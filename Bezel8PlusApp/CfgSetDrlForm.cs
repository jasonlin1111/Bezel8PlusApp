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

namespace Bezel8PlusApp
{
    public partial class CfgSetDrlForm : Form
    {
        private OpenFileDialog openFileDialog;
        private Dictionary<string, FileInfo> templateFiles;
        private readonly string templateDirectory = Environment.CurrentDirectory + @"\Config\DRL";

        private SerialPortManager serialPort = SerialPortManager.Instance;

        public CfgSetDrlForm()
        {
            InitializeComponent();
            InitializeDRLTemplate();
            InitializeValue();

            TxnForm.TxnStartEventHandler += DisableAllButtons;
            TxnForm.TxnFinishEventHandler += EnableAllButtons;
        }

        private void DisableAllButtons(object sender, EventArgs e)
        {
            btnSetAll.Enabled = false;
            btnDeleteAll.Enabled = false;
            btnOpen.Enabled = false;
        }

        private void EnableAllButtons(object sender, EventArgs e)
        {
            btnSetAll.Enabled = true;
            btnDeleteAll.Enabled = true;
            btnOpen.Enabled = true;
        }

        private void InitializeDRLTemplate()
        {
            DirectoryInfo dinfo = new DirectoryInfo(templateDirectory);
            FileInfo[] templateFilesInfo = dinfo.GetFiles("*.txt");

            if (templateFiles == null)
                templateFiles = new Dictionary<string, FileInfo>();

            foreach (FileInfo file in templateFilesInfo)
                templateFiles.Add(Path.GetFileNameWithoutExtension(file.Name), file);

            cbbDRLTemplate.DataSource = templateFiles.Keys.ToList();
        }

        private void InitializeValue()
        {
            foreach (TableLayoutPanel tlp in tableLayoutPanelDRLs.Controls)
            {
                foreach (Control crl in tlp.Controls)
                {
                    if (crl is CheckBox)
                    {
                        CheckBox cb = crl as CheckBox;
                        cb.Checked = false;
                        if (!cb.Name.Contains("PID"))
                            cb.Enabled = false;
                    }
                    else if (crl is TextBox)
                    {
                        //Console.WriteLine("TextBox");
                    }
                    else if (crl is ComboBox)
                    {
                        ComboBox cbb = crl as ComboBox;
                        cbb.SelectedIndex = 0;
                    }
                }
                /*
                for (int i = 0; i < tlp.Controls.Count; i++)
                {
                    Console.WriteLine(tlp.Controls[i].Name);
                }
                */
                //Console.WriteLine(tlp.Controls[0].Name);

            }
        }

        private void cbPIDs_CheckedChanged(object sender, EventArgs e)
        {
            if (!(sender is CheckBox))
                return;

            CheckBox cb = sender as CheckBox;
            foreach (Control crl in cb.Parent.Controls)
            {

                if (!cb.Checked)
                {
                    if (!crl.Equals(cb))
                        crl.Enabled = false;  
                }
                else
                {
                    if (crl is CheckBox || crl.Name.StartsWith("tbPID"))
                        crl.Enabled = true;
                }
            }
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!(sender is CheckBox))
                return;

            CheckBox cb = sender as CheckBox;
            if (cb.Name.StartsWith("cbAmount0Check"))
            {
                cb.Parent.Controls[1].Enabled = cb.Checked ? true : false;
            }
            else if (cb.Name.StartsWith("cbRCTLCheck"))
            {
                cb.Parent.Controls[6].Enabled = cb.Checked ? true : false;
            }
            else if (cb.Name.StartsWith("cbCVMCheck"))
            {
                cb.Parent.Controls[4].Enabled = cb.Checked ? true : false;
            }
            else if (cb.Name.StartsWith("cbRCFLCheck"))
            {
                cb.Parent.Controls[2].Enabled = cb.Checked ? true : false;
            }
        }

