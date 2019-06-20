﻿using System;
using System.IO;
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
        private readonly string path = @"C:\Users\9390\Desktop\B8p_config\template";
        private Dictionary<string, FileInfo> templateFiles;
        private List<string> cbbTepSource;


        public ParameterForm()
        {
            InitializeComponent();
            templateFiles = new Dictionary<string, FileInfo>();
            cbbTepSource = new List<string>();
            cbbAmount0Check.DataSource = new string[] { "Option 1", "Option 2" };
            cbbTxnType.SelectedIndex = 0;


            InitializeTemplates();
        }

        private void ResetUI()
        {
            tbTTQ.Text = "A6004000";
            foreach (Control crl in tlpQVSDC.Controls)
            {
                if (crl is CheckBox)
                {
                    CheckBox cb = crl as CheckBox;
                    cb.Checked = false;
                }
                else if (crl is TextBox)
                {
                    TextBox tb = crl as TextBox;
                    tb.Clear();
                    tb.Enabled = false;
                }
                else if (crl is ComboBox)
                {
                    ComboBox cbb = crl as ComboBox;
                    cbb.SelectedIndex = 0;
                    cbb.Enabled = false;
                }
            }

            cbCVN17.Checked = false;
            cbTrack1.Checked = false;
            cbTrack2.Checked = false;

        }

        private void InitializeTemplates()
        {
            DirectoryInfo dinfo = new DirectoryInfo(path);
            FileInfo[] templateFilesInfo = dinfo.GetFiles("*.txt");

            foreach (FileInfo file in templateFilesInfo)
            {
                string name = Path.GetFileNameWithoutExtension(file.Name);
                templateFiles.Add(name, file);
                if (name.ToUpper().Equals("DEFAULT"))
                    cbbTepSource.Insert(0, name);
                else
                    cbbTepSource.Add(name);
            }
            cbbTemplate.DataSource = cbbTepSource;

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

            // Reader Contactless Transaction Limit Checking DISABLE: tag FFFF8004
            tmp = cbRCTLCheck.Checked ? "00" : "01";
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

            // Exception File Checking: tag FFFF800C
            tmp = cbExceptionFile.Checked ? "01" : "00";
            t55Message += s1A + "FFFF800C" + s1C + "2" + s1C + tmp;

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

        private void btnGetPara_Click(object sender, EventArgs e)
        {
            string s1A = Convert.ToChar(0x1A).ToString();
            string me = s1A + "00" + s1A + "030000" + s1A + "A000000003";
            try
            {
                serialPort.WriteAndReadMessage(PktType.STX, "V052", me, out string v05Response);
                if (!v05Response.StartsWith("V0620"))
                {
                    MessageBox.Show($"Fail: {v05Response}");
                    return;
                }
                ResetUI();
                v05Response = v05Response.Substring(6);
                string[] dataObj = v05Response.Split(Convert.ToChar(0x1A));
                foreach (string data in dataObj)
                {
                    string[] tagFormatValue = data.Split(Convert.ToChar(0x1C));
                    if (tagFormatValue.Length == 3)
                        SetupUI(tagFormatValue[0], tagFormatValue[2]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void cbbTemplate_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbbTemplate.SelectedItem == null)
                return;
            Console.WriteLine(cbbTemplate.SelectedItem.ToString());
            ResetUI();

            if (templateFiles.TryGetValue(cbbTemplate.SelectedItem.ToString(), out FileInfo file))
            {
                try
                {
                    var sr = new StreamReader(file.FullName);

                    while (!sr.EndOfStream)
                    {
                        string sl = sr.ReadLine();
                        if (!string.IsNullOrEmpty(sl))
                        {
                            int descripePosition = sl.IndexOf("//");
                            if (descripePosition > 0)
                                sl = sl.Substring(0, descripePosition);

                            string[] tagValue = sl.Split('=');
                            if (tagValue.Length == 2)
                                SetupUI(tagValue[0].Trim(), tagValue[1].Trim());
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void SetupUI(string tag, string value)
        {
            if (tag == null || value == null)
                return;

            int intValue = -1;
            switch (tag)
            {
                // TTQ: tag 9F66
                case "9F66":
                    tbTTQ.Text = value;
                    break;

                // DRL Enable: tag FFFF800F
                case "FFFF800F":
                    if (Int32.TryParse(value, out intValue))
                        cbDRL.Checked = (intValue == 1) ? true : false; 
                    break;

                // Status Checking: tag FFFF8007
                case "FFFF8007":
                    if (Int32.TryParse(value, out intValue))
                        cbStatusCheck.Checked = (intValue == 1) ? true : false;
                    break;

                // Amount Zero Checking: tag FFFF8005
                case "FFFF8005": 
                    if (Int32.TryParse(value, out intValue))
                        cbAmount0Check.Checked = (intValue == 1) ? true : false;
                    break;

                // Amount Zero Option: tag FFFF8008
                case "FFFF8008":   
                    if (Int32.TryParse(value, out intValue))
                        cbbAmount0Check.SelectedIndex = (intValue == 2) ? 1 : 0;
                    break;

                // Reader Contactless Transaction Limit Checking DISABLE: tag FFFF8004
                case "FFFF8004":
                    if (Int32.TryParse(value, out intValue))
                        cbRCTLCheck.Checked = (intValue == 0) ? true : false;
                    break;

                // Reader Contactless Transaction Limit: tag DF8124
                case "DF8124": 
                    tbRCTL.Text = value;
                    break;

                // CVM Required Limit Checking: tag FFFF8009
                case "FFFF8009":
                    if (Int32.TryParse(value, out intValue))
                        cbCVMCheck.Checked = (intValue == 1) ? true : false;
                    break;

                // CVM Required Limit: tag DF8126
                case "DF8126":
                    tbCVML.Text = value;
                    break;

                // Reader CL Floor Limit Checking: tag FFFF800A
                case "FFFF800A":
                    if (Int32.TryParse(value, out intValue))
                        cbRCFLCheck.Checked = (intValue == 1) ? true : false;
                    break;

                // Reader CL Floor Limit: tag DF8123
                case "DF8123":
                    tbRCFL.Text = value;
                    break;

                // Terminal Floor Limit: tag 9F1B
                case "9F1B":
                    cbTFLCheck.Checked = true;
                    int tfl = Convert.ToInt32(value, 16);
                    tbTFL.Text = tfl.ToString().PadLeft(12, '0');
                    break;

                // Certification Revocation List Enable: tag FFFF8217
                case "FFFF8217":
                    if (Int32.TryParse(value, out intValue))
                        cbRevoList.Checked = (intValue == 1) ? true : false;
                    break;

                // Certification Revocation List: tag FFFF8211
                case "FFFF8211":
                    if (Int32.TryParse(value, out intValue))
                        tbRevoList.Text = value;
                    break;

                // CVN 17 Enable: tag FFFF8006
                case "FFFF8006":
                    if (Int32.TryParse(value, out intValue))
                        cbCVN17.Checked = (intValue == 1) ? true : false;
                    break;

                // Exception File Checking: tag FFFF800C
                case "FFFF800C":
                    if (Int32.TryParse(value, out intValue))
                        cbExceptionFile.Checked = (intValue == 1) ? true : false;
                    break;

                default:
                    break;

            }
        }
    }
}
