﻿using System;
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

            AddFormToTab(new CfgLoadFileForm(), tpConfig);
            AddFormToTab(new CfgLoadKeyForm(), tpCAPK);
            AddFormToTab(new CfgSetDrlForm(), tpDRL);
            AddFormToTab(new CfgSetParameterForm(), tpParameter);

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
