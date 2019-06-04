using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace Bezel8PlusApp
{
    public partial class MainEntryForm : Form
    {
        private SerialPortManager serialPort = SerialPortManager.Instance;

        private Dictionary<Button, Form> dictBtnForm;

        public MainEntryForm()
        {
            InitializeComponent();
            InitializeComponentValue();
            InitializeBtnsAndForms();
        }

        private void InitializeComponentValue()
        {
            cbBuadRate.SelectedIndex = 0;
            cbDataBits.SelectedIndex = 0;
            cbparity.SelectedIndex = 0;
            cbHandShake.SelectedIndex = 0;
            cbStopBits.SelectedIndex = 0;
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
    }
}
