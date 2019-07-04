using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security;
using System.Diagnostics;
using System.IO;

namespace Bezel8PlusApp
{
    public partial class TerAppConfigForm : Form
    {
        
        private SerialPortManager serialPort = SerialPortManager.Instance;
        private OpenFileDialog openFileDialog;
        private DataSet confDataSet;

        public Dictionary<string, string> formatTable = new Dictionary<string, string>();

        public TerAppConfigForm()
        {
            InitializeComponent();
            BuildFormatTable();

            confDataSet = new DataSet();

            TxnForm.TxnStartEventHandler += DisableAllButtons;
            TxnForm.TxnFinishEventHandler += EnableAllButtons;
        }

        private void DisableAllButtons(object sender, EventArgs e)
        {
            btnOpen.Enabled = false;
            btnSetSelected.Enabled = false;
            btnSetAll.Enabled = false;
            btnGetAll.Enabled = false;
            btnAddItem.Enabled = false;
            btnDeleteItem.Enabled = false;
            btnRemoveOne.Enabled = false;
        }

        private void EnableAllButtons(object sender, EventArgs e)
        {
            btnOpen.Enabled = true;
            btnSetSelected.Enabled = true;
            btnSetAll.Enabled = true;
            btnGetAll.Enabled = true;
            btnAddItem.Enabled = true;
            btnDeleteItem.Enabled = true;
            btnRemoveOne.Enabled = true;
        }


        private void BuildFormatTable()
        {
            formatTable["a"] = "1";
            formatTable["b"] = "2";
            formatTable["an"] = "3";
            formatTable["ans"] = "4";
            formatTable["cn"] = "5";
            formatTable["n"] = "6";
            formatTable["var"] = "7";
        }

        private void DemonstrateDataView()
        {
            DataTable table = new DataTable("table");
            DataColumn colDescrip = new DataColumn("Description", Type.GetType("System.String"));
            DataColumn colTag = new DataColumn("Tag", Type.GetType("System.String"));
            DataColumn colFormat = new DataColumn("Format", Type.GetType("System.String"));
            DataColumn colValue = new DataColumn("Value", Type.GetType("System.String"));

            table.Columns.Add(colDescrip);
            table.Columns.Add(colTag);
            table.Columns.Add(colFormat);
            table.Columns.Add(colValue);

        }

        private DataTable InitializeDataTable(string tableName)
        {

            DataTable table = new DataTable(tableName);

            DataColumn colDescrip = new DataColumn("Description", Type.GetType("System.String"));



            DataColumn colTag = new DataColumn("Tag", Type.GetType("System.String"));
            DataColumn colFormat = new DataColumn("Format", Type.GetType("System.String"));
            DataColumn colValue = new DataColumn("Value", Type.GetType("System.String"));

            table.Columns.Add(colDescrip);
            table.Columns.Add(colTag);
            table.Columns.Add(colFormat);
            table.Columns.Add(colValue);

            return table;
        }

