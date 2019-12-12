﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;

namespace Bezel8PlusApp
{
    public partial class MainEntryForm : Form
    {
        private SerialPortManager serialPort = SerialPortManager.Instance;

        private Dictionary<Button, Form> dictBtnForm;

        private readonly string defaultConfigDirectory = Environment.CurrentDirectory + @"\Config\Default_configs\";

        public MainEntryForm(string version = "")
        {
            InitializeComponent();
            InitializeComponentValue();
            InitializeBtnsAndForms();
            if (!String.IsNullOrEmpty(version))
            {
                this.Text = "B8p payWave SDK v" + version;
            }

            TxnForm.TxnStartEventHandler += TxnInProgress;
            TxnForm.TxnFinishEventHandler += OnIdleState;

        }

        private void TxnInProgress(object sender, EventArgs e)
        {
            btnDefaultSetting.Enabled = false;
        }

        private void OnIdleState(object sender, EventArgs e)
        {
            btnDefaultSetting.Enabled = true;
        }

        private void InitializeComponentValue()
        {
            cbBuadRate.DataSource = new int[] { 9600, 19200, 38400, 57600, 115200 };
            cbDataBits.DataSource = new int[] { 8 };
            cbparity.DataSource = new string[] { "None" };
            cbHandShake.DataSource = new string[] { "None" };
            cbStopBits.DataSource = new int[] { 1 };
        }

        private void InitializeBtnsAndForms()
        {
            dictBtnForm = new Dictionary<Button, Form>();
            dictBtnForm.Add(btnMenuConfig, new MainConfigForm());
            dictBtnForm.Add(btnMenuTxn, new TxnForm());
            dictBtnForm.Add(btnMenuLog, new LogForm());
            dictBtnForm.Add(btnMenuTool, new MainToolForm());

            foreach (Form form in dictBtnForm.Values)
            {
                form.TopLevel = false;
                form.Visible = false;
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Fill;

                groupBoxWorkspace.Controls.Add(form);
            }
        }

        private void cbCOM_Click(object sender, EventArgs e)
        {
            cbCOM.Items.Clear();
            foreach (string port in SerialPort.GetPortNames())
            {
                cbCOM.Items.Add(port);
            }
        }

        private void btnOpenCom_Click(object sender, EventArgs e)
        {

            if (cbCOM.SelectedItem == null)
            {
                MessageBox.Show("Invalid Port");
                return;
            }
            try
            {
                serialPort.Open(cbCOM.SelectedItem.ToString(),
                    Int32.Parse(cbBuadRate.SelectedItem.ToString()),
                    Parity.None,
                    Int32.Parse(cbDataBits.SelectedItem.ToString()),
                    StopBits.One,
                    Handshake.None);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (serialPort.IsOpen)
            {
                btnOpenCom.Enabled = false;
                btnCloseCom.Enabled = true;
                tableLayoutPanelComSetting.Enabled = false;
            }
            
        }

        private void btnCloseCom_Click(object sender, EventArgs e)
        {
            serialPort.Close();

            if (!serialPort.IsOpen)
            {
                btnOpenCom.Enabled = true;
                btnCloseCom.Enabled = false;
                tableLayoutPanelComSetting.Enabled = true;
            }
        }
        
        private void MenuButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            foreach (Form form in dictBtnForm.Values)
            {
                form.Visible = false;
            }

            Form targetForm;
            if (dictBtnForm.TryGetValue(btn, out targetForm))
            {
                targetForm.Visible = true;
            }
        }

