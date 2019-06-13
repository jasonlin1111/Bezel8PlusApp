using System;
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
    public partial class CapkForm : Form
    {
        private SerialPortManager serialPort = SerialPortManager.Instance;
        private FolderBrowserDialog folderBrowserDialog;
        private DataSet capkDataSet;

        public CapkForm()
        {
            InitializeComponent();
            capkDataSet = new DataSet();
        }

        private void SetupCapkToReader(DataTable capkTable)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            foreach (DataRow row in capkTable.Rows)
            {
                string key = row["Item"].ToString().ToUpper();
                if (!dictionary.ContainsKey(key))
                {
                    dictionary.Add(key, row["Value"].ToString());
                }
            }

            // Build 1st message
            string body = String.Empty;
            string value = String.Empty;
            if (dictionary.TryGetValue("RID", out value))
                body += value;
            else
                throw new System.Exception("No RID");

            if (dictionary.TryGetValue("PKI", out value))
                body += value;
            else
                throw new System.Exception("No PKI");

            if (dictionary.TryGetValue("HashAlgorithm".ToUpper(), out value))
                body += value;
            else
                throw new System.Exception("No HashAlgorithm");

            if (dictionary.TryGetValue("HashValue".ToUpper(), out value))
                body += value;
            else
                throw new System.Exception("No HashValue");

            if (dictionary.TryGetValue("PKAlgorithm".ToUpper(), out value))
                body += value;
            else
                throw new System.Exception("No PKAlgorithm");

            if (dictionary.TryGetValue("PKLen".ToUpper(), out value))
                body += value;
            else
                throw new System.Exception("No PKLen");

            if (dictionary.TryGetValue("PKExp".ToUpper(), out value))
            {
                if (value.Equals("03"))
                    body += "1";
                else if (value.Equals("010001"))
                    body += "2";
                else
                    throw new System.Exception("Unknown Public Exponent");
            }
            else
                throw new System.Exception("No PKExp");

            string t53response = String.Empty;
            try
            {
                serialPort.WriteAndReadMessage(PktType.STX, "T531", body, out t53response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            if (t53response.IndexOf("T5410", StringComparison.OrdinalIgnoreCase) < 0)
            {
                throw new System.Exception($"Error Message:\n\n{t53response}");
            }

            System.Threading.Thread.Sleep(200);
            // Send 2nd message
            body = String.Empty;
            if (dictionary.TryGetValue("PKModulus".ToUpper(), out value))
                body += value;
            else
                throw new System.Exception("No PKModulus");

            t53response = String.Empty;
            try
            {
                serialPort.WriteAndReadMessage(PktType.STX, "T532", body, out t53response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            if (t53response.IndexOf("T5420", StringComparison.OrdinalIgnoreCase) < 0)
            {
                throw new System.Exception($"Error Message:\n\n{t53response}");
            }

        }

        private DataTable BuildDataTableFromFile(FileInfo capkFile)
        {
            DataTable table = new DataTable(Path.GetFileNameWithoutExtension(capkFile.Name));
            DataColumn colItem = new DataColumn("Item", Type.GetType("System.String"));
            colItem.ReadOnly = true;
            DataColumn colValue = new DataColumn("Value", Type.GetType("System.String"));

            table.Columns.Add(colItem);
            table.Columns.Add(colValue);

            try
            {
                var sr = new StreamReader(capkFile.FullName);

                while (!sr.EndOfStream)
                {
                    string sl = sr.ReadLine();
                    if (!string.IsNullOrEmpty(sl))
                    {
                        string[] cols = sl.Split(' ');
                        if (cols.Length == 2)
                        {
                            DataRow dataRow = table.NewRow();
                            dataRow["Item"] = cols[0];
                            dataRow["Value"] = cols[1];
                            table.Rows.Add(dataRow);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return table;
        }

        private void btnOpenCAPK_Click(object sender, EventArgs e)
        {
            folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.SelectedPath = System.Environment.CurrentDirectory;
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                capkDataSet.Tables.Clear();
                listBoxCAPK.Items.Clear();
                string folderPath = folderBrowserDialog.SelectedPath;
                DirectoryInfo dinfo = new DirectoryInfo(folderPath);
                FileInfo[] Files = dinfo.GetFiles("*.txt");

                foreach (FileInfo file in Files)
                {
                    DataTable table = BuildDataTableFromFile(file);
                    capkDataSet.Tables.Add(table);
                    listBoxCAPK.Items.Add(table.TableName);
                }

                if (listBoxCAPK.Items.Count > 0)
                {
                    listBoxCAPK.SelectedIndex = 0;
                }

            }

        } 

        private void btnSetAll_Click(object sender, EventArgs e)
        {

            if (capkDataSet.Tables.Count > 0)
            {
                tbStatus.Text = "";
                foreach (DataTable capkTable in capkDataSet.Tables)
                {
                    System.Threading.Thread.Sleep(300);
                    try
                    {
                        tbStatus.AppendText($"Setup {capkTable.TableName} ... ");
                        SetupCapkToReader(capkTable);
                        tbStatus.AppendText($"Done." + Environment.NewLine);
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show(ex.Message);
                        tbStatus.AppendText($"Failed - {ex.Message}" + Environment.NewLine);
                        continue;
                    }
                }
            }
        }

        private void btnGetAll_Click(object sender, EventArgs e)
        {

            // <02>T591<03>[LRC]
            string t59response = String.Empty;
            listBoxReaderCAPK.Items.Clear();
            try
            {
                serialPort.WriteAndReadMessage(PktType.STX, "T59", "1", out t59response);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            if (t59response.ToUpper().Equals("T5A11"))
            {
                listBoxReaderCAPK.Items.Clear();
                MessageBox.Show("No CA keys in the Reader");  
                return;
            }

            if (t59response.ToUpper().StartsWith("T5A10") ||
                t59response.ToUpper().StartsWith("T5A13"))
            {
                Console.WriteLine(t59response);
                if (t59response.Length <= 6)
                    return;
                t59response = t59response.Substring(6);
                string[] keys = t59response.Split(Convert.ToChar(0x1C));

                foreach(string key in keys)
                {
                    listBoxReaderCAPK.Items.Add(key);
                }
            }
            else
            {
                MessageBox.Show("Error Message:\n\n {0}", t59response);
            }
        }

        private void listBoxReaderCAPK_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBoxCAPK_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxCAPK.SelectedItem == null)
            {
                dataGridViewCAPK.DataSource = null;
                return;
            }
            string tableName = listBoxCAPK.SelectedItem.ToString();
            if (capkDataSet.Tables.Contains(tableName))
            {
                int tableIndex = capkDataSet.Tables.IndexOf(tableName);
                dataGridViewCAPK.DataSource = capkDataSet.Tables[tableIndex];
                dataGridViewCAPK.AutoResizeColumns();
            }
        }

        private string[] DeleteCAPK(string[] keys)
        {
            string[] results = null;
            if (keys == null)
                return results;

            string keyIDs = Convert.ToChar(0x1A).ToString() + String.Join(Convert.ToChar(0x1C).ToString(), keys);

            string response = String.Empty;
            try
            {
                serialPort.WriteAndReadMessage(PktType.STX, "T5B1", keyIDs, out response);
                if (response.ToUpper().StartsWith("T5C10"))
                {
                    results = response.Substring(6).Split(Convert.ToChar(0x1C));
                }
                else
                {
                    throw new System.Exception(response);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return results;
        }

        private void btnRemoveOne_Click(object sender, EventArgs e)
        {
            if (listBoxReaderCAPK.SelectedItem != null)
            {
                string[] key = new string[1] { listBoxReaderCAPK.SelectedItem.ToString() };
                string[] result = null;
                try
                {
                    result = DeleteCAPK(key);
                    if (result != null)
                    {
                        if (result[0] == "0")
                        {
                            // Delete CAPK sucess
                            listBoxReaderCAPK.Items.Remove(listBoxReaderCAPK.SelectedItem);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            if (listBoxReaderCAPK.Items.Count == 0)
                return;
            /*
            string keys = Convert.ToChar(0x1A).ToString() + String.Join(Convert.ToChar(0x1C).ToString(), listBoxReaderCAPK.Items);
            string response = String.Empty;
            string[] results;
            try
            {
                serialPort.WriteAndReadMessage(PktType.STX, "T5B1", keys, out response);
                if (response.ToUpper().StartsWith("T5C10"))
                {
                    results = response.Substring(6).Split(Convert.ToChar(0x1C));
                    int idx = 0;
                    foreach (string key in listBoxReaderCAPK.Items)
                    {

                    }
                }
                else
                {
                    throw new System.Exception(response);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            */

        }
    }
}
