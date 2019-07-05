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
    public partial class ProgressBarForm : Form
    {
        public ProgressBarForm()
        {
            InitializeComponent();
            
        }

        public ProgressBarForm(int maximunValue)
        {
            InitializeComponent();
            progressBar.Maximum = maximunValue;
            this.Visible = true;
        }

        public void AppendText(string context)
        {
            tbStatus.AppendText(context);
        }

        public void IncreaseValue(int volume)
        {
            progressBar.Value += volume;
        }
    }
}
