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
    public partial class ReceiptForm : Form
    {

        public ReceiptForm()
        {
            InitializeComponent();

        }

        public void SetupReceipt(ref Dictionary<string, string> receiptData, string outcome)
        {
            string context = String.Empty;

            // Merchant ID
            if (receiptData.TryGetValue("9F16", out context))
                lbMerchantID.Text = DataHandler.ConvertHexToAscii(context);
            else
                lbMerchantID.Text = String.Empty;

            // Terminal ID
            if (receiptData.TryGetValue("9F1C", out context))
                lbTerminalID.Text = DataHandler.ConvertHexToAscii(context);
            else
                lbTerminalID.Text = String.Empty;

            // AID
            if (receiptData.TryGetValue("84", out context))
                lbAID.Text = context;
            else
                lbAID.Text = String.Empty;

            // Card Type
            if (lbAID.Text.StartsWith("A000000003"))
            {
                lbCardType.Text = "VISA";
                lbTextCardType.Visible = true;
                lbCardType.Visible = true;
            } 
            else
            {
                lbTextCardType.Visible = false;
                lbCardType.Visible = false;
            }

            // Txn Type
            if (receiptData.TryGetValue("9C", out context))
                lbTxnType.Text = context;
            else
                lbTxnType.Text = String.Empty;

            // Amount
            if (receiptData.TryGetValue("9F02", out context))
                lbAmount.Text = context;
            else
                lbAmount.Text = String.Empty;

            // Amount Other
            if (receiptData.TryGetValue("9F03", out context)) {
                lbAmountOther.Text = context;
                lbTextAmountOther.Visible = true;
                lbAmountOther.Visible = true;
            }
            else
            {
                lbTextAmountOther.Visible = false;
                lbAmountOther.Visible = false;

            }

            // Date n Time
            if (receiptData.TryGetValue("9A", out context))
            {
                int yy = Int32.Parse(context.Substring(0, 2));
                if (yy >= 50)
                    yy += 1900;
                else
                    yy += 2000;

                if (context.Length == 6)
                    lbDateTime.Text = yy.ToString() + " / " + context.Substring(2, 2) + " / " + context.Substring(4);

                if (receiptData.TryGetValue("9F21", out context))
                    lbDateTime.Text += "  " + context.Substring(0, 2) + ":" + context.Substring(2, 2);
            }
            else
            {
                lbDateTime.Text = String.Empty;
            }

            // AOSA
            if (receiptData.TryGetValue("9F5D", out context))
            {
                double aosa = Double.Parse(context) / (double)100;
                lbAOSA.Text = aosa.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                lbTextAOSA.Visible = true;
                lbAOSA.Visible = true;
            }
            else
            {
                lbTextAOSA.Visible = false;
                lbAOSA.Visible = false;
            }

            // PAN
            if (receiptData.TryGetValue("5A", out context))
                lbCardNo.Text = context.Remove(6, 6).Insert(6, "******");
            else if (receiptData.TryGetValue("57", out context))
            {
                int separator = context.IndexOf('D');
                if (separator > 0)
                    lbCardNo.Text = context.Substring(0, separator).Remove(6, 6).Insert(6, "******");
            }
            else
            {
                lbCardNo.Text = String.Empty;
            }

            // CVM - signature
            if (receiptData.TryGetValue("9F34", out context))
            {
                byte[] CVMResult = DataHandler.HexStringToByteArray(context);
                if ((CVMResult[0] & 0x1E) == 0x1E)
                    lbSign.Visible = true;
                else
                    lbSign.Visible = false;
            }

            // Outcome
            if (!string.IsNullOrEmpty(outcome))
                lbOutcome.Text = outcome;
            else
                lbOutcome.Text = String.Empty;
            lbOutcome.Visible = false;

        }

        private void ReceiptForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
