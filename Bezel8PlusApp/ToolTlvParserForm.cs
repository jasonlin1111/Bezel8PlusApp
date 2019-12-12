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
    public partial class ToolTlvParserForm : Form
    {
        public ToolTlvParserForm()
        {
            InitializeComponent();
        }

        private void btnParse_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tbInput.Text))
                return;
            if ((tbInput.Text.Length % 2) != 0)
            {
                MessageBox.Show("Length Error");
                return;
            }

            try
            {
                treeView1.Nodes.Clear();
                treeView1.BeginUpdate();
                TreeNode rootTreeNode = new TreeNode();
                test(tbInput.Text, ref rootTreeNode);
                treeView1.Nodes.Add(rootTreeNode);
                rootTreeNode.ExpandAll();
                treeView1.EndUpdate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void test(string stringIn, ref TreeNode parentNode)
        {
            List<TLVDataObject> tlvlist = TLVDataObject.ConvertToTLVList(stringIn);

            foreach (TLVDataObject tlv in tlvlist)
            {
                TreeNode tn = new TreeNode(tlv.TagString() + "   " + tlv.ValueString());
                parentNode.Nodes.Add(tn);
                if (tlv.IsConstructed)
                {
                    test(tlv.ValueString(), ref tn);
                }
            }
            return;
        }
    }

    
}
