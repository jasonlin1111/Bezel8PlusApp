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
        private ReceiptForm receiptForm;

        List<TLVDataObject> dataRecord;
        List<TLVDataObject> discretionaryData;

        public TxnForm()
        {
            InitializeComponent();
            receiptForm = new ReceiptForm();
            dataRecord = new List<TLVDataObject>();
            discretionaryData = new List<TLVDataObject>();
            comBoxTxnType.SelectedIndex = 0;
            comBoxARC.SelectedIndex = 0;      
        }

        /// <summary>
        /// Build a string for T61 Packet command
        /// </summary>
        private string PrepareTxnData()
        {
            string txnData = String.Empty;

            //[AmtAuth][AmtOther][CurExponent + CurCode][TranType][TranInfo][Account Type][Force Online]
            string[] t61Elements = new string[7];
            for (int i = 0; i < t61Elements.Length; i++)
                t61Elements[i] = String.Empty;

            // AmtAuth
            if (cbAmountAuth.Checked)
            {
                // Amount present
                if (textBoxAmountAuth.Text.Length != 0)
                {
                    t61Elements[0] += textBoxAmountAuth.Text.PadLeft(12, '0');
                }
                else
                {
                    // Amount present but empty
                    t61Elements[0] += String.Empty.PadLeft(12, 'F');
                }
            }

            // AmtOther
            if (cbAmountOther.Checked)
            {
                // Amount, Other present
                if (textBoxAmountOther.Text.Length != 0)
                {
                    t61Elements[1] += textBoxAmountOther.Text.PadLeft(12, '0');
                }
                else
                {
                    // Amount, Other present but empty
                    t61Elements[1] += String.Empty.PadLeft(12, 'F');
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
                t61Elements[2] += exp.ToString();
            }
            if (cbCurrencyCode.Checked)
            {
                string cc = textBoxCurrencyCode.Text.PadLeft(4, '0').Substring(1);
                t61Elements[2] += cc;
            }

            // TranType
            switch (comBoxTxnType.SelectedItem.ToString().ToUpper())
            {
                case "PURCHASE":
                    t61Elements[3] += "00";
                    break;

                case "CASH":
                    t61Elements[3] += "01";
                    break;

                case "PURCHASE WITH CASHBACK":
                    t61Elements[3] += "09";
                    break;

                case "REFUND":
                    t61Elements[3] += "20";
                    break;
            }

            // TranInfo
            t61Elements[4] += "40"; // Goods

            // Account Type
            t61Elements[5] += "00"; // Default

            // Force Online
            t61Elements[6] += "0";

            txnData = Convert.ToChar(0x1A).ToString() +
                String.Join(Convert.ToChar(0x1A).ToString(), t61Elements) +
                Convert.ToChar(0x1A).ToString();

            return txnData;


        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            SetTxnInProgressUI();
            receiptForm.Hide();

            string t61Message = PrepareTxnData();
            string t61Response = String.Empty;

            try
            {
                serialPort.WriteAndReadMessage(PktType.STX, "T61", t61Message, out t61Response);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //btnStart.Enabled = true;
                return;
            }

            TransactionResultAnalyze(t61Response);
    
        }

        private void TransactionResultAnalyze(string result)
        {
            // Fail
            if (string.IsNullOrEmpty(result))
                return;
            if (!result.ToUpper().StartsWith("T620"))
            {
                //MessageBox.Show(result);
                tbOutcome.Text = result;
                return;
            }

            // Success
            switch (result.Substring(4))
            {
                case TxnResult.OnlineApprove:
                    PrintReceipt("Approve", false);
                    tbOutcome.Text = "Online Approve";
                    break;

                case TxnResult.OfflineApprove:
                    PrintReceipt("Approve", false);
                    tbOutcome.Text = "Offline Approve";
                    break;

                case TxnResult.OfflineDecline:
                    PrintReceipt("Decline", false);
                    tbOutcome.Text = "Offline Decline";
                    break;

                case TxnResult.OnlineDecline:
                    PrintReceipt("Decline", false);
                    tbOutcome.Text = "Online Decline";
                    break;

                case TxnResult.OfflineApproveSign:
                    PrintReceipt("Approve", true);
                    tbOutcome.Text = "Offline Approve";
                    break;

                case TxnResult.TryAnotherInterface:
                    tbOutcome.Text = "Terminated";
                    break;

                case TxnResult.OnlineAuthorizeReq:
                    tbOutcome.Text = "Online Authorizing";
                    GetOnlineData("0");
                    GetOnlineData("1");
                    OnlineAuthorization();
                    break;

                case TxnResult.ExternalPinBlockReq:
                    MessageBox.Show("ExternalPinBlockReq");
                    break;

                default:
                    MessageBox.Show(result);
                    break;

            }
            ResetToIdleState();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            string t6CResponse = String.Empty;
            try
            {
                serialPort.WriteAndReadMessage(PktType.STX, "T6C", "", out t6CResponse);
                MessageBox.Show(t6CResponse);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void GetOnlineData(string dataType)
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
                    MessageBox.Show(ex.Message);
                    return;
                }

                if (t65Response.ToUpper().StartsWith("T66F"))
                {
                    //MessageBox.Show(t65Response);
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
                //Console.WriteLine(tlvHexString);
            }
        }

        private void OnlineAuthorization()
        {
            string t71Response = String.Empty;
            string IAD = String.Empty;
            string ARC = String.Empty;

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
                    MessageBox.Show(ex.Message);
                }

            }
            else if (cbAutoReply.Checked)
            {
                Thread.Sleep(1000);
                btnHostSend_Click(this, null);
            }
            else
            {
                btnStart.Enabled = false;
                btnHostSend.Enabled = true;
            }
        }

        private void btnHostSend_Click(object sender, EventArgs e)
        {
            string t71Response = String.Empty;
            string IAD = String.Empty;
            string ARC = String.Empty;

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
            {
                switch (comBoxTxnType.SelectedIndex)
                {
                    case 0:
                        receiptData.Add("9C", "Purchase");
                        break;
                    case 1:
                        receiptData.Add("9C", "Cash");
                        break;
                    case 2:
                        receiptData.Add("9C", "Purchase with cashback");
                        break;
                    case 3:
                        receiptData.Add("9C", "Refund");
                        break;
                }
            }

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
            string[] receiptTags = new string[] { "9F16", "9F1C", "9F21", "84", "5A", "9F5D" };
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

        private void PrintReceipt(string outcome, bool needSign)
        {
            Dictionary<string, string> receiptData = PrepareReceiptData();
            receiptForm.SetupReceipt(ref receiptData, outcome, needSign);
            receiptForm.Show();
        }

        private void ResetToIdleState()
        {
            btnStart.Enabled = true;
            btnHostSend.Enabled = false;
        }

        private void SetTxnInProgressUI()
        {
            btnStart.Enabled = false;
            btnCancel.Enabled = true;
            tbOutcome.Clear();
            tbOnlineData.Clear();
        }
    }

    public class TxnResult
    {
        public const string OnlineApprove = "Y4";
        public const string OfflineApprove = "Y1";
        public const string OfflineDecline = "Z1";
        public const string OnlineDecline = "Z4";
        public const string OfflineApproveSign = "Y7";
        public const string TryAnotherInterface = "B0";
        public const string OnlineAuthorizeReq = "A1";
        public const string ExternalPinBlockReq = "A5";
    }
}
