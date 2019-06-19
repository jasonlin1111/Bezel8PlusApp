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
    public partial class MainConfigForm : Form
    {
        public MainConfigForm()
        {
            InitializeComponent();

            AddFormToTab(new TerAppConfigForm(), tpConfig);
            AddFormToTab(new CapkForm(), tpCAPK);
            AddFormToTab(new DRLForm(), tpDRL);
            AddFormToTab(new TimeSettingForm(), tpTime);
            AddFormToTab(new ParameterForm(), tpParameter);

        }

        private void AddFormToTab(Form form, TabPage tabPage)
        {
            form.TopLevel = false;
            form.Visible = true;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            tabPage.Controls.Add(form);
        }
    }
}
