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
        private Dictionary<string, string> receiptData;



        public TxnForm()
        {
            InitializeComponent();
            receiptForm = new ReceiptForm();
            receiptData = new Dictionary<string, string>();
            comBoxTxnType.SelectedIndex = 0;
            comBoxARC.SelectedIndex = 0;      
        }

        private void PrepareReceiptData()
        {
            // txnData[0]: transaction type
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

            // txnData[1]: Amount
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

            // txnData[2]: Amount Other
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

            // txnData[3]: Currency Code
            if (cbCurrencyCode.Checked)
            {
                if (textBoxCurrencyCode.Text.Equals("0840"))
                {
                    receiptData.Add("5F2A", "US");
                }
            }

            // txnData[4]: Transaction Result
            if (!string.IsNullOrEmpty(tbOutcome.Text))
            {
                receiptData.Add("OUTCOME", tbOutcome.Text);
            }


            // T63 to get receipt data
            int curPkg = 0, totalPkg = 0;
            string t63Response = String.Empty;
            string[] receiptTags = new string[] { "9F16", "9F1C", "9A", "9F21", "84", "5A", "9F5D" };          
            string t63Stream = string.Join(Convert.ToChar(0x1A).ToString(), receiptTags);
            // t64Stream = the sum of t63Responses
            string t64Stream = String.Empty;


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
                    return;
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

                int separatorIndex = t63Response.IndexOf(Convert.ToChar(0x1C));
                if (separatorIndex >= 0)
                    t64Stream += t63Response.Substring(separatorIndex + 1);

            } while (curPkg < totalPkg);

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            SetTxnInProgressUI();
            receiptForm.Clear();
            receiptData.Clear();

            // 1. Build T61 message
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

                default:
                    MessageBox.Show("Unknown Transaction Type.");
                    return;
            }

            // TranInfo
            t61Elements[4] += "40"; // Goods

            // Account Type
            t61Elements[5] += "00"; // Default

            // Force Online
            t61Elements[6] += "0";

            string t61Message = Convert.ToChar(0x1A).ToString() +
                String.Join(Convert.ToChar(0x1A).ToString(), t61Elements) +
                Convert.ToChar(0x1A).ToString();

            // 2. Send T61 message
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
                    receiptForm.Print();
                    tbOutcome.Text = "Online Approve";
                    break;

                case TxnResult.OfflineApprove:
                    receiptForm.Print();
                    tbOutcome.Text = "Offline Approve";
                    break;

                case TxnResult.OfflineDecline:
                    receiptForm.Print();
                    tbOutcome.Text = "Offline Decline";
                    break;

                case TxnResult.OnlineDecline:
                    receiptForm.Print();
                    tbOutcome.Text = "Online Decline";
                    break;

                case TxnResult.OfflineApproveSign:
                    receiptForm.Print(true);
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
                tbOnlineData.AppendText(tlvHexString + Environment.NewLine);
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
                Thread.Sleep(1500);
                btnHostSend_Click(this, null);
            }
            else
            {
                btnStart.Enabled = false;
                btnHostSend.Enabled = true;
            }
        }

        private void GetReceipt()
        {

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

        public class OutcomeDisplayMessage
        {
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
            //ClearReceipt();
        }
    }
}
