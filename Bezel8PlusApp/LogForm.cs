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
    public partial class LogForm : Form
    {

        private delegate void SafeCallDelegate(object sender, byte[] text);
        private SerialPortManager serialPort = SerialPortManager.Instance;

        public LogForm()
        {
            InitializeComponent();

            serialPort.OnDataReceived += LogReceivedData;
            serialPort.OnDataSent += LogSendingData;
        }

        private void LogReceivedData(object sender, byte[] text)
        {
            if (tbLog.InvokeRequired)
            {
                var d = new SafeCallDelegate(LogReceivedData);
                Invoke(d, new object[] { sender, text });
            }
            else
            {
                PrintLog("Received", text);
            }
        }

        private void LogSendingData(object sender, byte[] text)
        {
            if (tbLog.InvokeRequired)
            {
                var d = new SafeCallDelegate(LogSendingData);
                Invoke(d, new object[] { sender, text });
            }
            else
            {
                PrintLog("Sent", text);
            }
        }

        private void PrintLog(string direction, byte[] message)
        {
            if (!cbShowLog.Checked)
                return;

            string time = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff");

            tbLog.AppendText(time + "  " + direction + ":" + Environment.NewLine);
            tbLog.AppendText(DataHandler.ConvertLoggingMessage(message) + Environment.NewLine + Environment.NewLine);
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            tbLog.Clear();
        }

        private void LoggingForm_VisibleChanged(object sender, EventArgs e)
        {
            tbLog.SelectionStart = tbLog.TextLength;
            tbLog.ScrollToCaret();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tbMessage.Text))
                return;

            try
            {
                btnSend.Enabled = false;
                string message = tbMessage.Text.Trim().Replace("<1A>", Convert.ToChar(0x1A).ToString()).Replace("<1C>", Convert.ToChar(0x1C).ToString());

                if (message.StartsWith("<02>"))
                {
                    Console.WriteLine("1");
                    message = message.Substring(4, message.IndexOf("<03>") - 4);
                    if (Int32.TryParse(tbTimeout.Text, out int timeout) && timeout > 0)
                        serialPort.WriteAndReadMessage(PktType.STX, "", message, out string response, true, timeout);
                    else
                        serialPort.WriteAndReadMessage(PktType.STX, "", message, out string response, false);
                }
                else if (message.StartsWith("<0F>"))
                {
                    Console.WriteLine("2");
                    message = message.Substring(4, message.IndexOf("<0E>") - 4);
                    if (Int32.TryParse(tbTimeout.Text, out int timeout) && timeout > 0)
                        serialPort.WriteAndReadMessage(PktType.SI, "", message, out string response, true, timeout);
                    else
                        serialPort.WriteAndReadMessage(PktType.SI, "", message, out string response, false);
                }
                else
                {
                    // Unknown format
                    throw new FormatException("Format Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            btnSend.Enabled = true;
        }

        private void cbPPSQA_CheckedChanged(object sender, EventArgs e)
        {
            gbPPSQA.Visible = cbPPSQA.Checked;
        }
    }
}
