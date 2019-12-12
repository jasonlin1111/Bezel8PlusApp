using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using System.Net;
using System.IO;

namespace Bezel8PlusApp
{
    public partial class TxnForm : Form
    {
        
        private SerialPortManager serialPort = SerialPortManager.Instance;
        private TxnReceiptForm receiptForm;
        private TxnOnlinePinForm onlinePinForm;

        private bool btnHostSendPressed = false;
        private bool btnCancelPressed = false;

        List<TLVDataObject> dataRecord;
        List<TLVDataObject> discretionaryData;

        public static event EventHandler TxnStartEventHandler;
        public static event EventHandler TxnFinishEventHandler;

        public TxnForm()
        {
            InitializeComponent();

            comBoxTxnType.DataSource = new string[] { "Purchase", "Refund" };
            comBoxARC.DataSource = new string[] { "3030  (Approve)", "3531  (Decline)" };

            receiptForm = new TxnReceiptForm();
            onlinePinForm = new TxnOnlinePinForm();

            dataRecord = new List<TLVDataObject>();
            discretionaryData = new List<TLVDataObject>();

            receiptForm.TopLevel = false;
            receiptForm.Visible = false;
            receiptForm.FormBorderStyle = FormBorderStyle.None;
            receiptForm.Dock = DockStyle.Fill;
            gbReceipt.Controls.Add(receiptForm);
        }

        public void OnTxnStartEventCall(EventArgs e)
        {
            tbOutcome.Text = "Processing ...";
            //tbOutcome.Clear();
            tbOnlineData.Clear();
            btnStart.Enabled = false;
            receiptForm.Visible = false;

            if (TxnStartEventHandler != null)
                TxnStartEventHandler(this, e);
        }

        public void OnTxnFinishEventCall(EventArgs e)
        {
            btnStart.Enabled = true;
            btnCancel.Enabled = true;
            btnHostSend.Enabled = false;

            if (TxnFinishEventHandler != null)
                TxnFinishEventHandler(this, e);
        }

        public void OnTxnWaitForHostEventCall()
        {
            btnCancel.Enabled = false;
            btnHostSend.Enabled = true;
        }

        public void OnResetToIdleEventCall(EventArgs e)
        {
            tbOutcome.Clear();
            OnTxnFinishEventCall(e);
        }

        private void MagneticStripeTransaction()
        {
            try
            {
                serialPort.WriteAndReadMessage(PktType.STX, "V07", "", out string response);
                string[] trackData = response.Split(Convert.ToChar(0x1A));
                tbOnlineData.AppendText("Track 1: " + trackData[1] + Environment.NewLine);
                tbOnlineData.AppendText("Track 2: " + trackData[2] + Environment.NewLine);
                //tbOnlineData.AppendText("Track 3: " + trackData[3] + Environment.NewLine);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                OnResetToIdleEventCall(null);
            }
        }

