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
    public partial class TimeSettingForm : Form
    {
        private SerialPortManager serialPort = SerialPortManager.Instance;

        public TimeSettingForm()
        {
            InitializeComponent();
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

        private void cbbCardType_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbPAN.Text = String.Empty;

            if (cbbCardType.SelectedIndex == 1)
            {
                tbPAN.Text += "4761739001010010";
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