        private void CheckBox_EnabledChanged(object sender, EventArgs e)
        {
            if (!(sender is CheckBox))
                return;
            CheckBox cb = sender as CheckBox;

            if (!cb.Enabled)
                return;

            if (cb.Name.StartsWith("cbAmount0Check"))
            {
                cb.Parent.Controls[1].Enabled = cb.Checked ? true : false;
            }
            else if (cb.Name.StartsWith("cbRCTLCheck"))
            {
                cb.Parent.Controls[6].Enabled = cb.Checked ? true : false;
            }
            else if (cb.Name.StartsWith("cbCVMCheck"))
            {
                cb.Parent.Controls[4].Enabled = cb.Checked ? true : false;
            }
            else if (cb.Name.StartsWith("cbRCFLCheck"))
            {
                cb.Parent.Controls[2].Enabled = cb.Checked ? true : false;
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            openFileDialog = new OpenFileDialog();
            string sl = String.Empty;
            int drl_index = -1;

            Control crl = null;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                InitializeValue();
                try
                {
                    var sr = new StreamReader(openFileDialog.FileName);
                    while (!sr.EndOfStream)
                    {
                        sl = sr.ReadLine().Trim();

                        switch (sl)
                        {
                            case "#1":
                                drl_index = 0;
                                cbPID1.Checked = true;
                                crl = tableLayoutPanelDRLs.Controls[2];
                                break;
                            case "#2":
                                drl_index = 1;
                                cbPID2.Checked = true;
                                crl = tableLayoutPanelDRLs.Controls[3];
                                break;
                            case "#3":
                                drl_index = 2;
                                cbPID3.Checked = true;
                                crl = tableLayoutPanelDRLs.Controls[1];
                                break;
                            case "#4":
                                drl_index = 3;
                                cbPID4.Checked = true;
                                crl = tableLayoutPanelDRLs.Controls[0];
                                break;
                            default:
                                break;
                        }

                        if (drl_index >= 0 && drl_index < 4 && crl != null)
                        {
                            if (sl.StartsWith("ProgramID"))
                            {
                                TextBox tb = crl.Controls[5] as TextBox;
                                tb.Text = sl.Substring(sl.IndexOf("=") + 1);
                            }
                            else if (sl.StartsWith("StatusCheck"))
                            {
                                if (Int32.TryParse(sl.Substring(sl.IndexOf("=") + 1), out int check))
                                {
                                    CheckBox cb = crl.Controls[3] as CheckBox;
                                    if (check == 1)
                                        cb.Checked = true;
                                }
                            }
                            else if (sl.StartsWith("AmountZeroCheck"))
                            {
                                if (Int32.TryParse(sl.Substring(sl.IndexOf("=") + 1), out int check))
                                {
                                    CheckBox cb = crl.Controls[0] as CheckBox;
                                    if (check == 1)
                                        cb.Checked = true;
                                }
                            }
                            else if (sl.StartsWith("AmountOption"))
                            {
                                if (Int32.TryParse(sl.Substring(sl.IndexOf("=") + 1), out int option))
                                {
                                    ComboBox cbb = crl.Controls[1] as ComboBox;
                                    if (option == 2)
                                        cbb.SelectedIndex = 1;
                                    else
                                        cbb.SelectedIndex = 0;
                                }
                            }
                            else if (sl.StartsWith("RCTLChcek"))
                            {
                                if (Int32.TryParse(sl.Substring(sl.IndexOf("=") + 1), out int check))
                                {
                                    CheckBox cb = crl.Controls[8] as CheckBox;
                                    if (check == 1)
                                        cb.Checked = true;
                                }
                            }
                            else if (sl.StartsWith("RCTL=") || sl.StartsWith("RCTL ="))
                            {
                                TextBox tb = crl.Controls[6] as TextBox;
                                string limitValue = sl.Substring(sl.IndexOf("=") + 1).Trim();
                                if (limitValue.Equals("FFFFFFFFFFFF"))
                                    tb.Text = String.Empty;
                                else
                                    tb.Text = limitValue;
                            }
                            else if (sl.StartsWith("CVMLCheck"))
                            {
                                if (Int32.TryParse(sl.Substring(sl.IndexOf("=") + 1), out int check))
                                {
                                    CheckBox cb = crl.Controls[10] as CheckBox;
                                    if (check == 1)
                                        cb.Checked = true;
                                }
                            }
                            else if (sl.StartsWith("CVML=") || sl.StartsWith("CVML ="))
                            {
                                TextBox tb = crl.Controls[4] as TextBox;
                                string limitValue = sl.Substring(sl.IndexOf("=") + 1).Trim();
                                if (limitValue.Equals("FFFFFFFFFFFF"))
                                    tb.Text = String.Empty;
                                else
                                    tb.Text = limitValue;
                            }
                            else if (sl.StartsWith("RCFLCheck"))
                            {
                                if (Int32.TryParse(sl.Substring(sl.IndexOf("=") + 1), out int check))
                                {
                                    CheckBox cb = crl.Controls[9] as CheckBox;
                                    if (check == 1)
                                        cb.Checked = true;
                                }
                            }
                            else if (sl.StartsWith("RCFL=") || sl.StartsWith("RCFL ="))
                            {
                                TextBox tb = crl.Controls[2] as TextBox;
                                string limitValue = sl.Substring(sl.IndexOf("=") + 1).Trim();
                                if (limitValue.Equals("FFFFFFFFFFFF"))
                                    tb.Text = String.Empty;
                                else
                                    tb.Text = limitValue;
                            }
                        }
                    }
                }
                catch (Exception)
                {

                }
            }
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            string t5hResponse = String.Empty;
            try
            {
                serialPort.WriteAndReadMessage(PktType.STX, "T5H", "", out t5hResponse);
                if (!t5hResponse.ToUpper().Equals("T5I0"))
                    MessageBox.Show(t5hResponse);
                else if (sender.Equals(btnDeleteAll))
                    MessageBox.Show("Delete All DRL sets done.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        private void btnSetAll_Click(object sender, EventArgs e)
        {
            try
            {
                btnDeleteAll_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
                return;
            }


            // T5F message: T5F<SUB>[PID]<SUB>[DO]
            string t5fMessage = String.Empty;
            List<string> t5fMessageList = new List<string>();

            foreach (Control crl in tableLayoutPanelDRLs.Controls)
            {
                t5fMessage = String.Empty;
                CheckBox cbPID = crl.Controls[7] as CheckBox;
                if (!cbPID.Checked)
                    continue;

                // Program ID
                TextBox tbPID = crl.Controls[5] as TextBox;
                if (string.IsNullOrEmpty(tbPID.Text))
                {
                    MessageBox.Show("PID can not be empty");
                    return;
                }
                else
                {
                    t5fMessage += Convert.ToChar(0x1A).ToString() + tbPID.Text;
                }

                // Kernel ID: tag DF810C
                t5fMessage += Convert.ToChar(0x1A).ToString() + "DF810C" + Convert.ToChar(0x1C).ToString() +
                    "2" + Convert.ToChar(0x1C).ToString() + "03";

                // Status Check: tag FFFF8007
                CheckBox cb = crl.Controls[3] as CheckBox;
                string val = cb.Checked ? "01" : "00";
                t5fMessage += Convert.ToChar(0x1A).ToString() + "FFFF8007" + Convert.ToChar(0x1C).ToString() +
                    "2" + Convert.ToChar(0x1C).ToString() + val;

                // Zero Amount Check: tag FFFF8005
                cb = crl.Controls[0] as CheckBox;
                val = cb.Checked ? "01" : "00";
                t5fMessage += Convert.ToChar(0x1A).ToString() + "FFFF8005" + Convert.ToChar(0x1C).ToString() +
                    "2" + Convert.ToChar(0x1C).ToString() + val;

                // Zero Amount Option: tag FFFF8008
                if (cb.Checked)
                {
                    ComboBox cbb = crl.Controls[1] as ComboBox;
                    val = cbb.SelectedIndex == 0 ? "01" : "02";
                    t5fMessage += Convert.ToChar(0x1A).ToString() + "FFFF8008" + Convert.ToChar(0x1C).ToString() +
                    "2" + Convert.ToChar(0x1C).ToString() + val;
                }

                // RCTL Check: tag FFFF8004
                cb = crl.Controls[8] as CheckBox;
                val = cb.Checked ? "00" : "01";
                t5fMessage += Convert.ToChar(0x1A).ToString() + "FFFF8004" + Convert.ToChar(0x1C).ToString() +
                    "2" + Convert.ToChar(0x1C).ToString() + val;

                // RCTL: tag DF8124
                if (cb.Checked)
                {
                    TextBox tb = crl.Controls[6] as TextBox;
                    if (!string.IsNullOrEmpty(tb.Text) && tb.Text.Length == 12)
                    {
                        t5fMessage += Convert.ToChar(0x1A).ToString() + "DF8124" + Convert.ToChar(0x1C).ToString() +
                            "2" + Convert.ToChar(0x1C).ToString() + tb.Text;
                    }
                    else
                    {
                        MessageBox.Show("RCTL length error");
                        return;
                    }
                }

                // CVML Check: tag FFFF8009
                cb = crl.Controls[10] as CheckBox;
                val = cb.Checked ? "01" : "00";
                t5fMessage += Convert.ToChar(0x1A).ToString() + "FFFF8009" + Convert.ToChar(0x1C).ToString() +
                    "2" + Convert.ToChar(0x1C).ToString() + val;

                // CVML: tag DF8126
                if (cb.Checked)
                {
                    TextBox tb = crl.Controls[4] as TextBox;
                    if (!string.IsNullOrEmpty(tb.Text) && tb.Text.Length == 12)
                    {
                        t5fMessage += Convert.ToChar(0x1A).ToString() + "DF8126" + Convert.ToChar(0x1C).ToString() +
                            "2" + Convert.ToChar(0x1C).ToString() + tb.Text;
                    }
                    else
                    {
                        MessageBox.Show("CVML length error");
                        return;
                    }
                }

                // RCFL Check: tag FFFF800A, RCFL: tag DF8123
                cb = crl.Controls[9] as CheckBox;
                TextBox tbRCFL = crl.Controls[2] as TextBox;
                if (!cb.Checked)
                    val = "00";
                else if (string.IsNullOrEmpty(tbRCFL.Text))
                    val = "10";
                else if (tbRCFL.Text.Length == 12)
                    val = "01";
                else
                {
                    MessageBox.Show("RCFL length error");
                    return;
                }

                t5fMessage += Convert.ToChar(0x1A).ToString() + "FFFF800A" + Convert.ToChar(0x1C).ToString() +
                    "2" + Convert.ToChar(0x1C).ToString() + val;

                if (cb.Checked && !string.IsNullOrEmpty(tbRCFL.Text))
                {
                    t5fMessage += Convert.ToChar(0x1A).ToString() + "DF8123" + Convert.ToChar(0x1C).ToString() +
                            "2" + Convert.ToChar(0x1C).ToString() + tbRCFL.Text;
                }

                t5fMessageList.Add(t5fMessage);
            }

            // Send T5F command
            while (t5fMessageList.Count > 0)
            {
                try
                {
                    serialPort.WriteAndReadMessage(PktType.STX, "T5F", t5fMessageList.ElementAt(0), out string t5fResponse);
                    if (!t5fResponse.ToUpper().Equals("T5G0"))
                    {
                        MessageBox.Show(t5fResponse);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                t5fMessageList.RemoveAt(0);
            }
            MessageBox.Show("Set DRL done.");
        }

        private void cbbDRLTemplate_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbbDRLTemplate.SelectedItem == null)
                return;

            InitializeValue();

            if (templateFiles.TryGetValue(cbbDRLTemplate.SelectedItem.ToString(), out FileInfo file))
            {
                int drl_index = -1;
                Control crl = null;
                try
                {
                    var sr = new StreamReader(file.FullName);

                    while (!sr.EndOfStream)
                    {
                        string sl = sr.ReadLine().Trim();
                        if (!string.IsNullOrEmpty(sl))
                        {
                            switch (sl)
                            {
                                case "#1":
                                    drl_index = 0;
                                    cbPID1.Checked = true;
                                    crl = tableLayoutPanelDRLs.Controls[2];
                                    break;
                                case "#2":
                                    drl_index = 1;
                                    cbPID2.Checked = true;
                                    crl = tableLayoutPanelDRLs.Controls[3];
                                    break;
                                case "#3":
                                    drl_index = 2;
                                    cbPID3.Checked = true;
                                    crl = tableLayoutPanelDRLs.Controls[1];
                                    break;
                                case "#4":
                                    drl_index = 3;
                                    cbPID4.Checked = true;
                                    crl = tableLayoutPanelDRLs.Controls[0];
                                    break;
                                default:
                                    break;
                            }

                            if (drl_index >= 0 && drl_index < 4 && crl != null)
                            {
                                if (sl.StartsWith("ProgramID"))
                                {
                                    TextBox tb = crl.Controls[5] as TextBox;
                                    tb.Text = sl.Substring(sl.IndexOf("=") + 1);
                                }
                                else if (sl.StartsWith("StatusCheck"))
                                {
                                    if (Int32.TryParse(sl.Substring(sl.IndexOf("=") + 1), out int check))
                                    {
                                        CheckBox cb = crl.Controls[3] as CheckBox;
                                        if (check == 1)
                                            cb.Checked = true;
                                    }
                                }
                                else if (sl.StartsWith("AmountZeroCheck"))
                                {
                                    if (Int32.TryParse(sl.Substring(sl.IndexOf("=") + 1), out int check))
                                    {
                                        CheckBox cb = crl.Controls[0] as CheckBox;
                                        if (check == 1)
                                            cb.Checked = true;
                                    }
                                }
                                else if (sl.StartsWith("AmountOption"))
                                {
                                    if (Int32.TryParse(sl.Substring(sl.IndexOf("=") + 1), out int option))
                                    {
                                        ComboBox cbb = crl.Controls[1] as ComboBox;
                                        if (option == 2)
                                            cbb.SelectedIndex = 1;
                                        else
                                            cbb.SelectedIndex = 0;
                                    }
                                }
                                else if (sl.StartsWith("RCTLChcek"))
                                {
                                    if (Int32.TryParse(sl.Substring(sl.IndexOf("=") + 1), out int check))
                                    {
                                        CheckBox cb = crl.Controls[8] as CheckBox;
                                        if (check == 1)
                                            cb.Checked = true;
                                    }
                                }
                                else if (sl.StartsWith("RCTL=") || sl.StartsWith("RCTL ="))
                                {
                                    TextBox tb = crl.Controls[6] as TextBox;
                                    string limitValue = sl.Substring(sl.IndexOf("=") + 1).Trim();
                                    if (limitValue.Equals("FFFFFFFFFFFF"))
                                        tb.Text = String.Empty;
                                    else
                                        tb.Text = limitValue;
                                }
                                else if (sl.StartsWith("CVMLCheck"))
                                {
                                    if (Int32.TryParse(sl.Substring(sl.IndexOf("=") + 1), out int check))
                                    {
                                        CheckBox cb = crl.Controls[10] as CheckBox;
                                        if (check == 1)
                                            cb.Checked = true;
                                    }
                                }
                                else if (sl.StartsWith("CVML=") || sl.StartsWith("CVML ="))
                                {
                                    TextBox tb = crl.Controls[4] as TextBox;
                                    string limitValue = sl.Substring(sl.IndexOf("=") + 1).Trim();
                                    if (limitValue.Equals("FFFFFFFFFFFF"))
                                        tb.Text = String.Empty;
                                    else
                                        tb.Text = limitValue;
                                }
                                else if (sl.StartsWith("RCFLCheck"))
                                {
                                    if (Int32.TryParse(sl.Substring(sl.IndexOf("=") + 1), out int check))
                                    {
                                        CheckBox cb = crl.Controls[9] as CheckBox;
                                        if (check == 1)
                                            cb.Checked = true;
                                    }
                                }
                                else if (sl.StartsWith("RCFL=") || sl.StartsWith("RCFL ="))
                                {
                                    TextBox tb = crl.Controls[2] as TextBox;
                                    string limitValue = sl.Substring(sl.IndexOf("=") + 1).Trim();
                                    if (limitValue.Equals("FFFFFFFFFFFF"))
                                        tb.Text = String.Empty;
                                    else
                                        tb.Text = limitValue;
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }

}
