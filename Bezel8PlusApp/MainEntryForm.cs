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

        private TxnForm txnForm;
        private MainConfigForm configForm;

        private List<Form> formList;

        public MainEntryForm()
        {
            InitializeComponent();
            InitializeComponentValue();
            InitializeForms();
        }

        private void InitializeComponentValue()
        {
            cbBuadRate.SelectedIndex = 0;
            cbDataBits.SelectedIndex = 0;
            cbparity.SelectedIndex = 0;
            cbHandShake.SelectedIndex = 0;
            cbStopBits.SelectedIndex = 0;
        }

        private void InitializeForms()
        {
            formList = new List<Form>();

            txnForm = new TxnForm();
            configForm = new MainConfigForm();

            formList.Add(txnForm);
            formList.Add(configForm);

            foreach (Form form in formList)
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
            if (cbCOM.SelectedIndex == -1)
                return;

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

        private void btnMenuTxn_Click(object sender, EventArgs e)
        {
            foreach (Form form in formList)
            {
                form.Visible = false;
            }
            txnForm.Visible = true;
        }

        private void btnMenuConfig_Click(object sender, EventArgs e)
        {

            foreach (Form form in formList)
            {
                form.Visible = false;
            }
            configForm.Visible = true;
        }
    }
}
