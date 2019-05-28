using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bezel8PlusApp
{
    public partial class TxnForm : Form
    {
        
        private SerialPortManager serialPort = SerialPortManager.Instance;

        public TxnForm()
        {
            InitializeComponent();
            comBoxTxnType.SelectedIndex = 0;
            comBoxARC.SelectedIndex = 0;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //btnStart.Enabled = false;

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

            if (!t61Response.ToUpper().StartsWith("T620"))
            {
                MessageBox.Show(t61Response);
                //btnStart.Enabled = true;
                return;
            }
            
            string t61ResultCode = t61Response.Substring(4);
            switch (t61ResultCode)
            {
                case TxnResult.OnlineApprove:
                    MessageBox.Show("OnlineApprove");
                    break;

                case TxnResult.OfflineApprove:
                    MessageBox.Show("OfflineApprove");
                    break;

                case TxnResult.OfflineDecline:
                    MessageBox.Show("OfflineDecline");
                    break;

                case TxnResult.OnlineDecline:
                    MessageBox.Show("OnlineDecline");
                    break;

                case TxnResult.OfflineApproveSign:
                    MessageBox.Show("OfflineApproveSign");
                    break;

                case TxnResult.TryAnotherInterface:
                    MessageBox.Show("TryAnotherInterface");
                    break;

                case TxnResult.OnlineAuthorizeReq:
                    MessageBox.Show("OnlineAuthorizeReq");
                    break;

                case TxnResult.ExternalPinBlockReq:
                    MessageBox.Show("ExternalPinBlockReq");
                    break;

                default:
                    MessageBox.Show(t61Response);
                    return;

            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //Console.WriteLine("cancel");
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
}
