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

        private TerAppConfigForm terAndAppForm;
        private CapkForm capkForm;

        public MainConfigForm()
        {
            InitializeComponent();

            terAndAppForm = new TerAppConfigForm();
            capkForm = new CapkForm();
            AddFormToTab(terAndAppForm, tpConfig);
            AddFormToTab(capkForm, tpCAPK);

        }

        private void AddFormToTab(Form form, TabPage tabPage)
        {
            form.TopLevel = false;
            form.Visible = true;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            tabPage.Controls.Add(form);
        }

        private void MainConfigForm_Load(object sender, EventArgs e)
        {

        }
    }
}
