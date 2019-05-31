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
        private SerialPortManager serialPort = SerialPortManager.Instance;
        private string[] receiptTags = new string[] { "9F16", "9F1C", "9A", "9F21", "84", "5A", "9C", "9F02", "9F5D" };

        private Dictionary<string, Label> labelTable = new Dictionary<string, Label>();

        public ReceiptForm()
        {
            InitializeComponent();
            InitializeLabelTable();
        }

        private void InitializeLabelTable()
        {
            labelTable.Add("9F16", lbMerchantID);
            labelTable.Add("9F1C", lbTerminalID);
            labelTable.Add("9A", lbDateTime);
            labelTable.Add("9F21", lbDateTime);
            labelTable.Add("84", lbAID);
            labelTable.Add("5A", lbCardNo);
            labelTable.Add("9C", lbTxnType);
            labelTable.Add("9F02", lbAmount);
            labelTable.Add("9F5D", lbAOSA);
        }

        private void GetReceiptData()
        {
            
            string t63Response = String.Empty;
            string t63Stream = string.Join(Convert.ToChar(0x1A).ToString(), labelTable.Keys.ToArray());
            Console.WriteLine(t63Stream);



            try
            {
                serialPort.WriteAndReadMessage(PktType.STX, "T63", t63Stream, out t63Response);
                Console.WriteLine(t63Response);
            }
            catch (Exception)
            {

            }

            string[] dataObjects = t63Response.Split(Convert.ToChar(0x1A));

            string date = String.Empty;
            string time = String.Empty;
            foreach (string dataObject in dataObjects)
            {
                string[] tlv = dataObject.Split(Convert.ToChar(0x1C));
                if (tlv.Length == 3 && labelTable.ContainsKey(tlv[0]))
                {
                    if (tlv[0].ToUpper().Equals("9A"))
                    {
                        int year;
                        //Int32.TryParse(tlv[2].Substring(0, 2), out year)
                    } else if (tlv[0].ToUpper().Equals("9F21"))
                    {

                    }
                    else
                    {
                        Label label;
                        labelTable.TryGetValue(tlv[0], out label);
                        label.Text = tlv[2];
                    }
                    
                }
            }
        }

        public void Print(bool singature = false)
        {
            GetReceiptData();

            if (singature)
                lbSign.Visible = true;
            else
                lbSign.Visible = false;

            this.Show();
        }

        public void Clear()
        {
            foreach (Label l in labelTable.Values)
            {
                l.Text = String.Empty;
            }
            lbSign.Visible = false;

            this.Hide();
        }

    }
}
