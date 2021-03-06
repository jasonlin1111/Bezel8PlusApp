﻿namespace Bezel8PlusApp
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
            this.btnDefaultSetting = new System.Windows.Forms.Button();
            this.btnCloseCom = new System.Windows.Forms.Button();
            this.btnOpenCom = new System.Windows.Forms.Button();
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
            this.btnMenuConfig = new System.Windows.Forms.Button();
            this.btnMenu5 = new System.Windows.Forms.Button();
            this.btnMenuTool = new System.Windows.Forms.Button();
            this.btnMenuLog = new System.Windows.Forms.Button();
            this.btnMenuTxn = new System.Windows.Forms.Button();
            this.groupBoxWorkspace = new System.Windows.Forms.GroupBox();
            this.pgbInitialCfg = new System.Windows.Forms.ProgressBar();
            this.tbInfo = new System.Windows.Forms.TextBox();
            this.btnGetVersion = new System.Windows.Forms.Button();
            this.tableLayoutPanelComSetting = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxCom.SuspendLayout();
            this.groupBoxMenu.SuspendLayout();
            this.tableLayoutPanelMenu.SuspendLayout();
            this.tableLayoutPanelComSetting.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxCom
            // 
            this.groupBoxCom.Controls.Add(this.tableLayoutPanel2);
            this.groupBoxCom.Controls.Add(this.tableLayoutPanelComSetting);
            this.groupBoxCom.Controls.Add(this.tbInfo);
            this.groupBoxCom.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxCom.Location = new System.Drawing.Point(0, 0);
            this.groupBoxCom.Name = "groupBoxCom";
            this.groupBoxCom.Size = new System.Drawing.Size(1242, 87);
            this.groupBoxCom.TabIndex = 0;
            this.groupBoxCom.TabStop = false;
            // 
            // btnDefaultSetting
            // 
            this.btnDefaultSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDefaultSetting.Enabled = false;
            this.btnDefaultSetting.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDefaultSetting.Location = new System.Drawing.Point(0, 0);
            this.btnDefaultSetting.Margin = new System.Windows.Forms.Padding(0);
            this.btnDefaultSetting.Name = "btnDefaultSetting";
            this.btnDefaultSetting.Size = new System.Drawing.Size(76, 50);
            this.btnDefaultSetting.TabIndex = 4;
            this.btnDefaultSetting.Text = "Default";
            this.btnDefaultSetting.UseVisualStyleBackColor = true;
            this.btnDefaultSetting.Click += new System.EventHandler(this.btnDefaultSetting_Click);
            // 
            // btnCloseCom
            // 
            this.btnCloseCom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCloseCom.Enabled = false;
            this.btnCloseCom.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseCom.Location = new System.Drawing.Point(85, 3);
            this.btnCloseCom.Name = "btnCloseCom";
            this.btnCloseCom.Size = new System.Drawing.Size(76, 63);
            this.btnCloseCom.TabIndex = 3;
            this.btnCloseCom.Text = "CLOSE";
            this.btnCloseCom.UseVisualStyleBackColor = true;
            this.btnCloseCom.Click += new System.EventHandler(this.btnCloseCom_Click);
            // 
            // btnOpenCom
            // 
            this.btnOpenCom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOpenCom.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenCom.Location = new System.Drawing.Point(3, 3);
            this.btnOpenCom.Name = "btnOpenCom";
            this.btnOpenCom.Size = new System.Drawing.Size(76, 63);
            this.btnOpenCom.TabIndex = 2;
            this.btnOpenCom.Text = "OPEN";
            this.btnOpenCom.UseVisualStyleBackColor = true;
            this.btnOpenCom.Click += new System.EventHandler(this.btnOpenCom_Click);
            // 
            // cbparity
            // 
            this.cbparity.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbparity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbparity.Enabled = false;
            this.cbparity.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbparity.FormattingEnabled = true;
            this.cbparity.Location = new System.Drawing.Point(246, 37);
            this.cbparity.Name = "cbparity";
            this.cbparity.Size = new System.Drawing.Size(67, 22);
            this.cbparity.TabIndex = 7;
            // 
            // cbDataBits
            // 
            this.cbDataBits.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbDataBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDataBits.Enabled = false;
            this.cbDataBits.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDataBits.FormattingEnabled = true;
            this.cbDataBits.Items.AddRange(new object[] {
            "8"});
            this.cbDataBits.Location = new System.Drawing.Point(173, 37);
            this.cbDataBits.Name = "cbDataBits";
            this.cbDataBits.Size = new System.Drawing.Size(67, 22);
            this.cbDataBits.TabIndex = 6;
            // 
            // lbParity
            // 
            this.lbParity.AutoSize = true;
            this.lbParity.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbParity.Enabled = false;
            this.lbParity.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbParity.Location = new System.Drawing.Point(246, 19);
            this.lbParity.Name = "lbParity";
            this.lbParity.Size = new System.Drawing.Size(67, 15);
            this.lbParity.TabIndex = 5;
            this.lbParity.Text = "Parity";
            this.lbParity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbDataBits
            // 
            this.lbDataBits.AutoSize = true;
            this.lbDataBits.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbDataBits.Enabled = false;
            this.lbDataBits.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDataBits.Location = new System.Drawing.Point(173, 19);
            this.lbDataBits.Name = "lbDataBits";
            this.lbDataBits.Size = new System.Drawing.Size(67, 15);
            this.lbDataBits.TabIndex = 4;
            this.lbDataBits.Text = "Data Bits";
            this.lbDataBits.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbCom
            // 
            this.lbCom.AutoSize = true;
            this.lbCom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbCom.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCom.Location = new System.Drawing.Point(3, 19);
            this.lbCom.Name = "lbCom";
            this.lbCom.Size = new System.Drawing.Size(79, 15);
            this.lbCom.TabIndex = 0;
            this.lbCom.Text = "COM";
            this.lbCom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbCOM
            // 
            this.cbCOM.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbCOM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCOM.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCOM.FormattingEnabled = true;
            this.cbCOM.Location = new System.Drawing.Point(3, 37);
            this.cbCOM.Name = "cbCOM";
            this.cbCOM.Size = new System.Drawing.Size(79, 22);
            this.cbCOM.TabIndex = 1;
            this.cbCOM.Click += new System.EventHandler(this.cbCOM_Click);
            // 
            // cbBuadRate
            // 
            this.cbBuadRate.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbBuadRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBuadRate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBuadRate.FormattingEnabled = true;
            this.cbBuadRate.Location = new System.Drawing.Point(88, 37);
            this.cbBuadRate.Name = "cbBuadRate";
            this.cbBuadRate.Size = new System.Drawing.Size(79, 22);
            this.cbBuadRate.TabIndex = 2;
            // 
            // lbBuadrate
            // 
            this.lbBuadrate.AutoSize = true;
            this.lbBuadrate.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbBuadrate.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBuadrate.Location = new System.Drawing.Point(88, 19);
            this.lbBuadrate.Name = "lbBuadrate";
            this.lbBuadrate.Size = new System.Drawing.Size(79, 15);
            this.lbBuadrate.TabIndex = 3;
            this.lbBuadrate.Text = "Buadrate";
            this.lbBuadrate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbStopBits
            // 
            this.lbStopBits.AutoSize = true;
            this.lbStopBits.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbStopBits.Enabled = false;
            this.lbStopBits.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStopBits.Location = new System.Drawing.Point(319, 19);
            this.lbStopBits.Name = "lbStopBits";
            this.lbStopBits.Size = new System.Drawing.Size(79, 15);
            this.lbStopBits.TabIndex = 8;
            this.lbStopBits.Text = "Stop Bits";
            this.lbStopBits.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbHandShake
            // 
            this.lbHandShake.AutoSize = true;
            this.lbHandShake.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbHandShake.Enabled = false;
            this.lbHandShake.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHandShake.Location = new System.Drawing.Point(404, 19);
            this.lbHandShake.Name = "lbHandShake";
            this.lbHandShake.Size = new System.Drawing.Size(82, 15);
            this.lbHandShake.TabIndex = 9;
            this.lbHandShake.Text = "Hand Shake";
            this.lbHandShake.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbStopBits
            // 
            this.cbStopBits.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStopBits.Enabled = false;
            this.cbStopBits.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbStopBits.FormattingEnabled = true;
            this.cbStopBits.Location = new System.Drawing.Point(319, 37);
            this.cbStopBits.Name = "cbStopBits";
            this.cbStopBits.Size = new System.Drawing.Size(79, 22);
            this.cbStopBits.TabIndex = 10;
            // 
            // cbHandShake
            // 
            this.cbHandShake.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbHandShake.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHandShake.Enabled = false;
            this.cbHandShake.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbHandShake.FormattingEnabled = true;
            this.cbHandShake.Location = new System.Drawing.Point(404, 37);
            this.cbHandShake.Name = "cbHandShake";
            this.cbHandShake.Size = new System.Drawing.Size(82, 22);
            this.cbHandShake.TabIndex = 11;
            // 
            // groupBoxMenu
            // 
            this.groupBoxMenu.Controls.Add(this.tableLayoutPanelMenu);
            this.groupBoxMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBoxMenu.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxMenu.Location = new System.Drawing.Point(0, 87);
            this.groupBoxMenu.Name = "groupBoxMenu";
            this.groupBoxMenu.Size = new System.Drawing.Size(109, 574);
            this.groupBoxMenu.TabIndex = 1;
            this.groupBoxMenu.TabStop = false;
            // 
            // tableLayoutPanelMenu
            // 
            this.tableLayoutPanelMenu.ColumnCount = 1;
            this.tableLayoutPanelMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMenu.Controls.Add(this.btnMenuConfig, 0, 1);
            this.tableLayoutPanelMenu.Controls.Add(this.btnMenu5, 0, 4);
            this.tableLayoutPanelMenu.Controls.Add(this.btnMenuTool, 0, 3);
            this.tableLayoutPanelMenu.Controls.Add(this.btnMenuLog, 0, 2);
            this.tableLayoutPanelMenu.Controls.Add(this.btnMenuTxn, 0, 0);
            this.tableLayoutPanelMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMenu.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanelMenu.Name = "tableLayoutPanelMenu";
            this.tableLayoutPanelMenu.RowCount = 5;
            this.tableLayoutPanelMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelMenu.Size = new System.Drawing.Size(103, 553);
            this.tableLayoutPanelMenu.TabIndex = 0;
            // 
            // btnMenuConfig
            // 
            this.btnMenuConfig.BackColor = System.Drawing.Color.Transparent;
            this.btnMenuConfig.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnMenuConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMenuConfig.FlatAppearance.BorderSize = 0;
            this.btnMenuConfig.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnMenuConfig.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnMenuConfig.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuConfig.Location = new System.Drawing.Point(3, 113);
            this.btnMenuConfig.Name = "btnMenuConfig";
            this.btnMenuConfig.Size = new System.Drawing.Size(97, 104);
            this.btnMenuConfig.TabIndex = 0;
            this.btnMenuConfig.Text = "Configuration";
            this.btnMenuConfig.UseVisualStyleBackColor = false;
            this.btnMenuConfig.Click += new System.EventHandler(this.MenuButton_Click);
            // 
            // btnMenu5
            // 
            this.btnMenu5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMenu5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenu5.Location = new System.Drawing.Point(3, 443);
            this.btnMenu5.Name = "btnMenu5";
            this.btnMenu5.Size = new System.Drawing.Size(97, 107);
            this.btnMenu5.TabIndex = 4;
            this.btnMenu5.UseVisualStyleBackColor = true;
            this.btnMenu5.Visible = false;
            // 
            // btnMenuTool
            // 
            this.btnMenuTool.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMenuTool.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuTool.Location = new System.Drawing.Point(3, 333);
            this.btnMenuTool.Name = "btnMenuTool";
            this.btnMenuTool.Size = new System.Drawing.Size(97, 104);
            this.btnMenuTool.TabIndex = 3;
            this.btnMenuTool.Text = "Tools";
            this.btnMenuTool.UseVisualStyleBackColor = true;
            this.btnMenuTool.Click += new System.EventHandler(this.MenuButton_Click);
            // 
            // btnMenuLog
            // 
            this.btnMenuLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMenuLog.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuLog.Location = new System.Drawing.Point(3, 223);
            this.btnMenuLog.Name = "btnMenuLog";
            this.btnMenuLog.Size = new System.Drawing.Size(97, 104);
            this.btnMenuLog.TabIndex = 2;
            this.btnMenuLog.Text = "Log";
            this.btnMenuLog.UseVisualStyleBackColor = true;
            this.btnMenuLog.Click += new System.EventHandler(this.MenuButton_Click);
            // 
            // btnMenuTxn
            // 
            this.btnMenuTxn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMenuTxn.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuTxn.Location = new System.Drawing.Point(3, 3);
            this.btnMenuTxn.Name = "btnMenuTxn";
            this.btnMenuTxn.Size = new System.Drawing.Size(97, 104);
            this.btnMenuTxn.TabIndex = 1;
            this.btnMenuTxn.Text = "Transaction";
            this.btnMenuTxn.UseVisualStyleBackColor = true;
            this.btnMenuTxn.Click += new System.EventHandler(this.MenuButton_Click);
            // 
            // groupBoxWorkspace
            // 
            this.groupBoxWorkspace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxWorkspace.Location = new System.Drawing.Point(109, 87);
            this.groupBoxWorkspace.Name = "groupBoxWorkspace";
            this.groupBoxWorkspace.Size = new System.Drawing.Size(1133, 574);
            this.groupBoxWorkspace.TabIndex = 2;
            this.groupBoxWorkspace.TabStop = false;
            // 
            // pgbInitialCfg
            // 
            this.pgbInitialCfg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgbInitialCfg.Location = new System.Drawing.Point(1, 51);
            this.pgbInitialCfg.Margin = new System.Windows.Forms.Padding(1);
            this.pgbInitialCfg.Name = "pgbInitialCfg";
            this.pgbInitialCfg.Size = new System.Drawing.Size(74, 11);
            this.pgbInitialCfg.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pgbInitialCfg.TabIndex = 5;
            // 
            // tbInfo
            // 
            this.tbInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbInfo.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tbInfo.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbInfo.Location = new System.Drawing.Point(837, 12);
            this.tbInfo.Multiline = true;
            this.tbInfo.Name = "tbInfo";
            this.tbInfo.ReadOnly = true;
            this.tbInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbInfo.Size = new System.Drawing.Size(393, 68);
            this.tbInfo.TabIndex = 6;
            // 
            // btnGetVersion
            // 
            this.btnGetVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGetVersion.Enabled = false;
            this.btnGetVersion.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetVersion.Location = new System.Drawing.Point(249, 3);
            this.btnGetVersion.Name = "btnGetVersion";
            this.btnGetVersion.Size = new System.Drawing.Size(78, 63);
            this.btnGetVersion.TabIndex = 7;
            this.btnGetVersion.Text = "Version";
            this.btnGetVersion.UseVisualStyleBackColor = true;
            this.btnGetVersion.Click += new System.EventHandler(this.btnGetVersion_Click);
            // 
            // tableLayoutPanelComSetting
            // 
            this.tableLayoutPanelComSetting.ColumnCount = 6;
            this.tableLayoutPanelComSetting.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.5F));
            this.tableLayoutPanelComSetting.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.5F));
            this.tableLayoutPanelComSetting.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanelComSetting.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanelComSetting.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.5F));
            this.tableLayoutPanelComSetting.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.5F));
            this.tableLayoutPanelComSetting.Controls.Add(this.cbHandShake, 5, 1);
            this.tableLayoutPanelComSetting.Controls.Add(this.cbStopBits, 4, 1);
            this.tableLayoutPanelComSetting.Controls.Add(this.cbparity, 3, 1);
            this.tableLayoutPanelComSetting.Controls.Add(this.lbCom, 0, 0);
            this.tableLayoutPanelComSetting.Controls.Add(this.cbDataBits, 2, 1);
            this.tableLayoutPanelComSetting.Controls.Add(this.lbBuadrate, 1, 0);
            this.tableLayoutPanelComSetting.Controls.Add(this.cbBuadRate, 1, 1);
            this.tableLayoutPanelComSetting.Controls.Add(this.cbCOM, 0, 1);
            this.tableLayoutPanelComSetting.Controls.Add(this.lbParity, 3, 0);
            this.tableLayoutPanelComSetting.Controls.Add(this.lbDataBits, 2, 0);
            this.tableLayoutPanelComSetting.Controls.Add(this.lbStopBits, 4, 0);
            this.tableLayoutPanelComSetting.Controls.Add(this.lbHandShake, 5, 0);
            this.tableLayoutPanelComSetting.Location = new System.Drawing.Point(6, 12);
            this.tableLayoutPanelComSetting.Name = "tableLayoutPanelComSetting";
            this.tableLayoutPanelComSetting.RowCount = 2;
            this.tableLayoutPanelComSetting.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelComSetting.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelComSetting.Size = new System.Drawing.Size(489, 69);
            this.tableLayoutPanelComSetting.TabIndex = 8;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.btnDefaultSetting, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pgbInitialCfg, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(167, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(76, 63);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnOpenCom, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnCloseCom, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnGetVersion, 3, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(501, 12);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(330, 69);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // MainEntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1242, 661);
            this.Controls.Add(this.groupBoxWorkspace);
            this.Controls.Add(this.groupBoxMenu);
            this.Controls.Add(this.groupBoxCom);
            this.MinimumSize = new System.Drawing.Size(1100, 660);
            this.Name = "MainEntryForm";
            this.Text = "MainEntryForm";
            this.groupBoxCom.ResumeLayout(false);
            this.groupBoxCom.PerformLayout();
            this.groupBoxMenu.ResumeLayout(false);
            this.tableLayoutPanelMenu.ResumeLayout(false);
            this.tableLayoutPanelComSetting.ResumeLayout(false);
            this.tableLayoutPanelComSetting.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxCom;
        private System.Windows.Forms.GroupBox groupBoxMenu;
        private System.Windows.Forms.GroupBox groupBoxWorkspace;
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
        private System.Windows.Forms.Button btnMenuTool;
        private System.Windows.Forms.Button btnMenuLog;
        private System.Windows.Forms.Button btnMenuTxn;
        private System.Windows.Forms.Button btnMenuConfig;
        private System.Windows.Forms.Button btnDefaultSetting;
        private System.Windows.Forms.ProgressBar pgbInitialCfg;
        private System.Windows.Forms.TextBox tbInfo;
        private System.Windows.Forms.Button btnGetVersion;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelComSetting;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}