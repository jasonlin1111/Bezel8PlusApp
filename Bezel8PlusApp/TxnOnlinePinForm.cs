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
    public partial class TxnOnlinePinForm : Form
    {
        private string pinText; 

        public TxnOnlinePinForm()
        {
            InitializeComponent();
            pinText = String.Empty;
        }

        public string GetPINBlock()
        {
            string pinLength = pinText.Length.ToString("X2");
            return pinLength + pinText.PadRight(14, 'F');
        }

        public string GetPIN()
        {
            return pinText;
        }

        private void ClearPIN()
        {
            textBoxScreen.Clear();
            pinText = String.Empty;
        }

        private void BtnNunber_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (pinText.Length < 12)
            {
                textBoxScreen.AppendText("*");
                pinText += btn.Text;
            }

            if (pinText.Length >= 4)
                buttonEnter.Enabled = true;

        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearPIN();
            buttonEnter.Enabled = false;
        }

        private void OnlinePinForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            ClearPIN();
            this.Hide();
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void OnlinePinForm_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                ClearPIN();
                buttonEnter.Enabled = false;
            }   
        }
    }
}
