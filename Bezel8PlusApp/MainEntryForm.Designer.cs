namespace Bezel8PlusApp
{
    partial class MainEntryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBoxCom = new System.Windows.Forms.GroupBox();
            this.btnCloseCom = new System.Windows.Forms.Button();
            this.btnOpenCom = new System.Windows.Forms.Button();
            this.tableLayoutPanelComSetting = new System.Windows.Forms.TableLayoutPanel();
            this.cbparity = new System.Windows.Forms.ComboBox();
            this.cbDataBits = new System.Windows.Forms.ComboBox();
            this.lbParity = new System.Windows.Forms.Label();
            this.lbDataBits = new System.Windows.Forms.Label();
            this.lbCom = new System.Windows.Forms.Label();
            this.cbCOM = new System.Windows.Forms.ComboBox();
            this.cbBuadRate = new System.Windows.Forms.ComboBox();
            this.lbBuadrate = new System.Windows.Forms.Label();
            this.lbStopBits = new System.Windows.Forms.Label();
            this.lbHandShake = new System.Windows.Forms.Label();
            this.cbStopBits = new System.Windows.Forms.ComboBox();
            this.cbHandShake = new System.Windows.Forms.ComboBox();
            this.groupBoxMenu = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelMenu = new System.Windows.Forms.TableLayoutPanel();
            this.btnMenu5 = new System.Windows.Forms.Button();
            this.btnMenu4 = new System.Windows.Forms.Button();
            this.btnMenu3 = new System.Windows.Forms.Button();
            this.btnMenuTxn = new System.Windows.Forms.Button();
            this.btnMenuConfig = new System.Windows.Forms.Button();
            this.groupBoxWorkspace = new System.Windows.Forms.GroupBox();
            this.groupBoxCom.SuspendLayout();
            this.tableLayoutPanelComSetting.SuspendLayout();
            this.groupBoxMenu.SuspendLayout();
            this.tableLayoutPanelMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxCom
            // 
            this.groupBoxCom.Controls.Add(this.btnCloseCom);
            this.groupBoxCom.Controls.Add(this.btnOpenCom);
            this.groupBoxCom.Controls.Add(this.tableLayoutPanelComSetting);
            this.groupBoxCom.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxCom.Location = new System.Drawing.Point(0, 0);
            this.groupBoxCom.Name = "groupBoxCom";
            this.groupBoxCom.Size = new System.Drawing.Size(1061, 87);
            this.groupBoxCom.TabIndex = 0;
            this.groupBoxCom.TabStop = false;
            // 
            // btnCloseCom
            // 
            this.btnCloseCom.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCloseCom.Enabled = false;
            this.btnCloseCom.Location = new System.Drawing.Point(633, 18);
            this.btnCloseCom.Name = "btnCloseCom";
            this.btnCloseCom.Size = new System.Drawing.Size(87, 66);
            this.btnCloseCom.TabIndex = 3;
            this.btnCloseCom.Text = "CLOSE";
            this.btnCloseCom.UseVisualStyleBackColor = true;
            this.btnCloseCom.Click += new System.EventHandler(this.btnCloseCom_Click);
            // 
            // btnOpenCom
            // 
            this.btnOpenCom.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnOpenCom.Location = new System.Drawing.Point(548, 18);
            this.btnOpenCom.Name = "btnOpenCom";
            this.btnOpenCom.Size = new System.Drawing.Size(85, 66);
            this.btnOpenCom.TabIndex = 2;
            this.btnOpenCom.Text = "OPEN";
            this.btnOpenCom.UseVisualStyleBackColor = true;
            this.btnOpenCom.Click += new System.EventHandler(this.btnOpenCom_Click);
            // 
            // tableLayoutPanelComSetting
            // 
            this.tableLayoutPanelComSetting.ColumnCount = 6;
            this.tableLayoutPanelComSetting.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.31707F));
            this.tableLayoutPanelComSetting.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.68293F));
            this.tableLayoutPanelComSetting.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 78F));
            this.tableLayoutPanelComSetting.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 89F));
            this.tableLayoutPanelComSetting.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 99F));
            this.tableLayoutPanelComSetting.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 108F));
            this.tableLayoutPanelComSetting.Controls.Add(this.cbparity, 3, 1);
            this.tableLayoutPanelComSetting.Controls.Add(this.cbDataBits, 2, 1);
            this.tableLayoutPanelComSetting.Controls.Add(this.lbParity, 3, 0);
            this.tableLayoutPanelComSetting.Controls.Add(this.lbDataBits, 2, 0);
            this.tableLayoutPanelComSetting.Controls.Add(this.lbCom, 0, 0);
            this.tableLayoutPanelComSetting.Controls.Add(this.cbCOM, 0, 1);
            this.tableLayoutPanelComSetting.Controls.Add(this.cbBuadRate, 1, 1);
            this.tableLayoutPanelComSetting.Controls.Add(this.lbBuadrate, 1, 0);
            this.tableLayoutPanelComSetting.Controls.Add(this.lbStopBits, 4, 0);
            this.tableLayoutPanelComSetting.Controls.Add(this.lbHandShake, 5, 0);
            this.tableLayoutPanelComSetting.Controls.Add(this.cbStopBits, 4, 1);
            this.tableLayoutPanelComSetting.Controls.Add(this.cbHandShake, 5, 1);
            this.tableLayoutPanelComSetting.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanelComSetting.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanelComSetting.Name = "tableLayoutPanelComSetting";
            this.tableLayoutPanelComSetting.RowCount = 2;
            this.tableLayoutPanelComSetting.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelComSetting.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelComSetting.Size = new System.Drawing.Size(545, 66);
            this.tableLayoutPanelComSetting.TabIndex = 1;
            // 
            // cbparity
            // 
            this.cbparity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbparity.Enabled = false;
            this.cbparity.FormattingEnabled = true;
            this.cbparity.Items.AddRange(new object[] {
            "None"});
            this.cbparity.Location = new System.Drawing.Point(251, 36);
            this.cbparity.Name = "cbparity";
            this.cbparity.Size = new System.Drawing.Size(83, 20);
            this.cbparity.TabIndex = 7;
            // 
            // cbDataBits
            // 
            this.cbDataBits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbDataBits.Enabled = false;
            this.cbDataBits.FormattingEnabled = true;
            this.cbDataBits.Items.AddRange(new object[] {
            "8"});
            this.cbDataBits.Location = new System.Drawing.Point(173, 36);
            this.cbDataBits.Name = "cbDataBits";
            this.cbDataBits.Size = new System.Drawing.Size(72, 20);
            this.cbDataBits.TabIndex = 6;
            // 
            // lbParity
            // 
            this.lbParity.AutoSize = true;
            this.lbParity.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbParity.Location = new System.Drawing.Point(251, 21);
            this.lbParity.Name = "lbParity";
            this.lbParity.Size = new System.Drawing.Size(83, 12);
            this.lbParity.TabIndex = 5;
            this.lbParity.Text = "Parity";
            this.lbParity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbDataBits
            // 
            this.lbDataBits.AutoSize = true;
            this.lbDataBits.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbDataBits.Location = new System.Drawing.Point(173, 21);
            this.lbDataBits.Name = "lbDataBits";
            this.lbDataBits.Size = new System.Drawing.Size(72, 12);
            this.lbDataBits.TabIndex = 4;
            this.lbDataBits.Text = "Data Bits";
            this.lbDataBits.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbCom
            // 
            this.lbCom.AutoSize = true;
            this.lbCom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbCom.Location = new System.Drawing.Point(3, 21);
            this.lbCom.Name = "lbCom";
            this.lbCom.Size = new System.Drawing.Size(74, 12);
            this.lbCom.TabIndex = 0;
            this.lbCom.Text = "COM";
            this.lbCom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbCOM
            // 
            this.cbCOM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbCOM.FormattingEnabled = true;
            this.cbCOM.Location = new System.Drawing.Point(3, 36);
            this.cbCOM.Name = "cbCOM";
            this.cbCOM.Size = new System.Drawing.Size(74, 20);
            this.cbCOM.TabIndex = 1;
            this.cbCOM.Click += new System.EventHandler(this.cbCOM_Click);
            // 
            // cbBuadRate
            // 
            this.cbBuadRate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbBuadRate.FormattingEnabled = true;
            this.cbBuadRate.Items.AddRange(new object[] {
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.cbBuadRate.Location = new System.Drawing.Point(83, 36);
            this.cbBuadRate.Name = "cbBuadRate";
            this.cbBuadRate.Size = new System.Drawing.Size(84, 20);
            this.cbBuadRate.TabIndex = 2;
            // 
            // lbBuadrate
            // 
            this.lbBuadrate.AutoSize = true;
            this.lbBuadrate.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbBuadrate.Location = new System.Drawing.Point(83, 21);
            this.lbBuadrate.Name = "lbBuadrate";
            this.lbBuadrate.Size = new System.Drawing.Size(84, 12);
            this.lbBuadrate.TabIndex = 3;
            this.lbBuadrate.Text = "Buadrate";
            this.lbBuadrate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbStopBits
            // 
            this.lbStopBits.AutoSize = true;
            this.lbStopBits.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbStopBits.Location = new System.Drawing.Point(340, 21);
            this.lbStopBits.Name = "lbStopBits";
            this.lbStopBits.Size = new System.Drawing.Size(93, 12);
            this.lbStopBits.TabIndex = 8;
            this.lbStopBits.Text = "Stop Bits";
            this.lbStopBits.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbHandShake
            // 
            this.lbHandShake.AutoSize = true;
            this.lbHandShake.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbHandShake.Location = new System.Drawing.Point(439, 21);
            this.lbHandShake.Name = "lbHandShake";
            this.lbHandShake.Size = new System.Drawing.Size(103, 12);
            this.lbHandShake.TabIndex = 9;
            this.lbHandShake.Text = "Hand Shake";
            this.lbHandShake.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbStopBits
            // 
            this.cbStopBits.Enabled = false;
            this.cbStopBits.FormattingEnabled = true;
            this.cbStopBits.Items.AddRange(new object[] {
            "1"});
            this.cbStopBits.Location = new System.Drawing.Point(340, 36);
            this.cbStopBits.Name = "cbStopBits";
            this.cbStopBits.Size = new System.Drawing.Size(93, 20);
            this.cbStopBits.TabIndex = 10;
            // 
            // cbHandShake
            // 
            this.cbHandShake.Enabled = false;
            this.cbHandShake.FormattingEnabled = true;
            this.cbHandShake.Items.AddRange(new object[] {
            "None"});
            this.cbHandShake.Location = new System.Drawing.Point(439, 36);
            this.cbHandShake.Name = "cbHandShake";
            this.cbHandShake.Size = new System.Drawing.Size(93, 20);
            this.cbHandShake.TabIndex = 11;
            // 
            // groupBoxMenu
            // 
            this.groupBoxMenu.Controls.Add(this.tableLayoutPanelMenu);
            this.groupBoxMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBoxMenu.Location = new System.Drawing.Point(0, 87);
            this.groupBoxMenu.Name = "groupBoxMenu";
            this.groupBoxMenu.Size = new System.Drawing.Size(97, 519);
            this.groupBoxMenu.TabIndex = 1;
            this.groupBoxMenu.TabStop = false;
            // 
            // tableLayoutPanelMenu
            // 
            this.tableLayoutPanelMenu.ColumnCount = 1;
            this.tableLayoutPanelMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMenu.Controls.Add(this.btnMenu5, 0, 4);
            this.tableLayoutPanelMenu.Controls.Add(this.btnMenu4, 0, 3);
            this.tableLayoutPanelMenu.Controls.Add(this.btnMenu3, 0, 2);
            this.tableLayoutPanelMenu.Controls.Add(this.btnMenuTxn, 0, 1);
            this.tableLayoutPanelMenu.Controls.Add(this.btnMenuConfig, 0, 0);
            this.tableLayoutPanelMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMenu.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanelMenu.Name = "tableLayoutPanelMenu";
            this.tableLayoutPanelMenu.RowCount = 5;
            this.tableLayoutPanelMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelMenu.Size = new System.Drawing.Size(91, 498);
            this.tableLayoutPanelMenu.TabIndex = 0;
            // 
            // btnMenu5
            // 
            this.btnMenu5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMenu5.Location = new System.Drawing.Point(3, 399);
            this.btnMenu5.Name = "btnMenu5";
            this.btnMenu5.Size = new System.Drawing.Size(85, 96);
            this.btnMenu5.TabIndex = 4;
            this.btnMenu5.UseVisualStyleBackColor = true;
            // 
            // btnMenu4
            // 
            this.btnMenu4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMenu4.Location = new System.Drawing.Point(3, 300);
            this.btnMenu4.Name = "btnMenu4";
            this.btnMenu4.Size = new System.Drawing.Size(85, 93);
            this.btnMenu4.TabIndex = 3;
            this.btnMenu4.UseVisualStyleBackColor = true;
            // 
            // btnMenu3
            // 
            this.btnMenu3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMenu3.Location = new System.Drawing.Point(3, 201);
            this.btnMenu3.Name = "btnMenu3";
            this.btnMenu3.Size = new System.Drawing.Size(85, 93);
            this.btnMenu3.TabIndex = 2;
            this.btnMenu3.UseVisualStyleBackColor = true;
            // 
            // btnMenuTxn
            // 
            this.btnMenuTxn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMenuTxn.Location = new System.Drawing.Point(3, 102);
            this.btnMenuTxn.Name = "btnMenuTxn";
            this.btnMenuTxn.Size = new System.Drawing.Size(85, 93);
            this.btnMenuTxn.TabIndex = 1;
            this.btnMenuTxn.Text = "Transaction";
            this.btnMenuTxn.UseVisualStyleBackColor = true;
            this.btnMenuTxn.Click += new System.EventHandler(this.btnMenuTxn_Click);
            // 
            // btnMenuConfig
            // 
            this.btnMenuConfig.BackColor = System.Drawing.Color.White;
            this.btnMenuConfig.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnMenuConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMenuConfig.FlatAppearance.BorderSize = 0;
            this.btnMenuConfig.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnMenuConfig.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnMenuConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuConfig.Location = new System.Drawing.Point(3, 3);
            this.btnMenuConfig.Name = "btnMenuConfig";
            this.btnMenuConfig.Size = new System.Drawing.Size(85, 93);
            this.btnMenuConfig.TabIndex = 0;
            this.btnMenuConfig.Text = "Configuration";
            this.btnMenuConfig.UseVisualStyleBackColor = false;
            this.btnMenuConfig.Click += new System.EventHandler(this.btnMenuConfig_Click);
            // 
            // groupBoxWorkspace
            // 
            this.groupBoxWorkspace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxWorkspace.Location = new System.Drawing.Point(97, 87);
            this.groupBoxWorkspace.Name = "groupBoxWorkspace";
            this.groupBoxWorkspace.Size = new System.Drawing.Size(964, 519);
            this.groupBoxWorkspace.TabIndex = 2;
            this.groupBoxWorkspace.TabStop = false;
            // 
            // MainEntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1061, 606);
            this.Controls.Add(this.groupBoxWorkspace);
            this.Controls.Add(this.groupBoxMenu);
            this.Controls.Add(this.groupBoxCom);
            this.Name = "MainEntryForm";
            this.Text = "MainEntryForm";
            this.groupBoxCom.ResumeLayout(false);
            this.tableLayoutPanelComSetting.ResumeLayout(false);
            this.tableLayoutPanelComSetting.PerformLayout();
            this.groupBoxMenu.ResumeLayout(false);
            this.tableLayoutPanelMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxCom;
        private System.Windows.Forms.GroupBox groupBoxMenu;
        private System.Windows.Forms.GroupBox groupBoxWorkspace;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelComSetting;
        private System.Windows.Forms.ComboBox cbparity;
        private System.Windows.Forms.ComboBox cbDataBits;
        private System.Windows.Forms.Label lbParity;
        private System.Windows.Forms.Label lbDataBits;
        private System.Windows.Forms.Label lbCom;
        private System.Windows.Forms.ComboBox cbCOM;
        private System.Windows.Forms.ComboBox cbBuadRate;
        private System.Windows.Forms.Label lbBuadrate;
        private System.Windows.Forms.Label lbStopBits;
        private System.Windows.Forms.Label lbHandShake;
        private System.Windows.Forms.ComboBox cbStopBits;
        private System.Windows.Forms.ComboBox cbHandShake;
        private System.Windows.Forms.Button btnOpenCom;
        private System.Windows.Forms.Button btnCloseCom;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMenu;
        private System.Windows.Forms.Button btnMenu5;
        private System.Windows.Forms.Button btnMenu4;
        private System.Windows.Forms.Button btnMenu3;
        private System.Windows.Forms.Button btnMenuTxn;
        private System.Windows.Forms.Button btnMenuConfig;
    }
}