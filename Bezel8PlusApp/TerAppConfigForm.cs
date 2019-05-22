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
            string path = String.Empty;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                listBoxConfig.Items.Clear();
                confDataSet.Tables.Clear();
                path = Path.GetDirectoryName(openFileDialog.FileName) + @"\";
                //Console.WriteLine(path);
                try
                {
                    var sr = new StreamReader(openFileDialog.FileName);
                    while (!sr.EndOfStream)
                    {
                        string configFileName = sr.ReadLine().Trim();
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

            List<string> dataObjectList = new List<string>();

            // 1st package need to specify [TxnType]<1A>[KID]<1A>[AID] at the beginning
            string[] first3Elements = new string[3];

            // Build Data Stream
            string configName = listBoxConfig.SelectedItem.ToString();
            if (confDataSet.Tables.Contains(configName))
            {
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

                if (totalPackages == 0)
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

                    if (response.IndexOf("T560", StringComparison.OrdinalIgnoreCase) < 0 && 
                        response.IndexOf("T520", StringComparison.OrdinalIgnoreCase) < 0)
                    {
                        // fail
                        MessageBox.Show($"Error message: {response}\n\n");
                        break;
                    }
                    else
                    {
                        // Success, sending next package if any
                        if (sender.Equals(btnSetSelected))
                        {
                            MessageBox.Show($"Success: {response}\n\n");
                        }        
                        segmentList.RemoveAt(0);
                        pkg++;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error message: {ex.Message}\n\n");
                    break;
                }
            }

        }

        private void btnSetAll_Click(object sender, EventArgs e)
        {

            // Delete all configs first
            string t5bresponse = String.Empty;
            try
            {
                serialPort.WriteAndReadMessage(PktType.STX, "T5B", "2", out t5bresponse);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
                return;
            }

            if (t5bresponse.IndexOf("T5C20", StringComparison.OrdinalIgnoreCase) < 0)
            {
                MessageBox.Show($"\tDelete config failed\t\n\n\t{t5bresponse}");
                return;
            }

            System.Threading.Thread.Sleep(500);

            // Setting config one by one
            int count = confDataSet.Tables.Count;
            listBoxConfig.Enabled = false;
            for (int i = 0; i < listBoxConfig.Items.Count; i++)
            {
                listBoxConfig.SelectedIndex = i;
                btnSetSelected_Click(sender, e);
                System.Threading.Thread.Sleep(500);
            }
            listBoxConfig.Enabled = true;
        }
    }
}