        private int LoadConfigFileToDataSetView(string filename, string path)
        {
            try
            {
                var sr = new StreamReader(path + filename);
                DataTable table = InitializeDataTable(Path.GetFileNameWithoutExtension(filename));

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
                            //Console.WriteLine(sl);
                            //Console.WriteLine(description);

                            sl = sl.Substring(0, descripePosition);
                            //Console.WriteLine(sl);
                        }

                        // Tag Format Value string handling
                        string[] tagFormatValue = sl.Trim().Split(' ');
                        //Console.WriteLine("tagFormatValue size = {0}", tagFormatValue.Length);
                        if (tagFormatValue.Length == 3)
                        {
                            DataRow dataRow = table.NewRow();
                            dataRow["Tag"] = tagFormatValue[0];
                            dataRow["Format"] = tagFormatValue[1];
                            dataRow["Value"] = tagFormatValue[2];

                            if (!string.IsNullOrEmpty(description))
                            {
                                dataRow["Description"] = description;
                            }
                            table.Rows.Add(dataRow);
                        }
                    }
                }
                confDataSet.Tables.Add(table);
            }
            catch (FileNotFoundException)
            {
                throw new System.IO.FileNotFoundException("File: {0} Not Found.", filename);
            }
            

            return 0;
        }

        private void BuildConfigDataSet(string fileName)
        {

            try
            {
                var sr = new StreamReader(fileName);
                DataTable table = InitializeDataTable(Path.GetFileNameWithoutExtension(fileName));

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
                            DataRow dataRow = table.NewRow();
                            dataRow["Tag"] = tagFormatValue[0];
                            dataRow["Format"] = tagFormatValue[1];
                            dataRow["Value"] = tagFormatValue[2];

                            if (!string.IsNullOrEmpty(description))
                            {
                                dataRow["Description"] = description;
                            }
                            table.Rows.Add(dataRow);
                        }
                    }

                }
                confDataSet.Tables.Add(table);
                listBoxConfig.Items.Add(table.TableName);
            }
            catch (FileNotFoundException)
            {
                throw new System.IO.FileNotFoundException("File: {0} Not Found.", fileName);
            }

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "dat files (*.dat)|*.dat|All files (*.*)|*.*";
            string path = String.Empty;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                listBoxConfig.Items.Clear();
                confDataSet.Tables.Clear();
                path = Path.GetDirectoryName(openFileDialog.FileName) + @"\";
                try
                {
                    var sr = new StreamReader(openFileDialog.FileName);
                    while (!sr.EndOfStream)
                    {
                        string configFileName = sr.ReadLine().Trim();
                        if (!configFileName.Contains(".txt"))
                            configFileName += ".txt";
                        if (!string.IsNullOrEmpty(configFileName) &&
                            File.Exists(path + configFileName))
                        {
                            BuildConfigDataSet(path + configFileName);
                        }
                    }
                    if (listBoxConfig.Items.Count > 0)
                    {
                        listBoxConfig.SelectedIndex = 0;
                    }
                }
                catch (FileNotFoundException)
                {

                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }

        private void listBoxConfig_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxConfig.SelectedItem == null)
            {
                dataGridView1.DataSource = null;
                return;
            }
            string configName = listBoxConfig.SelectedItem.ToString();
            if (confDataSet.Tables.Contains(configName))
            {
                int tableIndex = confDataSet.Tables.IndexOf(configName);
                dataGridView1.DataSource = confDataSet.Tables[tableIndex];
                dataGridView1.AutoResizeColumns();
            }
            //dataGridView1.DataSource = confDataSet.Tables[listBoxConfig.SelectedIndex];
            //dataGridView1.AutoResizeColumns();
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            openFileDialog = new OpenFileDialog();
            //openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    BuildConfigDataSet(openFileDialog.FileName);
                }
                catch (DuplicateNameException)
                {
                    MessageBox.Show($"{openFileDialog.FileName} \n\n\talready exists");
                }
            }

            // Refresh list box
            if (listBoxConfig.Items.Count > 0)
            {
                listBoxConfig.SelectedIndex = listBoxConfig.Items.Count - 1;
            }
        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            if (listBoxConfig.SelectedItem == null) return;

            string configName = listBoxConfig.SelectedItem.ToString();

            if (confDataSet.Tables.Contains(configName))
            {
                confDataSet.Tables.Remove(configName);
            }

            listBoxConfig.Items.Remove(listBoxConfig.SelectedItem);
            listBoxConfig.SelectedIndex = -1;
        }

        private void btnSetSelected_Click(object sender, EventArgs e)
        {
            if (listBoxConfig.SelectedItem == null) return;

            string configName = listBoxConfig.SelectedItem.ToString();
            SetupConfigToReader(configName);
        }

        private void btnSetAll_Click(object sender, EventArgs e)
        {

            // Delete all configs first
            string t5bresponse = String.Empty;
            try
            {
                serialPort.WriteAndReadMessage(PktType.STX, "T5B", "3", out t5bresponse);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
                return;
            }

            if (t5bresponse.IndexOf("T5C30", StringComparison.OrdinalIgnoreCase) < 0)
            {
                MessageBox.Show($"\tDelete config failed\t\n\n\t{t5bresponse}");
                return;
            }

            System.Threading.Thread.Sleep(300);

            // Setting config one by one
            int count = confDataSet.Tables.Count;
            listBoxConfig.Enabled = false;
            tbStatus.Clear();
            foreach (string config in listBoxConfig.Items)
            {
                SetupConfigToReader(config);
                System.Threading.Thread.Sleep(300);
            }
            listBoxConfig.Enabled = true;
        }

        private void SetupConfigToReader(string configName)
        {
            if (!confDataSet.Tables.Contains(configName))
                return;

            // 1st package need to specify [TxnType]<1A>[KID]<1A>[AID] at the beginning
            string[] first3Elements = new string[3];

            List<string> dataObjectList = new List<string>();

            int idx = confDataSet.Tables.IndexOf(configName);
            foreach (DataRow row in confDataSet.Tables[idx].Rows)
            {

                // Check TxnType, KID and AID
                if (row.ItemArray[1].ToString().ToUpper().Equals("9C"))
                {
                    first3Elements[0] = row.ItemArray[3].ToString();
                }
                else if (row.ItemArray[1].ToString().ToUpper().Equals("DF810C"))
                {
                    first3Elements[1] = row.ItemArray[3].ToString();
                }
                else if (row.ItemArray[1].ToString().ToUpper().Equals("9F06"))
                {
                    first3Elements[2] = row.ItemArray[3].ToString();
                }

                string format;
                if (!formatTable.TryGetValue(row.ItemArray[2].ToString().ToLower(), out format))
                {
                    format = row.ItemArray[2].ToString();
                }
                string dataObject =
                    row.ItemArray[1].ToString() + Convert.ToChar(0x1C).ToString() +
                    format + Convert.ToChar(0x1C).ToString() +
                    row.ItemArray[3].ToString();

                //Console.WriteLine(dataObject.Length);
                dataObjectList.Add(dataObject);
            }

            string head = String.Empty;
            if (configName.IndexOf("terminal", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                // Terminal config, use T51
                head = "T51";
            }
            else
            {
                // Application config, use T55
                head = "T55";

                // Check [TxnType]<1A>[KID]<1A>[AID]
                for (int i = 0; i < first3Elements.Length; i++)
                {
                    if (first3Elements[i] == null)
                    {
                        MessageBox.Show($"Data {i} missing in {configName}");
                        return;
                    }
                }
            }

            // Counting the number of total packages
            //[prefixX][T][5][X][n][total]...(body)...[suffix][LRC]
            int body_length = serialPort.GetWriteBufferSize() - 10;
            int totalPackages = 0;

            List<string> segmentList = new List<string>();

            while (dataObjectList.Count > 0)
            {
                string segment = String.Empty;
                int currentLength = 0;

                if (head.Equals("T55") && totalPackages == 0)
                {
                    // 1st package need to specify [TxnType]<1A>[KID]<1A>[AID] at the beginning
                    segment += Convert.ToChar(0x1A).ToString() + string.Join(Convert.ToChar(0x1A).ToString(), first3Elements);
                    currentLength += segment.Length;
                }

                while (currentLength + 1 + dataObjectList[0].Length <= body_length)
                {
                    segment += Convert.ToChar(0x1A).ToString() + dataObjectList[0];
                    dataObjectList.RemoveAt(0);
                    currentLength += segment.Length;

                    if (dataObjectList.Count == 0)
                        break;
                }
                segmentList.Add(segment);
                totalPackages++;
            }

            // Sending messages
            int pkg = 1;
            while (segmentList.Count > 0)
            {
                Console.WriteLine($"Sending package {pkg} of {totalPackages}");
                try
                {
                    string response = String.Empty;
                    serialPort.WriteAndReadMessage(PktType.STX, head + pkg.ToString() + totalPackages.ToString(), segmentList[0], out response);

                    if (pkg == 1)
                        tbStatus.AppendText($"Setting Config {configName} ...\t");

                    if (response.IndexOf("T560", StringComparison.OrdinalIgnoreCase) < 0 &&
                        response.IndexOf("T520", StringComparison.OrdinalIgnoreCase) < 0)
                    {
                        // Fail
                        //MessageBox.Show($"Error message: {response}\n\n");
                        tbStatus.AppendText($"Failed: {response}" + Environment.NewLine);
                        break;
                    }
                    else
                    {
                        // Success, sending next package if any   
                        segmentList.RemoveAt(0);
                        pkg++;
                        if (segmentList.Count == 0)
                            tbStatus.AppendText("Done!" + Environment.NewLine);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error message: {ex.Message}\n\n");
                    break;
                }
            }
        }

        private void btnGetAll_Click(object sender, EventArgs e)
        {
            // <02>T592<03>[LRC]
            string t59response = String.Empty;
            listBoxReaderConfig.Items.Clear();
            try
            {
                serialPort.WriteAndReadMessage(PktType.STX, "T59", "2", out t59response);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            if (t59response.ToUpper().Equals("T5A21"))
            {
                listBoxReaderConfig.Items.Clear();
                MessageBox.Show("No application configs in the Reader");
                return;
            }

            if (t59response.ToUpper().StartsWith("T5A20") ||
                t59response.ToUpper().StartsWith("T5A23"))
            {
                Console.WriteLine(t59response);
                if (t59response.Length <= 6)
                    return;
                t59response = t59response.Substring(6);
                string[] configs = t59response.Split(Convert.ToChar(0x1C));

                foreach (string config in configs)
                {
                    listBoxReaderConfig.Items.Add(config);
                }
            }
            else
            {
                MessageBox.Show("Error Message:\n\n {0}", t59response);
            }
        }
    }
}
