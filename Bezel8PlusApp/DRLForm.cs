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
    public partial class DRLForm : Form
    {
        public DRLForm()
        {
            InitializeComponent();
            //InitializeValue();
        }

        private void InitializeValue()
        {
            foreach (TableLayoutPanel tlp in tableLayoutPanel2.Controls)
            {
                foreach (Control crl in tlp.Controls)
                {
                    if (crl is CheckBox)
                    {
                        CheckBox cb = crl as CheckBox;
                        cb.Checked = false;
                        if (!cb.Name.Contains("PID"))
                            cb.Enabled = false;
                    }
                    else if (crl is TextBox)
                    {
                        //Console.WriteLine("TextBox");
                    }
                    else if (crl is ComboBox)
                    {
                        ComboBox cbb = crl as ComboBox;
                        cbb.SelectedIndex = 0;
                    }
                }
                /*
                for (int i = 0; i < tlp.Controls.Count; i++)
                {
                    Console.WriteLine(tlp.Controls[i].Name);
                }
                */
                //Console.WriteLine(tlp.Controls[0].Name);

            }
        }

        private void cbPIDs_CheckedChanged(object sender, EventArgs e)
        {
            if (!(sender is CheckBox))
                return;

            CheckBox cb = sender as CheckBox;
            foreach (Control crl in cb.Parent.Controls)
            {

                if (!cb.Checked)
                {
                    if (!crl.Equals(cb))
                        crl.Enabled = false;  
                }
                else
                {
                    if (crl is CheckBox)
                        crl.Enabled = true;
                }
            }
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!(sender is CheckBox))
                return;

            CheckBox cb = sender as CheckBox;
            if (cb.Name.StartsWith("cbAmount0Check"))
            {
                cb.Parent.Controls[1].Enabled = cb.Checked ? true : false;
            }
            else if (cb.Name.StartsWith("cbRCTLCheck"))
            {
                cb.Parent.Controls[6].Enabled = cb.Checked ? true : false;
            }
            else if (cb.Name.StartsWith("cbCVMCheck"))
            {
                cb.Parent.Controls[4].Enabled = cb.Checked ? true : false;
            }
            else if (cb.Name.StartsWith("cbRCFLCheck"))
            {
                cb.Parent.Controls[2].Enabled = cb.Checked ? true : false;
            }
        }

        private void CheckBox_EnabledChanged(object sender, EventArgs e)
        {
            if (!(sender is CheckBox))
                return;
            CheckBox cb = sender as CheckBox;

            if (!cb.Enabled)
                return;

            if (cb.Name.StartsWith("cbAmount0Check"))
            {
                cb.Parent.Controls[1].Enabled = cb.Checked ? true : false;
            }
            else if (cb.Name.StartsWith("cbRCTLCheck"))
            {
                cb.Parent.Controls[6].Enabled = cb.Checked ? true : false;
            }
            else if (cb.Name.StartsWith("cbCVMCheck"))
            {
                cb.Parent.Controls[4].Enabled = cb.Checked ? true : false;
            }
            else if (cb.Name.StartsWith("cbRCFLCheck"))
            {
                cb.Parent.Controls[2].Enabled = cb.Checked ? true : false;
            }
        }
    }

}