        private void SetCurrentTime()
        {
            string datetime = DateTime.Now.ToString("yyyyMMdd") + ((int)DateTime.Now.DayOfWeek).ToString() + DateTime.Now.ToString("HHmmss");
            try
            {
                serialPort.WriteAndReadMessage(PktType.SI, "18", datetime, out string response);
                if (!response.Equals("180"))
                    throw new System.FormatException();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SetTerminalConfig(ConfigType type, string fullName)
        {
            string message_body = String.Empty;
            string message_head = (type == ConfigType.ICC) ? "T01" : "T51";
            try
            {
                var sr = new StreamReader(fullName);

                while (!sr.EndOfStream)
                {
                    string sl = sr.ReadLine();

                    if (!string.IsNullOrEmpty(sl))
                    {
                        if (sl.ToUpper().StartsWith("NOTE"))
                        {
                            break;
                        }     

                        // Description string handling
                        string description = String.Empty;
                        if (sl.Contains("//"))
                        {
                            int descripePosition = sl.IndexOf("//");
                            description = sl.Substring(descripePosition + 2).Trim();
                            sl = sl.Substring(0, descripePosition);
                        }

                        // Tag Format Value string handling
                        string[] tagFormatValue = sl.Trim().Split(' ');
                        if (tagFormatValue.Length == 3)
                            message_body += Convert.ToChar(0x1A).ToString() + string.Join(Convert.ToChar(0x1C).ToString(), tagFormatValue);
                    }

                }
                serialPort.WriteAndReadMessage(PktType.STX, message_head + "11", message_body, out string t51Response);
                if (!t51Response.Equals("T520") && !t51Response.Equals("T020"))
                    throw new System.FormatException();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SetPCDApplicationConfig(string fullName)
        {
            string s1A = Convert.ToChar(0x1A).ToString();
            string s1C = Convert.ToChar(0x1C).ToString();
            try
            {
                string t55Message = String.Empty;
                string txnType = String.Empty;
                string kid = String.Empty;
                string aid = String.Empty;

                var sr = new StreamReader(fullName);

                while (!sr.EndOfStream)
                {
                    string sl = sr.ReadLine();
                    if (!string.IsNullOrEmpty(sl))
                    {
                        // Description string handling
                        string description = String.Empty;
                        if (sl.Contains("//"))
                        {
                            int descripePosition = sl.IndexOf("//");
                            description = sl.Substring(descripePosition + 2).Trim();
                            sl = sl.Substring(0, descripePosition);
                        }

                        // Tag Format Value string handling
                        string[] tagFormatValue = sl.Trim().Split(' ');
                        if (tagFormatValue.Length == 3)
                        {
                            if (tagFormatValue[0].ToUpper().Equals("9C"))
                                txnType = tagFormatValue[2];
                            else if (tagFormatValue[0].ToUpper().Equals("DF810C"))
                                kid = tagFormatValue[2];
                            else if (tagFormatValue[0].ToUpper().Equals("9F06"))
                                aid = tagFormatValue[2];

                            t55Message += s1A + string.Join(s1C, tagFormatValue);
                        }                       
                    }
                }

                if (string.IsNullOrEmpty(txnType) || string.IsNullOrEmpty(kid) || string.IsNullOrEmpty(aid))
                    throw new System.FormatException();

                t55Message = s1A + txnType + s1A + kid + s1A + aid + t55Message;

                serialPort.WriteAndReadMessage(PktType.STX, "T5511", t55Message, out string t55Response);
                if (!t55Response.Equals("T560"))
                    throw new System.FormatException();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SetICCApplicationConfig(string fullName, int buffer_len = -1)
        {
            string s1A = Convert.ToChar(0x1A).ToString();
            string s1C = Convert.ToChar(0x1C).ToString();

            if (buffer_len < 0)
                buffer_len = serialPort.GetWriteBufferSize();

            int max_body_length = buffer_len - 25;
            List<string> message_body_list = new List<string>();

            try
            {
                string aid = String.Empty;
                string message_body = String.Empty;

                var sr = new StreamReader(fullName);


                while (!sr.EndOfStream)
                {
                    string sl = sr.ReadLine();

                    if (sl.ToUpper().StartsWith("NOTE"))
                        break;

                    // Description string handling
                    string description = String.Empty;
                    if (sl.Contains("//"))
                    {
                        int descripePosition = sl.IndexOf("//");
                        description = sl.Substring(descripePosition + 2).Trim();
                        sl = sl.Substring(0, descripePosition);
                    }

                    // Tag Format Value string handling
                    string[] tagFormatValue = sl.Trim().Split(' ');
                    if (tagFormatValue.Length == 3)
                    {
                        if (tagFormatValue[0].ToUpper().Equals("9F06"))
                            aid = tagFormatValue[2];

                        tagFormatValue[1] = DataHandler.UICFormatConvertor(tagFormatValue[1]).ToString();
                        string data_object = string.Join(s1C, tagFormatValue);
                        if ((message_body.Length + data_object.Length) > max_body_length)
                        {
                            message_body_list.Add(message_body);
                            message_body = String.Empty;
                        }
                        message_body += s1A + data_object;
                    }
                }
                message_body_list.Add(message_body);


                if (string.IsNullOrEmpty(aid))
                    throw new System.FormatException("Missing AID 9F06");

                int current_pkg = 1;
                int total_pkg = message_body_list.Count;
                while (current_pkg <= total_pkg)
                {
                    string pre_fix = current_pkg == 1 ? (s1A + aid) : "";

                    serialPort.WriteAndReadMessage(PktType.STX, "T05" + current_pkg.ToString() + total_pkg.ToString(),
                        pre_fix + message_body_list[current_pkg - 1], out string response);
                    if (!response.Equals("T060"))
                        throw new System.FormatException();

                    current_pkg += 1;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void SetCAPK(string fileName)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            try
            {
                var sr = new StreamReader(fileName);
                while (!sr.EndOfStream)
                {
                    string sl = sr.ReadLine();

                    if (!string.IsNullOrEmpty(sl))
                    {
                        string[] data = sl.Trim().Split(' ');
                        if (data.Length == 2)
                            dictionary.Add(data[0], data[1]);
                    }

                }

                // Building 1st message
                string body = String.Empty;
                string value = String.Empty;
                if (dictionary.TryGetValue("RID", out value))
                    body += value;
                else
                    throw new System.FormatException("No RID");

                if (dictionary.TryGetValue("PKI", out value))
                    body += value;
                else
                    throw new System.FormatException("No PKI");

                if (dictionary.TryGetValue("HashAlgorithm", out value))
                    body += value;
                else
                    throw new System.FormatException("No HashAlgorithm");

                if (dictionary.TryGetValue("HashValue", out value))
                    body += value;
                else
                    throw new System.FormatException("No HashValue");

                if (dictionary.TryGetValue("PKAlgorithm", out value))
                    body += value;
                else
                    throw new System.FormatException("No PKAlgorithm");

                if (dictionary.TryGetValue("PKLen", out value))
                    body += value;
                else
                    throw new System.FormatException("No PKLen");

                if (dictionary.TryGetValue("PKExp", out value))
                {
                    if (value.Equals("03"))
                        body += "1";
                    else if (value.Equals("010001"))
                        body += "2";
                    else
                        throw new System.FormatException("Unknown Public Exponent");
                }
                else
                    throw new System.FormatException("No PKExp");

                string t53response = String.Empty;
                // Sending 1st message
                serialPort.WriteAndReadMessage(PktType.STX, "T531", body, out t53response);
                if (!t53response.Equals("T5410"))
                    throw new System.FormatException();


                System.Threading.Thread.Sleep(200);
                // Building 2nd message
                body = String.Empty;
                if (dictionary.TryGetValue("PKModulus", out value))
                    body += value;
                else
                    throw new System.FormatException("No PKModulus");

                // Sending 2nd message
                t53response = String.Empty;
                serialPort.WriteAndReadMessage(PktType.STX, "T532", body, out t53response);
                if (!t53response.Equals("T5420"))
                    throw new System.FormatException();

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void btnDefaultSetting_Click(object sender, EventArgs e)
        {

            DirectoryInfo icc_app_dinfo = new DirectoryInfo(defaultConfigDirectory + @"ICC/App_config/");
            FileInfo[] icc_appFiles = icc_app_dinfo.GetFiles("*.txt");

            DirectoryInfo pcd_app_dinfo = new DirectoryInfo(defaultConfigDirectory + @"PCD/App_config");
            FileInfo[] pcd_appFiles = pcd_app_dinfo.GetFiles("*.txt");

            DirectoryInfo capk_dinfo = new DirectoryInfo(defaultConfigDirectory + @"PCD/CAPK");
            FileInfo[] capkFiles = capk_dinfo.GetFiles("*.txt");

            int loading = 3 + icc_appFiles.Length + pcd_appFiles.Length + capkFiles.Length;
            ProgressBarForm pgf = new ProgressBarForm(loading);

            // 1. Date and Time
            pgf.AppendText("Setting current date and time ...");
            try
            {
                SetCurrentTime();
                pgf.AppendText("Done." + Environment.NewLine);
            }
            catch (FormatException)
            {
                // Fail continue setting next part
                pgf.AppendText("Failed." + Environment.NewLine);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                pgf.Close();
                return;
            }
            pgf.IncreaseValue(1);


            System.Threading.Thread.Sleep(100);

            // 2. Terminal Config
            pgf.AppendText("Setting default Terminal configs ...");
            try
            {
                string fileName = defaultConfigDirectory + @"PCD/PCD_Terminal.txt";
                SetTerminalConfig(ConfigType.PCD, fileName);
                pgf.IncreaseValue(1);

                fileName = defaultConfigDirectory + @"ICC/ICC_Terminal.txt";
                SetTerminalConfig(ConfigType.ICC, fileName);
                pgf.IncreaseValue(1);

                pgf.AppendText("Done" + Environment.NewLine);
            }
            catch (FileNotFoundException)
            {
                // Fail, continue setting next part
                pgf.AppendText("Failed" + Environment.NewLine);
                pgf.IncreaseValue(2);
            }
            catch (FormatException)
            {
                // Fail, continue setting next part
                pgf.AppendText("Failed" + Environment.NewLine);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                pgf.Close();
                return;
            }   
            

            // 3-1. ICC Application Config
            pgf.AppendText("Setting default ICC Application configs ...");
            foreach (FileInfo appFile in icc_appFiles)
            {
                try
                {
                    System.Threading.Thread.Sleep(100);
                    SetICCApplicationConfig(appFile.FullName);
                    pgf.IncreaseValue(1);
                }
                catch (FileNotFoundException)
                {
                    continue;
                }
                catch (FormatException)
                {
                    continue;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            pgf.AppendText("Done" + Environment.NewLine);
            


            // 3. PCD Application Config
            pgf.AppendText("Setting default PCD Application config ...");
            foreach (FileInfo appFile in pcd_appFiles)
            {
                try
                {
                    System.Threading.Thread.Sleep(100);
                    SetPCDApplicationConfig(appFile.FullName);
                    pgf.IncreaseValue(1);
                }
                catch (FileNotFoundException)
                {
                    continue;
                }
                catch (FormatException)
                {
                    continue;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            pgf.AppendText("Done" + Environment.NewLine);
            


            // 4. CA Public Keys
            pgf.AppendText("Setting default CA Public keys ...");
            foreach (FileInfo capkFile in capkFiles)
            {
                try
                {
                    System.Threading.Thread.Sleep(100);
                    SetCAPK(capkFile.FullName);
                    pgf.IncreaseValue(1);
                }
                catch (FileNotFoundException)
                {
                    continue;
                }
                catch (FormatException)
                {
                    continue;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }

            }
            pgf.AppendText("Done" + Environment.NewLine);
            
            if (pgf != null)
                pgf.Close();

        }
    }
}
