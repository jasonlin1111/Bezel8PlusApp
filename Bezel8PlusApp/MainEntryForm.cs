using System;
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

        private readonly string defaultConfigDirectory = Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.LastIndexOf("bin")) 
            + @"Config\Default_configs\";

        public MainEntryForm()
        {
            InitializeComponent();
            InitializeComponentValue();
            InitializeBtnsAndForms();

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
            dictBtnForm.Add(btnMenu3, new LoggingForm());

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

            serialPort.Open(
            cbCOM.SelectedItem.ToString(),
            Int32.Parse(cbBuadRate.SelectedItem.ToString()),
            Parity.None,
            Int32.Parse(cbDataBits.SelectedItem.ToString()),
            StopBits.One,
            Handshake.None);

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

        private void SetTerminalConfig(string fullName)
        {
            string t51Message = String.Empty;  
            try
            {
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
                            t51Message += Convert.ToChar(0x1A).ToString() + string.Join(Convert.ToChar(0x1C).ToString(), tagFormatValue);
                    }

                }
                serialPort.WriteAndReadMessage(PktType.STX, "T5111", t51Message, out string t51Response);
                if (!t51Response.Equals("T520"))
                    throw new System.FormatException();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SetApplicationConfig(string fullName)
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
            // 1. Date and Time
            try
            {
                SetCurrentTime();
            }
            catch (FormatException)
            {
                // Fail continue setting next part
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            System.Threading.Thread.Sleep(200);

            // 2. Terminal Config
            string fileName = defaultConfigDirectory + "Terminal.txt";
            try
            {
                SetTerminalConfig(fileName);
            }
            catch (FileNotFoundException)
            {
                // Fail, continue setting next part
                //Console.WriteLine("File Not Found");
            }
            catch (FormatException)
            {
                // Fail, continue setting next part
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }



            // 3. Application Config
            DirectoryInfo app_dinfo = new DirectoryInfo(defaultConfigDirectory + "App_config");
            FileInfo[] appFiles = app_dinfo.GetFiles("*.txt");

            foreach (FileInfo appFile in appFiles)
            {
                try
                {
                    System.Threading.Thread.Sleep(200);
                    SetApplicationConfig(appFile.FullName);
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


            // 4. CA Public Keys
            //string capkDirectory = defaultConfigDirectory + @"CAPK\";
            DirectoryInfo capk_dinfo = new DirectoryInfo(defaultConfigDirectory + "CAPK");
            FileInfo[] capkFiles = capk_dinfo.GetFiles("*.txt");

            foreach (FileInfo capkFile in capkFiles)
            {
                try
                {
                    System.Threading.Thread.Sleep(200);
                    SetCAPK(capkFile.FullName);
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

        }

    }
}