        private void ContactTransaction()
        {
            try
            {
                // Step 1: Application Select - T11
                serialPort.WriteAndReadMessage(PktType.STX, "T11", "", out string t11Response);
                if (!t11Response.StartsWith("T120"))
                {
                    tbOutcome.Text = "Contact - Terminated";
                    return;
                }
                string aid = t11Response.Substring(4);
                if (String.IsNullOrEmpty(aid))
                {
                    tbOutcome.Text = "Contact - Candidate List Empty";
                    return;
                }

                // Step 2: Start Transaction - T15
                string t15Message = PrepareTxnData(true);
                serialPort.WriteAndReadMessage(PktType.STX, "T15", t15Message, out string t15Response);
                if (!t15Response.StartsWith("T160"))
                {
                    tbOutcome.Text = "Contact - Transaction Fail";
                    return;
                }
                ContactTransactionResultAnalyze(t15Response.Substring(4, 2));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ContactTransactionResultAnalyze(string result)
        {
            switch (result)
            {
                case TxnResult.OfflineApprove:
                case TxnResult.OnlineApprove:
                    tbOutcome.Text = "Contact - Approved";
                    break;

                case TxnResult.OnlineDecline:
                case TxnResult.OfflineDecline:
                    tbOutcome.Text = "Contact - Declined";
                    break;

                case TxnResult.OnlineAuthorizeReq:
                    tbOutcome.Text = "Contact - Online Authorizing";
                    Thread.Sleep(1000);
                    string t17Message = Convert.ToChar(0x1A).ToString() + "00" + Convert.ToChar(0x1A).ToString();
                    try
                    {
                        serialPort.WriteAndReadMessage(PktType.STX, "T171", t17Message, out string t17Response);
                        if (!t17Response.StartsWith("T160"))
                        {
                            throw new Exception();
                        }
                        ContactTransactionResultAnalyze(t17Response.Substring(4, 2));
                    }
                    catch (Exception)
                    {
                        tbOutcome.Text = "Contact - Transaction Fail";
                        serialPort.WriteAndReadMessage(PktType.STX, "T1C", "", out string response1, false);
                    }
                    break;

                case TxnResult.ExternalPinBlockReq:
                    tbOutcome.Text = "Please Enter PIN";
                    onlinePinForm.Show();
                    while (onlinePinForm.Visible == true)
                    {
                        Application.DoEvents();
                    }
                    OnlinePINProcess(onlinePinForm.GetPIN(), true);
                    /*
                    if (!string.IsNullOrEmpty(onlinePinForm.GetPIN()))
                        tbOnlineData.AppendText("PIN BLOCK: " + onlinePinForm.GetPINBlock() + Environment.NewLine);
                    */
                    break;

                default:
                    tbOutcome.Text = "Contact Transaction Result - " + result;
                    serialPort.WriteAndReadMessage(PktType.STX, "T1C", "", out string response, false);
                    break;
            }
        }

        /// <summary>
        /// Build a string for T61 Packet command
        /// </summary>
        private string PrepareTxnData(bool contact_version = false)
        {
            string txnData = String.Empty;

            //[AmtAuth][AmtOther][CurExponent + CurCode][TranType][TranInfo][Account Type][Force Online]
            string[] elements = new string[7];
            for (int i = 0; i < elements.Length; i++)
                elements[i] = String.Empty;

            // AmtAuth
            if (cbAmountAuth.Checked)
            {
                // Amount present
                if (textBoxAmountAuth.Text.Length != 0)
                {
                    elements[0] += textBoxAmountAuth.Text.PadLeft(12, '0');
                }
                else
                {
                    // Amount present but empty
                    elements[0] += String.Empty.PadLeft(12, 'F');
                }
            }

            // AmtOther
            if (contact_version)
            {
                elements[1] += String.Empty.PadLeft(12, '0');
            }
            else if (cbAmountOther.Checked)
            {
                // Amount, Other present
                if (textBoxAmountOther.Text.Length != 0)
                {
                    elements[1] += textBoxAmountOther.Text.PadLeft(12, '0');
                }
                else
                {
                    // Amount, Other present but empty
                    elements[1] += String.Empty.PadLeft(12, 'F');
                }
            }

            // CurExponent + CurCode
            if (cbCurrencyExp.Checked)
            {
                int exp;
                if (Int32.TryParse(textBoxCurrencyExp.Text, out exp))
                {
                    if (exp >= 10)
                        exp %= 10;
                }
                elements[2] += exp.ToString();
            }
            if (cbCurrencyCode.Checked)
            {
                string cc = textBoxCurrencyCode.Text.PadLeft(4, '0').Substring(1);
                elements[2] += cc;
            }

            // TranType
            switch (comBoxTxnType.SelectedItem.ToString().ToUpper())
            {
                case "PURCHASE":
                    elements[3] += "00";
                    break;

                case "CASH":
                    elements[3] += "01";
                    break;

                case "PURCHASE WITH CASHBACK":
                    elements[3] += "09";
                    break;

                case "REFUND":
                    elements[3] += "20";
                    break;
            }

            // TranInfo
            elements[4] += "40"; // Goods

            // Account Type
            elements[5] += "00"; // Default

            // Force Online
            elements[6] += "0";

            txnData = Convert.ToChar(0x1A).ToString() + String.Join(Convert.ToChar(0x1A).ToString(), elements);
            if (!contact_version)
            {
                txnData += Convert.ToChar(0x1A).ToString();
            }
            return txnData;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            AUTO_RUN:
            OnTxnStartEventCall(e);

            string t61Message = PrepareTxnData();
            string t61Response = String.Empty;

            try
            {
                if (cbTimeout.Checked)
                {
                    serialPort.WriteAndReadMessage(PktType.STX, "V09", Convert.ToChar(0x1A).ToString() + textBoxTimeout.Text, out string v09Response);
                    if (!v09Response.ToUpper().Equals("V0A0"))
                    {
                        throw new Exception("Setting Timeout Period Failed");
                    }
                }
                serialPort.WriteAndReadMessage(PktType.STX, "T61", t61Message, out t61Response);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                OnResetToIdleEventCall(e);
                return;
            }

            TransactionResultAnalyze(t61Response);
            OnTxnFinishEventCall(e);


            if (cbAutoRun.Checked)
            {
                int delayTime;
                if (!Int32.TryParse(tbAutoRunTime.Text, out delayTime))
                    delayTime = 1000;
                Thread.Sleep(delayTime);
                goto AUTO_RUN;
            }

        }

        private void TransactionResultAnalyze(string result)
        {
            if (string.IsNullOrEmpty(result))
                return;

            if (result.ToUpper().StartsWith("T6211"))
            {
                string error_code = result.Substring(5);
                switch (error_code)
                {
                    case TxnResult.EndApplication:
                        tbOutcome.Text = "Terminated";
                        break;

                    case TxnResult.TransactionCancelled:
                        tbOutcome.Clear();
                        break;

                    case TxnResult.InterruptedByICC:
                        // Contact Transaction
                        tbOutcome.Text = "Contact Transaction";
                        ContactTransaction();
                        break;

                    case TxnResult.InterruptedByMSR:
                        tbOutcome.Text = "Magnetic Stripe Transaction";
                        MagneticStripeTransaction();
                        break;

                    default:
                        tbOutcome.Text = result;
                        break;
                }
            }
            else if (result.ToUpper().StartsWith("T620"))
            {
                string outcome = result.Substring(4);
                switch (result.Substring(4))
                {
                    case TxnResult.OnlineApprove:
                    case TxnResult.OnlineApproveSign:
                        PrintReceipt("Approve");
                        tbOutcome.Text = "Online Approved";
                        break;

                    case TxnResult.OfflineApprove:
                    case TxnResult.OfflineApproveSign:
                        try
                        {
                            GetOutputData("0");
                            GetOutputData("1");
                            GetEntryMode();
                            PrintReceipt("Approve");
                            tbOutcome.Text = "Offline Approved";
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            OnResetToIdleEventCall(null);
                        }  
                        break;

                    case TxnResult.OfflineDecline:
                        try
                        {
                            GetOutputData("0");
                            GetOutputData("1");
                            GetEntryMode();
                            PrintReceipt("Decline");
                            tbOutcome.Text = "Offline Declined";
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            OnResetToIdleEventCall(null);
                        }
                        break;

                    case TxnResult.UnOnlineOfflineDeclineSign:
                        PrintReceipt("Decline");
                        tbOutcome.Text = "Offline Declined";
                        break;

                    case TxnResult.OnlineDecline:
                        PrintReceipt("Decline");
                        tbOutcome.Text = "Online Declined";
                        break;

                    case TxnResult.TryAnotherInterface:
                        // Shall launch a cantact transaction
                        tbOutcome.Text = "Terminated";
                        break;

                    case TxnResult.OnlineAuthorizeReq:
                        tbOutcome.Text = "Online Authorizing";
                        try
                        {
                            GetOutputData("0");
                            GetOutputData("1");
                            GetEntryMode();
                            OnlineAuthorization();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            OnResetToIdleEventCall(null);
                        }
                        break;

                    case TxnResult.ExternalPinBlockReq:
                        tbOutcome.Text = "Please Enter PIN";
                        onlinePinForm.Show();
                        while (onlinePinForm.Visible == true)
                        {
                            Application.DoEvents();
                        }
                        OnlinePINProcess(onlinePinForm.GetPIN());
                        if (!string.IsNullOrEmpty(onlinePinForm.GetPIN()))
                            tbOnlineData.AppendText("PIN BLOCK: " + onlinePinForm.GetPINBlock() + Environment.NewLine);
                        break;

                    default:
                        tbOutcome.Text = result;
                        break;
                }
            }
            else
            {
                tbOutcome.Text = result;
            } 
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

            btnCancelPressed = true;
            string t6CResponse = String.Empty;
            try
            {
                serialPort.WriteAndReadMessage(PktType.STX, "T6C", "", out t6CResponse, false); 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                OnResetToIdleEventCall(e);
            }

        }

        private void OnlinePINProcess(string pinText, bool contact_version = false)
        {
            if (string.IsNullOrEmpty(pinText)) { }

            try
            {
                string head = contact_version ? "T1F" : "T6F";
                serialPort.WriteAndReadMessage(PktType.STX, head, "1", out string response);
                if (contact_version)
                {
                    ContactTransactionResultAnalyze(TxnResult.OnlineAuthorizeReq);
                }
                else
                {
                    TransactionResultAnalyze(response);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                OnResetToIdleEventCall(null);
            }
        }

        private void GetOutputData(string dataType)
        {
            int curPkg, totalPkg;
            string t65Response = String.Empty;
            string tlvHexString = String.Empty;

            do
            {
                try
                {
                    serialPort.WriteAndReadMessage(PktType.STX, "T65", dataType, out t65Response);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                if (t65Response.ToUpper().StartsWith("T66F"))
                {
                    return;
                }
                else if (!Int32.TryParse(t65Response.Substring(3, 1), out curPkg) || !Int32.TryParse(t65Response.Substring(4, 1), out totalPkg))
                {
                    MessageBox.Show($"GetDataRecord failed. {t65Response}");
                    return;
                }

                int separatorIndex = t65Response.IndexOf(Convert.ToChar(0x1C));
                if (separatorIndex >= 0)
                    tlvHexString += t65Response.Substring(separatorIndex + 1);
                
            } while (curPkg < totalPkg);

            if (!string.IsNullOrEmpty(tlvHexString))
            {
                if (dataType == "0")
                {
                    dataRecord = TLVDataObject.ConvertToTLVList(tlvHexString);
                    foreach (TLVDataObject dataObj in dataRecord)
                    {
                        tbOnlineData.AppendText(dataObj.TagString() + "\t" + dataObj.ValueString() + Environment.NewLine);
                    }
                }
                else if (dataType == "1")
                {
                    discretionaryData = TLVDataObject.ConvertToTLVList(tlvHexString);
                    foreach (TLVDataObject dataObj in discretionaryData)
                    {
                        tbOnlineData.AppendText(dataObj.TagString() + "\t" + dataObj.ValueString() + Environment.NewLine);
                    }
                }
            }
        }

        private void GetEntryMode()
        {
            string tagPOSEntryMode = "9F39";
            string tagTerEntryCapability = "FFFF8204";
            string s1A = Convert.ToChar(0x1A).ToString();
            string t63Message = tagPOSEntryMode + s1A + tagTerEntryCapability;

            try
            {
                serialPort.WriteAndReadMessage(PktType.STX, "T63", t63Message, out string t63Response);
                if (t63Response.ToUpper().StartsWith("T64F"))
                    return;


                string[] dataObj = t63Response.Split(Convert.ToChar(0x1A));
                tbOnlineData.AppendText(Environment.NewLine);
                foreach (string data in dataObj)
                {
                    string[] tlv = data.Split(Convert.ToChar(0x1C));
                    if (tlv.Length == 3)
                    {
                        if (tlv[0].Equals(tagPOSEntryMode))
                            tbOnlineData.AppendText("POS Entry Mode: " + tlv[2] + Environment.NewLine);
                        else if (tlv[0].Equals(tagTerEntryCapability))
                            tbOnlineData.AppendText("Terminal Entry Capability: " + tlv[2] + Environment.NewLine);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void OnlineAuthorization()
        {
            string t71Response = String.Empty;
            string IAD = String.Empty;
            string ARC = String.Empty;

            btnHostSendPressed = false;
            btnCancelPressed = false;
            btnHostSend.Enabled = true;

            if (cbARC.Checked)
            {
                if (comBoxARC.SelectedIndex == 0)
                {
                    ARC += "00";
                }
                else
                {
                    ARC += "51";
                }
            }

            if (cbIAD.Checked)
            {
                IAD += tbIAD.Text;
            }

            if (cbNoAuthRes.Checked)
            {
                try
                {
                    serialPort.WriteAndReadMessage(PktType.STX, "T71", "0", out t71Response);
                    TransactionResultAnalyze(t71Response);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            else if (cbAutoReply.Checked)
            {
                Thread.Sleep(1000);
                btnHostSend_Click(this, null);
            }
            else
            {
                OnTxnWaitForHostEventCall();
                while (!btnHostSendPressed && !btnCancelPressed)
                {
                    Application.DoEvents();
                }
            }

        }

        private void btnHostSend_Click(object sender, EventArgs e)
        {
            string t71Response = String.Empty;
            string IAD = String.Empty;
            string ARC = String.Empty;

            btnHostSendPressed = true;

            if (cbARC.Checked)
            {
                if (comBoxARC.SelectedIndex == 0)
                {
                    ARC += "00";
                }
                else
                {
                    ARC += "51";
                }
            }

            if (cbIAD.Checked)
            {
                IAD += tbIAD.Text;
            }

            string t71Body = String.Empty;
            if (cbNoAuthRes.Checked)
            {
                t71Body = "0";
            }
            else
            {
                t71Body = "1" + Convert.ToChar(0x1A).ToString() +
                    ARC + Convert.ToChar(0x1A).ToString() + IAD;
            }

            try
            {
                serialPort.WriteAndReadMessage(PktType.STX, "T71", t71Body, out t71Response);
                TransactionResultAnalyze(t71Response);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private Dictionary<string, string> PrepareReceiptData()
        {
            Dictionary<string, string> receiptData = new Dictionary<string, string>();

            // Transaction type
            if (cbTxnType.Checked)
                receiptData.Add("9C", comBoxTxnType.SelectedItem.ToString());


            int exp;
            if (!Int32.TryParse(textBoxCurrencyExp.Text, out exp))
                exp = 0;

            // Amount
            if (cbAmountAuth.Checked)
            {
                if (textBoxAmountAuth.Text.Equals("FFFFFFFFFFFF"))
                    receiptData.Add("9F02", String.Empty);
                else if (exp <= textBoxAmountAuth.Text.Length)
                {
                    int amount;
                    if (!Int32.TryParse(textBoxAmountAuth.Text.Substring(0, textBoxAmountAuth.Text.Length - exp), out amount))
                        amount = 0;
                    receiptData.Add("9F02", amount.ToString() + "." + textBoxAmountAuth.Text.Substring(textBoxAmountAuth.Text.Length - exp));
                }
            }

            // Amount Other
            if (cbAmountOther.Checked)
            {
                if (textBoxAmountOther.Text.Equals("FFFFFFFFFFFF"))
                    receiptData.Add("9F03", String.Empty);
                else if (exp <= textBoxAmountOther.Text.Length)
                {
                    int amount;
                    if (!Int32.TryParse(textBoxAmountOther.Text.Substring(0, textBoxAmountOther.Text.Length - exp), out amount))
                        amount = 0;
                    receiptData.Add("9F03", amount.ToString() + "." + textBoxAmountOther.Text.Substring(textBoxAmountOther.Text.Length - exp));
                }
            }

            // Currency Code
            if (cbCurrencyCode.Checked)
            {
                if (textBoxCurrencyCode.Text.Equals("0840"))
                {
                    receiptData.Add("5F2A", "US");
                }
            }

            // From Data Record
            // 9A - Transaction Date
            // 57 - Track 2 Data
            foreach (TLVDataObject record in dataRecord)
            {
                if (record.TagString().ToUpper().Equals("9A") || record.TagString().Equals("57"))
                    receiptData.Add(record.TagString(), record.ValueString());
            }

            // 9F16 - Merchant Identifier
            // 9F1C - Terminal Identification
            // 9F21 - Transaction Time
            // 84   - Dedicated File (DF) Name
            // 5A   - Application Primary Account Number (PAN)
            // 9F5D - AOSA
            // 9F34 - CVM Result
            string[] receiptTags = new string[] { "9F16", "9F1C", "9F21", "84", "5A", "9F5D", "9F34" };
            string t63Stream = string.Join(Convert.ToChar(0x1A).ToString(), receiptTags);

            // t64Stream = the sum of t63Responses
            string t64Stream = String.Empty;
            string t63Response = String.Empty;

            int curPkg = 0, totalPkg = 0;
            do
            {
                try
                {
                    if (curPkg == 0)
                        serialPort.WriteAndReadMessage(PktType.STX, "T63", t63Stream, out t63Response);
                    else
                        serialPort.WriteAndReadMessage(PktType.STX, "T63", "0", out t63Response);
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                    break;
                }

                if (t63Response.ToUpper().StartsWith("T64F"))
                {
                    //MessageBox.Show(t65Response);
                    break;
                }
                else if (!Int32.TryParse(t63Response.Substring(3, 1), out curPkg) || !Int32.TryParse(t63Response.Substring(4, 1), out totalPkg))
                {
                    //MessageBox.Show($"GetDataRecord failed. {t63Response}");
                    break;
                }

                int separatorIndex = t63Response.IndexOf(Convert.ToChar(0x1A));
                if (separatorIndex >= 0)
                    t64Stream += t63Response.Substring(separatorIndex + 1);

            } while (curPkg < totalPkg);

            string[] dataObj = t64Stream.Split(Convert.ToChar(0x1A));
            foreach (string data in dataObj)
            {
                string[] tlv = data.Split(Convert.ToChar(0x1C));
                if (tlv.Length == 3)
                {
                    receiptData.Add(tlv[0], tlv[2]);
                }
            }

            return receiptData;
        }

        private void PrintReceipt(string outcome)
        {
            Dictionary<string, string> receiptData = PrepareReceiptData();
            receiptForm.SetupReceipt(ref receiptData, outcome);
            receiptForm.Visible = true;
        }

        private void cbAutoRun_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAutoRun.Checked)
            {
                tbAutoRunTime.Enabled = true;
                lbMs.Enabled = true;
            }
            else
            {
                tbAutoRunTime.Enabled = false;
                lbMs.Enabled = false;
            }
        }

        private void cbTimeout_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTimeout.Checked)
                textBoxTimeout.Enabled = true;
            else
                textBoxTimeout.Enabled = false;
        }
    }

    public class TxnResult
    {
        // Success
        public const string OnlineApprove = "Y4";
        public const string OfflineApprove = "Y1";
        public const string OfflineDecline = "Z1";
        public const string OnlineDecline = "Z4";
        public const string OfflineApproveSign = "Y7";
        public const string TryAnotherInterface = "B0";
        public const string OnlineAuthorizeReq = "A1";
        public const string ExternalPinBlockReq = "A5";
        public const string UnOnlineOfflineApproveSign = "Y8";
        public const string UnOnlineOfflineApprove = "Y3";
        public const string OnlineApproveSign = "Y9";
        public const string UnOnlineOfflineDeclineSign = "Z3";

        // Error
        public const string TransactionCancelled = "F1111111";
        public const string InterruptedByICC = "F1111112";
        public const string InterruptedByMSR = "F1111113";
        public const string EndApplication = "00000007";

    }

}
