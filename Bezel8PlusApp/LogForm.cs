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
    }
}
