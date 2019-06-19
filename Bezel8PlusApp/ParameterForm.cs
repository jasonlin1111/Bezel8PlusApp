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
    public partial class ParameterForm : Form
    {

        private SerialPortManager serialPort = SerialPortManager.Instance;

        public ParameterForm()
        {
            InitializeComponent();
            cbbAmount0Check.SelectedIndex = 0;
            cbbTxnType.SelectedIndex = 0;
        }



        private void btnGetTime_Click(object sender, EventArgs e)
        {
            tbYear.Text = DateTime.Now.Year.ToString("0000");
            tbMonth.Text = DateTime.Now.Month.ToString("00");
            tbDay.Text = DateTime.Now.Day.ToString("00");
            tbHour.Text = DateTime.Now.Hour.ToString("00");
            tbMinute.Text = DateTime.Now.Minute.ToString("00");
            tbSecond.Text = DateTime.Now.Second.ToString("00");
        }

        private void btnSetTime_Click(object sender, EventArgs e)
        {
            string formattedDate = tbYear.Text + "/" + tbMonth.Text + "/" + tbDay.Text + " " +
                tbHour.Text + ":" + tbMinute.Text + ":" + tbSecond.Text;

            if (DateTime.TryParse(formattedDate, out DateTime date))
            {
                string datetime = date.ToString("yyyyMMdd") + ((int)date.DayOfWeek).ToString() + date.ToString("HHmmss");
                try
                {
                    serialPort.WriteAndReadMessage(PktType.SI, "18", datetime, out string response);
                    if (response.Equals("180"))
                        MessageBox.Show("Set date and time sucessfully");
                    else
                        MessageBox.Show(response);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Invalid Date");
            }
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;

            if (sender.Equals(cbAmount0Check))
                cbbAmount0Check.Enabled = cb.Checked ? true : false;

            if (sender.Equals(cbRCTLCheck))
                tbRCTL.Enabled = cb.Checked ? true : false;

            if (sender.Equals(cbCVMCheck))
                tbCVML.Enabled = cb.Checked ? true : false;

            if (sender.Equals(cbRCFLCheck))
                tbRCFL.Enabled = cb.Checked ? true : false;

            if (sender.Equals(cbTFLCheck))
                tbTFL.Enabled = cb.Checked ? true : false;

            if (sender.Equals(cbRevoList))
                tbRevoList.Enabled = cb.Checked ? true : false;
        }

        private void btnSetPara_Click(object sender, EventArgs e)
        {
            string s1C = Convert.ToChar(0x1C).ToString();
            string s1A = Convert.ToChar(0x1A).ToString();
            string t55Message = String.Empty;
            string tmp = String.Empty;

            string txnType = "00";
            string kID = "030000";
            string aID = "A000000003";

            t55Message += s1A + txnType + s1A + kID + s1A + aID;

            // Transaction Type: tag 9C
            t55Message += s1A + "9C" + s1C + "6" + s1C + txnType;

            // KID: tag DF810C
            t55Message += s1A + "DF810C" + s1C + "2" + s1C + kID;

            // AID: tag 9F06
            t55Message += s1A + "9F06" + s1C + "2" + s1C + aID;

            // TTQ; tag 9F66
            if (string.IsNullOrEmpty(tbTTQ.Text) || tbTTQ.Text.Length != 8)
            {
                MessageBox.Show("TTQ Error");
                return;
            }
            t55Message += s1A + "9F66" + s1C + "2" + s1C + tbTTQ.Text;

            // DRL Enable: tag FFFF800F
            tmp = cbDRL.Checked ? "01" : "00";
            t55Message += s1A + "FFFF800F" + s1C + "2" + s1C + tmp;

            // Status Checking: tag FFFF8007
            tmp = cbStatusCheck.Checked ? "01" : "00";
            t55Message += s1A + "FFFF8007" + s1C + "2" + s1C + tmp;

            // Amount Zero Checking: tag FFFF8005
            tmp = cbAmount0Check.Checked ? "01" : "00";
            t55Message += s1A + "FFFF8005" + s1C + "2" + s1C + tmp;

            // Amount Zero Option: tag FFFF8008
            if (!cbAmount0Check.Checked)
                tmp = "01";
            else
                tmp = cbbAmount0Check.SelectedIndex == 0 ? "01" : "02";
            t55Message += s1A + "FFFF8008" + s1C + "2" + s1C + tmp;

            // Reader Contactless Transaction Limit Checking: tag FFFF8004
            tmp = cbRCTLCheck.Checked ? "01" : "00";
            t55Message += s1A + "FFFF8004" + s1C + "2" + s1C + tmp;

            // Reader Contactless Transaction Limit: tag DF8124
            tmp = tbRCTL.Text;
            if (tmp.Length < 12)
                tmp = tmp.PadLeft(12, '0');
            t55Message += s1A + "DF8124" + s1C + "2" + s1C + tmp;

            // CVM Required Limit Checking: tag FFFF8009
            tmp = cbCVMCheck.Checked ? "01" : "00";
            t55Message += s1A + "FFFF8009" + s1C + "2" + s1C + tmp;

            // CVM Required Limit: tag DF8126
            tmp = tbCVML.Text;
            if (tmp.Length < 12)
                tmp = tmp.PadLeft(12, '0');
            t55Message += s1A + "DF8126" + s1C + "2" + s1C + tmp;

            // Reader CL Floor Limit Checking: tag FFFF800A
            int checking = 0;
            if (cbRCFLCheck.Checked)
                checking += 1;
            if (cbTFLCheck.Checked)
                checking += 10;
            t55Message += s1A + "FFFF800A" + s1C + "2" + s1C + checking.ToString("00");

            // Reader CL Floor Limit: tag DF8123
            tmp = tbRCFL.Text;
            if (!string.IsNullOrEmpty(tmp))
            {
                if (tmp.Length < 12)
                    tmp = tmp.PadLeft(12, '0');
                t55Message += s1A + "DF8123" + s1C + "2" + s1C + tmp;
            }

            // Terminal Floor Limit: tag 9F1B
            tmp = tbTFL.Text;
            if (!string.IsNullOrEmpty(tmp))
            {
                if (Int32.TryParse(tmp, out int tfl))
                {
                    t55Message += s1A + "9F1B" + s1C + "2" + s1C + tfl.ToString("X8");
                }
            }

            // Certification Revocation List Enable: tag FFFF8217
            tmp = cbRevoList.Checked ? "01" : "00";
            t55Message += s1A + "FFFF8217" + s1C + "2" + s1C + tmp;

            // Certification Revocation List: tag FFFF8211
            if (cbRevoList.Checked)
                t55Message += s1A + "FFFF8211" + s1C + "2" + s1C + tbRevoList.Text;

            // CVN 17 Enable: tag FFFF8006
            tmp = cbCVN17.Checked ? "01" : "00";
            t55Message += s1A + "FFFF8006" + s1C + "2" + s1C + tmp;

            // Sending T55 Message
            try
            {
                serialPort.WriteAndReadMessage(PktType.STX, "T5511", t55Message, out string t55Response, true, 2000);
                if (t55Response.Equals("T560"))
                    MessageBox.Show("Success");
                else
                    MessageBox.Show($"Fail: {t55Response}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbPAN.Text))
                return;

            string t77Message = Convert.ToChar(0x1A).ToString() + tbPAN.Text + Convert.ToChar(0x1A).ToString();
            try
            {
                serialPort.WriteAndReadMessage(PktType.STX, "T77", t77Message, out string t77Response);
                if (t77Response.ToUpper().Equals("T780"))
                    MessageBox.Show("Add exception file sucessfully");
                else
                    MessageBox.Show($"Add exception file failed: {t77Response}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort.WriteAndReadMessage(PktType.STX, "T77", Convert.ToChar(0x1A).ToString() + "FF", out string t77Response);
                if (t77Response.ToUpper().Equals("T780"))
                    MessageBox.Show("Remove all exception files sucessfully");
                else
                    MessageBox.Show($"Remove all exception files failed: {t77Response}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
