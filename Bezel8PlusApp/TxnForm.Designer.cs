namespace Bezel8PlusApp
{
    partial class TxnForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelTxn = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxTimeout = new System.Windows.Forms.TextBox();
            this.comBoxTxnType = new System.Windows.Forms.ComboBox();
            this.textBoxCurrencyExp = new System.Windows.Forms.TextBox();
            this.cbCurrencyExp = new System.Windows.Forms.CheckBox();
            this.cbAmountAuth = new System.Windows.Forms.CheckBox();
            this.cbCurrencyCode = new System.Windows.Forms.CheckBox();
            this.textBoxCurrencyCode = new System.Windows.Forms.TextBox();
            this.textBoxAmountAuth = new System.Windows.Forms.TextBox();
            this.cbAmountOther = new System.Windows.Forms.CheckBox();
            this.textBoxAmountOther = new System.Windows.Forms.TextBox();
            this.cbTxnType = new System.Windows.Forms.CheckBox();
            this.cbTimeout = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbIssuerScript = new System.Windows.Forms.TextBox();
            this.cbIssuerScript = new System.Windows.Forms.CheckBox();
            this.tbOnlineData = new System.Windows.Forms.TextBox();
            this.btnHostSend = new System.Windows.Forms.Button();
            this.tbIAD = new System.Windows.Forms.TextBox();
            this.cbIAD = new System.Windows.Forms.CheckBox();
            this.cbAutoReply = new System.Windows.Forms.CheckBox();
            this.cbNoAuthRes = new System.Windows.Forms.CheckBox();
            this.cbARC = new System.Windows.Forms.CheckBox();
            this.comBoxARC = new System.Windows.Forms.ComboBox();
            this.gbReceipt = new System.Windows.Forms.GroupBox();
            this.tbAutoRunTime = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lbMs = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cbAutoRun = new System.Windows.Forms.CheckBox();
            this.tbOutcome = new System.Windows.Forms.TextBox();
            this.gbOutcome = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel15 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanelTxn.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.gbOutcome.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel15.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanelTxn);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Calibri Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(414, 236);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Transaction Data";
            // 
            // tableLayoutPanelTxn
            // 
            this.tableLayoutPanelTxn.ColumnCount = 2;
            this.tableLayoutPanelTxn.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelTxn.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelTxn.Controls.Add(this.textBoxTimeout, 1, 5);
            this.tableLayoutPanelTxn.Controls.Add(this.comBoxTxnType, 1, 0);
            this.tableLayoutPanelTxn.Controls.Add(this.textBoxCurrencyExp, 1, 4);
            this.tableLayoutPanelTxn.Controls.Add(this.cbCurrencyExp, 0, 4);
            this.tableLayoutPanelTxn.Controls.Add(this.cbAmountAuth, 0, 1);
            this.tableLayoutPanelTxn.Controls.Add(this.cbCurrencyCode, 0, 3);
            this.tableLayoutPanelTxn.Controls.Add(this.textBoxCurrencyCode, 1, 3);
            this.tableLayoutPanelTxn.Controls.Add(this.textBoxAmountAuth, 1, 1);
            this.tableLayoutPanelTxn.Controls.Add(this.cbAmountOther, 0, 2);
            this.tableLayoutPanelTxn.Controls.Add(this.textBoxAmountOther, 1, 2);
            this.tableLayoutPanelTxn.Controls.Add(this.cbTxnType, 0, 0);
            this.tableLayoutPanelTxn.Controls.Add(this.cbTimeout, 0, 5);
            this.tableLayoutPanelTxn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelTxn.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanelTxn.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanelTxn.Name = "tableLayoutPanelTxn";
            this.tableLayoutPanelTxn.RowCount = 6;
            this.tableLayoutPanelTxn.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanelTxn.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanelTxn.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanelTxn.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanelTxn.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanelTxn.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanelTxn.Size = new System.Drawing.Size(408, 215);
            this.tableLayoutPanelTxn.TabIndex = 0;
            // 
            // textBoxTimeout
            // 
            this.textBoxTimeout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxTimeout.Enabled = false;
            this.textBoxTimeout.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.textBoxTimeout.Location = new System.Drawing.Point(207, 178);
            this.textBoxTimeout.Name = "textBoxTimeout";
            this.textBoxTimeout.Size = new System.Drawing.Size(70, 26);
            this.textBoxTimeout.TabIndex = 11;
            this.textBoxTimeout.Text = "60";
            // 
            // comBoxTxnType
            // 
            this.comBoxTxnType.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comBoxTxnType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comBoxTxnType.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comBoxTxnType.FormattingEnabled = true;
            this.comBoxTxnType.Location = new System.Drawing.Point(207, 3);
            this.comBoxTxnType.Name = "comBoxTxnType";
            this.comBoxTxnType.Size = new System.Drawing.Size(198, 26);
            this.comBoxTxnType.TabIndex = 1;
            // 
            // textBoxCurrencyExp
            // 
            this.textBoxCurrencyExp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxCurrencyExp.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCurrencyExp.Location = new System.Drawing.Point(207, 143);
            this.textBoxCurrencyExp.MaxLength = 2;
            this.textBoxCurrencyExp.Name = "textBoxCurrencyExp";
            this.textBoxCurrencyExp.Size = new System.Drawing.Size(70, 26);
            this.textBoxCurrencyExp.TabIndex = 7;
            this.textBoxCurrencyExp.Text = "02";
            // 
            // cbCurrencyExp
            // 
            this.cbCurrencyExp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cbCurrencyExp.AutoCheck = false;
            this.cbCurrencyExp.AutoSize = true;
            this.cbCurrencyExp.Checked = true;
            this.cbCurrencyExp.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbCurrencyExp.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCurrencyExp.Location = new System.Drawing.Point(3, 143);
            this.cbCurrencyExp.Name = "cbCurrencyExp";
            this.cbCurrencyExp.Size = new System.Drawing.Size(144, 29);
            this.cbCurrencyExp.TabIndex = 9;
            this.cbCurrencyExp.Text = "Currency Exponent";
            this.cbCurrencyExp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbCurrencyExp.UseVisualStyleBackColor = true;
            // 
            // cbAmountAuth
            // 
            this.cbAmountAuth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cbAmountAuth.AutoSize = true;
            this.cbAmountAuth.Checked = true;
            this.cbAmountAuth.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAmountAuth.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAmountAuth.Location = new System.Drawing.Point(3, 38);
            this.cbAmountAuth.Name = "cbAmountAuth";
            this.cbAmountAuth.Size = new System.Drawing.Size(77, 29);
            this.cbAmountAuth.TabIndex = 2;
            this.cbAmountAuth.Text = "Amount";
            this.cbAmountAuth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbAmountAuth.UseVisualStyleBackColor = true;
            // 
            // cbCurrencyCode
            // 
            this.cbCurrencyCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cbCurrencyCode.AutoCheck = false;
            this.cbCurrencyCode.AutoSize = true;
            this.cbCurrencyCode.Checked = true;
            this.cbCurrencyCode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbCurrencyCode.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCurrencyCode.Location = new System.Drawing.Point(3, 108);
            this.cbCurrencyCode.Name = "cbCurrencyCode";
            this.cbCurrencyCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbCurrencyCode.Size = new System.Drawing.Size(117, 29);
            this.cbCurrencyCode.TabIndex = 8;
            this.cbCurrencyCode.Text = "Currency Code";
            this.cbCurrencyCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbCurrencyCode.UseVisualStyleBackColor = true;
            // 
            // textBoxCurrencyCode
            // 
            this.textBoxCurrencyCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxCurrencyCode.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCurrencyCode.Location = new System.Drawing.Point(207, 108);
            this.textBoxCurrencyCode.MaxLength = 4;
            this.textBoxCurrencyCode.Name = "textBoxCurrencyCode";
            this.textBoxCurrencyCode.Size = new System.Drawing.Size(70, 26);
            this.textBoxCurrencyCode.TabIndex = 6;
            this.textBoxCurrencyCode.Text = "0840";
            // 
            // textBoxAmountAuth
            // 
            this.textBoxAmountAuth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxAmountAuth.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAmountAuth.Location = new System.Drawing.Point(207, 38);
            this.textBoxAmountAuth.MaxLength = 12;
            this.textBoxAmountAuth.Name = "textBoxAmountAuth";
            this.textBoxAmountAuth.Size = new System.Drawing.Size(141, 26);
            this.textBoxAmountAuth.TabIndex = 4;
            this.textBoxAmountAuth.Text = "000000000000";
            // 
            // cbAmountOther
            // 
            this.cbAmountOther.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cbAmountOther.AutoSize = true;
            this.cbAmountOther.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAmountOther.Location = new System.Drawing.Point(3, 73);
            this.cbAmountOther.Name = "cbAmountOther";
            this.cbAmountOther.Size = new System.Drawing.Size(116, 29);
            this.cbAmountOther.TabIndex = 3;
            this.cbAmountOther.Text = "Amount Other";
            this.cbAmountOther.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbAmountOther.UseVisualStyleBackColor = true;
            // 
            // textBoxAmountOther
            // 
            this.textBoxAmountOther.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxAmountOther.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAmountOther.Location = new System.Drawing.Point(207, 73);
            this.textBoxAmountOther.MaxLength = 12;
            this.textBoxAmountOther.Name = "textBoxAmountOther";
            this.textBoxAmountOther.Size = new System.Drawing.Size(141, 26);
            this.textBoxAmountOther.TabIndex = 5;
            this.textBoxAmountOther.Text = "000000000000";
            // 
            // cbTxnType
            // 
            this.cbTxnType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cbTxnType.AutoCheck = false;
            this.cbTxnType.AutoSize = true;
            this.cbTxnType.Checked = true;
            this.cbTxnType.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbTxnType.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTxnType.Location = new System.Drawing.Point(3, 3);
            this.cbTxnType.Name = "cbTxnType";
            this.cbTxnType.Size = new System.Drawing.Size(128, 29);
            this.cbTxnType.TabIndex = 0;
            this.cbTxnType.Text = "Transaction Type";
            this.cbTxnType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbTxnType.UseVisualStyleBackColor = true;
            // 
            // cbTimeout
            // 
            this.cbTimeout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cbTimeout.AutoSize = true;
            this.cbTimeout.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTimeout.Location = new System.Drawing.Point(3, 178);
            this.cbTimeout.Name = "cbTimeout";
            this.cbTimeout.Size = new System.Drawing.Size(136, 34);
            this.cbTimeout.TabIndex = 10;
            this.cbTimeout.Text = "Timeout (second)";
            this.cbTimeout.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbTimeout.UseVisualStyleBackColor = true;
            this.cbTimeout.CheckedChanged += new System.EventHandler(this.cbTimeout_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbIssuerScript);
            this.groupBox2.Controls.Add(this.cbIssuerScript);
            this.groupBox2.Controls.Add(this.tbOnlineData);
            this.groupBox2.Controls.Add(this.btnHostSend);
            this.groupBox2.Controls.Add(this.tbIAD);
            this.groupBox2.Controls.Add(this.cbIAD);
            this.groupBox2.Controls.Add(this.cbAutoReply);
            this.groupBox2.Controls.Add(this.cbNoAuthRes);
            this.groupBox2.Controls.Add(this.cbARC);
            this.groupBox2.Controls.Add(this.comBoxARC);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Calibri Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(3, 251);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(601, 264);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Host";
            // 
            // tbIssuerScript
            // 
            this.tbIssuerScript.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tbIssuerScript.Location = new System.Drawing.Point(6, 173);
            this.tbIssuerScript.Multiline = true;
            this.tbIssuerScript.Name = "tbIssuerScript";
            this.tbIssuerScript.Size = new System.Drawing.Size(219, 85);
            this.tbIssuerScript.TabIndex = 7;
            // 
            // cbIssuerScript
            // 
            this.cbIssuerScript.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbIssuerScript.AutoSize = true;
            this.cbIssuerScript.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbIssuerScript.Location = new System.Drawing.Point(8, 145);
            this.cbIssuerScript.Name = "cbIssuerScript";
            this.cbIssuerScript.Size = new System.Drawing.Size(102, 22);
            this.cbIssuerScript.TabIndex = 6;
            this.cbIssuerScript.Text = "Issuer Script";
            this.cbIssuerScript.UseVisualStyleBackColor = true;
            // 
            // tbOnlineData
            // 
            this.tbOnlineData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbOnlineData.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbOnlineData.Location = new System.Drawing.Point(231, 15);
            this.tbOnlineData.Multiline = true;
            this.tbOnlineData.Name = "tbOnlineData";
            this.tbOnlineData.ReadOnly = true;
            this.tbOnlineData.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbOnlineData.Size = new System.Drawing.Size(364, 243);
            this.tbOnlineData.TabIndex = 8;
            // 
            // btnHostSend
            // 
            this.btnHostSend.Enabled = false;
            this.btnHostSend.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHostSend.Location = new System.Drawing.Point(157, 15);
            this.btnHostSend.Name = "btnHostSend";
            this.btnHostSend.Size = new System.Drawing.Size(68, 64);
            this.btnHostSend.TabIndex = 9;
            this.btnHostSend.Text = "Send";
            this.btnHostSend.UseVisualStyleBackColor = true;
            this.btnHostSend.Click += new System.EventHandler(this.btnHostSend_Click);
            // 
            // tbIAD
            // 
            this.tbIAD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tbIAD.Location = new System.Drawing.Point(68, 117);
            this.tbIAD.Name = "tbIAD";
            this.tbIAD.Size = new System.Drawing.Size(157, 22);
            this.tbIAD.TabIndex = 5;
            // 
            // cbIAD
            // 
            this.cbIAD.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbIAD.AutoSize = true;
            this.cbIAD.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbIAD.Location = new System.Drawing.Point(8, 119);
            this.cbIAD.Margin = new System.Windows.Forms.Padding(5);
            this.cbIAD.Name = "cbIAD";
            this.cbIAD.Size = new System.Drawing.Size(49, 22);
            this.cbIAD.TabIndex = 4;
            this.cbIAD.Text = "IAD";
            this.cbIAD.UseVisualStyleBackColor = true;
            // 
            // cbAutoReply
            // 
            this.cbAutoReply.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbAutoReply.AutoSize = true;
            this.cbAutoReply.Checked = true;
            this.cbAutoReply.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAutoReply.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAutoReply.Location = new System.Drawing.Point(8, 23);
            this.cbAutoReply.Margin = new System.Windows.Forms.Padding(5);
            this.cbAutoReply.Name = "cbAutoReply";
            this.cbAutoReply.Size = new System.Drawing.Size(150, 22);
            this.cbAutoReply.TabIndex = 0;
            this.cbAutoReply.Text = "Automatically Reply";
            this.cbAutoReply.UseVisualStyleBackColor = true;
            // 
            // cbNoAuthRes
            // 
            this.cbNoAuthRes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbNoAuthRes.AutoSize = true;
            this.cbNoAuthRes.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbNoAuthRes.Location = new System.Drawing.Point(8, 55);
            this.cbNoAuthRes.Margin = new System.Windows.Forms.Padding(5);
            this.cbNoAuthRes.Name = "cbNoAuthRes";
            this.cbNoAuthRes.Size = new System.Drawing.Size(108, 22);
            this.cbNoAuthRes.TabIndex = 1;
            this.cbNoAuthRes.Text = "No Response";
            this.cbNoAuthRes.UseVisualStyleBackColor = true;
            // 
            // cbARC
            // 
            this.cbARC.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbARC.AutoCheck = false;
            this.cbARC.AutoSize = true;
            this.cbARC.Checked = true;
            this.cbARC.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbARC.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbARC.Location = new System.Drawing.Point(8, 87);
            this.cbARC.Margin = new System.Windows.Forms.Padding(5);
            this.cbARC.Name = "cbARC";
            this.cbARC.Size = new System.Drawing.Size(52, 22);
            this.cbARC.TabIndex = 3;
            this.cbARC.Text = "ARC";
            this.cbARC.UseVisualStyleBackColor = true;
            // 
            // comBoxARC
            // 
            this.comBoxARC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.comBoxARC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comBoxARC.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comBoxARC.FormattingEnabled = true;
            this.comBoxARC.Location = new System.Drawing.Point(68, 85);
            this.comBoxARC.Name = "comBoxARC";
            this.comBoxARC.Size = new System.Drawing.Size(157, 26);
            this.comBoxARC.TabIndex = 2;
            // 
            // gbReceipt
            // 
            this.gbReceipt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbReceipt.AutoSize = true;
            this.gbReceipt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbReceipt.Location = new System.Drawing.Point(6, 62);
            this.gbReceipt.Name = "gbReceipt";
            this.gbReceipt.Size = new System.Drawing.Size(388, 450);
            this.gbReceipt.TabIndex = 2;
            this.gbReceipt.TabStop = false;
            this.gbReceipt.Text = "Receipt";
            // 
            // tbAutoRunTime
            // 
            this.tbAutoRunTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbAutoRunTime.Enabled = false;
            this.tbAutoRunTime.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.tbAutoRunTime.Location = new System.Drawing.Point(87, 206);
            this.tbAutoRunTime.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbAutoRunTime.Name = "tbAutoRunTime";
            this.tbAutoRunTime.Size = new System.Drawing.Size(50, 26);
            this.tbAutoRunTime.TabIndex = 1;
            this.tbAutoRunTime.Text = "2000";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lbMs);
            this.groupBox5.Controls.Add(this.btnStart);
            this.groupBox5.Controls.Add(this.btnCancel);
            this.groupBox5.Controls.Add(this.tbAutoRunTime);
            this.groupBox5.Controls.Add(this.cbAutoRun);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Font = new System.Drawing.Font("Calibri Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(423, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(175, 236);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Operation";
            // 
            // lbMs
            // 
            this.lbMs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbMs.AutoSize = true;
            this.lbMs.Enabled = false;
            this.lbMs.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMs.Location = new System.Drawing.Point(138, 209);
            this.lbMs.Name = "lbMs";
            this.lbMs.Size = new System.Drawing.Size(26, 18);
            this.lbMs.TabIndex = 2;
            this.lbMs.Text = "ms";
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(6, 18);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(163, 89);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(6, 113);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(163, 83);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cbAutoRun
            // 
            this.cbAutoRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbAutoRun.AutoSize = true;
            this.cbAutoRun.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAutoRun.Location = new System.Drawing.Point(6, 208);
            this.cbAutoRun.Name = "cbAutoRun";
            this.cbAutoRun.Size = new System.Drawing.Size(81, 22);
            this.cbAutoRun.TabIndex = 0;
            this.cbAutoRun.Text = "Auto run";
            this.cbAutoRun.UseVisualStyleBackColor = true;
            this.cbAutoRun.CheckedChanged += new System.EventHandler(this.cbAutoRun_CheckedChanged);
            // 
            // tbOutcome
            // 
            this.tbOutcome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbOutcome.Font = new System.Drawing.Font("Arial Black", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbOutcome.Location = new System.Drawing.Point(3, 18);
            this.tbOutcome.Name = "tbOutcome";
            this.tbOutcome.ReadOnly = true;
            this.tbOutcome.Size = new System.Drawing.Size(397, 38);
            this.tbOutcome.TabIndex = 5;
            this.tbOutcome.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gbOutcome
            // 
            this.gbOutcome.Controls.Add(this.gbReceipt);
            this.gbOutcome.Controls.Add(this.tbOutcome);
            this.gbOutcome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbOutcome.Font = new System.Drawing.Font("Calibri Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbOutcome.Location = new System.Drawing.Point(616, 3);
            this.gbOutcome.Name = "gbOutcome";
            this.gbOutcome.Size = new System.Drawing.Size(403, 518);
            this.gbOutcome.TabIndex = 7;
            this.gbOutcome.TabStop = false;
            this.gbOutcome.Text = "Outcome";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.Controls.Add(this.gbOutcome, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1022, 524);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel15, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(607, 518);
            this.tableLayoutPanel2.TabIndex = 8;
            // 
            // tableLayoutPanel15
            // 
            this.tableLayoutPanel15.ColumnCount = 2;
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel15.Controls.Add(this.groupBox5, 1, 0);
            this.tableLayoutPanel15.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel15.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel15.Name = "tableLayoutPanel15";
            this.tableLayoutPanel15.RowCount = 1;
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel15.Size = new System.Drawing.Size(601, 242);
            this.tableLayoutPanel15.TabIndex = 10;
            // 
            // TxnForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 524);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "TxnForm";
            this.Text = "TxnForm";
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanelTxn.ResumeLayout(false);
            this.tableLayoutPanelTxn.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.gbOutcome.ResumeLayout(false);
            this.gbOutcome.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel15.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox gbReceipt;
        private System.Windows.Forms.TextBox textBoxTimeout;
        private System.Windows.Forms.CheckBox cbTimeout;
        private System.Windows.Forms.CheckBox cbCurrencyExp;
        private System.Windows.Forms.CheckBox cbCurrencyCode;
        private System.Windows.Forms.TextBox textBoxCurrencyExp;
        private System.Windows.Forms.TextBox textBoxCurrencyCode;
        private System.Windows.Forms.TextBox textBoxAmountOther;
        private System.Windows.Forms.TextBox textBoxAmountAuth;
        private System.Windows.Forms.CheckBox cbAmountOther;
        private System.Windows.Forms.CheckBox cbAmountAuth;
        private System.Windows.Forms.ComboBox comBoxTxnType;
        private System.Windows.Forms.CheckBox cbTxnType;
        private System.Windows.Forms.CheckBox cbAutoReply;
        private System.Windows.Forms.CheckBox cbARC;
        private System.Windows.Forms.ComboBox comBoxARC;
        private System.Windows.Forms.CheckBox cbNoAuthRes;
        private System.Windows.Forms.TextBox tbIssuerScript;
        private System.Windows.Forms.CheckBox cbIssuerScript;
        private System.Windows.Forms.TextBox tbIAD;
        private System.Windows.Forms.CheckBox cbIAD;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelTxn;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lbMs;
        private System.Windows.Forms.TextBox tbAutoRunTime;
        private System.Windows.Forms.CheckBox cbAutoRun;
        private System.Windows.Forms.Button btnHostSend;
        private System.Windows.Forms.TextBox tbOutcome;
        private System.Windows.Forms.GroupBox gbOutcome;
        private System.Windows.Forms.TextBox tbOnlineData;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel15;
    }
}