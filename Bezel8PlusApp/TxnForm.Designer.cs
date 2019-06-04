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
            this.btnHostSend = new System.Windows.Forms.Button();
            this.tbOnlineData = new System.Windows.Forms.TextBox();
            this.tbIssuerScript = new System.Windows.Forms.TextBox();
            this.cbIssuerScript = new System.Windows.Forms.CheckBox();
            this.tbIAD = new System.Windows.Forms.TextBox();
            this.cbIAD = new System.Windows.Forms.CheckBox();
            this.cbARC = new System.Windows.Forms.CheckBox();
            this.comBoxARC = new System.Windows.Forms.ComboBox();
            this.cbNoAuthRes = new System.Windows.Forms.CheckBox();
            this.cbAutoReply = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.lbMs = new System.Windows.Forms.Label();
            this.tbAutoRunTime = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.tbOutcome = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanelTxn.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanelTxn);
            this.groupBox1.Location = new System.Drawing.Point(6, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(392, 245);
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
            this.tableLayoutPanelTxn.Size = new System.Drawing.Size(386, 224);
            this.tableLayoutPanelTxn.TabIndex = 0;
            // 
            // textBoxTimeout
            // 
            this.textBoxTimeout.Dock = System.Windows.Forms.DockStyle.Left;
            this.textBoxTimeout.Enabled = false;
            this.textBoxTimeout.Location = new System.Drawing.Point(196, 188);
            this.textBoxTimeout.Name = "textBoxTimeout";
            this.textBoxTimeout.Size = new System.Drawing.Size(70, 22);
            this.textBoxTimeout.TabIndex = 11;
            // 
            // comBoxTxnType
            // 
            this.comBoxTxnType.FormattingEnabled = true;
            this.comBoxTxnType.Items.AddRange(new object[] {
            "PURCHASE",
            "CASH",
            "PURCHASE WITH CASHBACK",
            "REFUND"});
            this.comBoxTxnType.Location = new System.Drawing.Point(196, 3);
            this.comBoxTxnType.Name = "comBoxTxnType";
            this.comBoxTxnType.Size = new System.Drawing.Size(187, 20);
            this.comBoxTxnType.TabIndex = 1;
            // 
            // textBoxCurrencyExp
            // 
            this.textBoxCurrencyExp.Dock = System.Windows.Forms.DockStyle.Left;
            this.textBoxCurrencyExp.Location = new System.Drawing.Point(196, 151);
            this.textBoxCurrencyExp.MaxLength = 2;
            this.textBoxCurrencyExp.Name = "textBoxCurrencyExp";
            this.textBoxCurrencyExp.Size = new System.Drawing.Size(70, 22);
            this.textBoxCurrencyExp.TabIndex = 7;
            this.textBoxCurrencyExp.Text = "02";
            // 
            // cbCurrencyExp
            // 
            this.cbCurrencyExp.AutoCheck = false;
            this.cbCurrencyExp.AutoSize = true;
            this.cbCurrencyExp.Checked = true;
            this.cbCurrencyExp.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbCurrencyExp.Location = new System.Drawing.Point(3, 151);
            this.cbCurrencyExp.Name = "cbCurrencyExp";
            this.cbCurrencyExp.Size = new System.Drawing.Size(116, 16);
            this.cbCurrencyExp.TabIndex = 9;
            this.cbCurrencyExp.Text = "Currency Exponent";
            this.cbCurrencyExp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbCurrencyExp.UseVisualStyleBackColor = true;
            // 
            // cbAmountAuth
            // 
            this.cbAmountAuth.AutoSize = true;
            this.cbAmountAuth.Checked = true;
            this.cbAmountAuth.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAmountAuth.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbAmountAuth.Location = new System.Drawing.Point(3, 40);
            this.cbAmountAuth.Name = "cbAmountAuth";
            this.cbAmountAuth.Size = new System.Drawing.Size(62, 31);
            this.cbAmountAuth.TabIndex = 2;
            this.cbAmountAuth.Text = "Amount";
            this.cbAmountAuth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbAmountAuth.UseVisualStyleBackColor = true;
            // 
            // cbCurrencyCode
            // 
            this.cbCurrencyCode.AutoCheck = false;
            this.cbCurrencyCode.AutoSize = true;
            this.cbCurrencyCode.Checked = true;
            this.cbCurrencyCode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbCurrencyCode.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbCurrencyCode.Location = new System.Drawing.Point(3, 114);
            this.cbCurrencyCode.Name = "cbCurrencyCode";
            this.cbCurrencyCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbCurrencyCode.Size = new System.Drawing.Size(96, 31);
            this.cbCurrencyCode.TabIndex = 8;
            this.cbCurrencyCode.Text = "Currency Code";
            this.cbCurrencyCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbCurrencyCode.UseVisualStyleBackColor = true;
            // 
            // textBoxCurrencyCode
            // 
            this.textBoxCurrencyCode.Dock = System.Windows.Forms.DockStyle.Left;
            this.textBoxCurrencyCode.Location = new System.Drawing.Point(196, 114);
            this.textBoxCurrencyCode.MaxLength = 4;
            this.textBoxCurrencyCode.Name = "textBoxCurrencyCode";
            this.textBoxCurrencyCode.Size = new System.Drawing.Size(70, 22);
            this.textBoxCurrencyCode.TabIndex = 6;
            this.textBoxCurrencyCode.Text = "0840";
            // 
            // textBoxAmountAuth
            // 
            this.textBoxAmountAuth.Dock = System.Windows.Forms.DockStyle.Left;
            this.textBoxAmountAuth.Location = new System.Drawing.Point(196, 40);
            this.textBoxAmountAuth.MaxLength = 12;
            this.textBoxAmountAuth.Name = "textBoxAmountAuth";
            this.textBoxAmountAuth.Size = new System.Drawing.Size(152, 22);
            this.textBoxAmountAuth.TabIndex = 4;
            this.textBoxAmountAuth.Text = "000000000000";
            // 
            // cbAmountOther
            // 
            this.cbAmountOther.AutoSize = true;
            this.cbAmountOther.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbAmountOther.Location = new System.Drawing.Point(3, 77);
            this.cbAmountOther.Name = "cbAmountOther";
            this.cbAmountOther.Size = new System.Drawing.Size(91, 31);
            this.cbAmountOther.TabIndex = 3;
            this.cbAmountOther.Text = "Amount Other";
            this.cbAmountOther.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbAmountOther.UseVisualStyleBackColor = true;
            // 
            // textBoxAmountOther
            // 
            this.textBoxAmountOther.Dock = System.Windows.Forms.DockStyle.Left;
            this.textBoxAmountOther.Location = new System.Drawing.Point(196, 77);
            this.textBoxAmountOther.MaxLength = 12;
            this.textBoxAmountOther.Name = "textBoxAmountOther";
            this.textBoxAmountOther.Size = new System.Drawing.Size(152, 22);
            this.textBoxAmountOther.TabIndex = 5;
            this.textBoxAmountOther.Text = "000000000000";
            // 
            // cbTxnType
            // 
            this.cbTxnType.AutoCheck = false;
            this.cbTxnType.AutoSize = true;
            this.cbTxnType.Checked = true;
            this.cbTxnType.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbTxnType.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbTxnType.Location = new System.Drawing.Point(3, 3);
            this.cbTxnType.Name = "cbTxnType";
            this.cbTxnType.Size = new System.Drawing.Size(105, 31);
            this.cbTxnType.TabIndex = 0;
            this.cbTxnType.Text = "Transaction Type";
            this.cbTxnType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbTxnType.UseVisualStyleBackColor = true;
            // 
            // cbTimeout
            // 
            this.cbTimeout.AutoSize = true;
            this.cbTimeout.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbTimeout.Location = new System.Drawing.Point(3, 188);
            this.cbTimeout.Name = "cbTimeout";
            this.cbTimeout.Size = new System.Drawing.Size(87, 33);
            this.cbTimeout.TabIndex = 10;
            this.cbTimeout.Text = "Timeout (ms)";
            this.cbTimeout.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbTimeout.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnHostSend);
            this.groupBox2.Controls.Add(this.tbOnlineData);
            this.groupBox2.Controls.Add(this.tbIssuerScript);
            this.groupBox2.Controls.Add(this.cbIssuerScript);
            this.groupBox2.Controls.Add(this.tbIAD);
            this.groupBox2.Controls.Add(this.cbIAD);
            this.groupBox2.Controls.Add(this.cbARC);
            this.groupBox2.Controls.Add(this.comBoxARC);
            this.groupBox2.Controls.Add(this.cbNoAuthRes);
            this.groupBox2.Controls.Add(this.cbAutoReply);
            this.groupBox2.Location = new System.Drawing.Point(9, 253);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(521, 223);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "HOST";
            // 
            // btnHostSend
            // 
            this.btnHostSend.Enabled = false;
            this.btnHostSend.Location = new System.Drawing.Point(177, 18);
            this.btnHostSend.Name = "btnHostSend";
            this.btnHostSend.Size = new System.Drawing.Size(89, 65);
            this.btnHostSend.TabIndex = 9;
            this.btnHostSend.Text = "Send";
            this.btnHostSend.UseVisualStyleBackColor = true;
            this.btnHostSend.Click += new System.EventHandler(this.btnHostSend_Click);
            // 
            // tbOnlineData
            // 
            this.tbOnlineData.Dock = System.Windows.Forms.DockStyle.Right;
            this.tbOnlineData.Location = new System.Drawing.Point(276, 18);
            this.tbOnlineData.Multiline = true;
            this.tbOnlineData.Name = "tbOnlineData";
            this.tbOnlineData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbOnlineData.Size = new System.Drawing.Size(242, 202);
            this.tbOnlineData.TabIndex = 8;
            // 
            // tbIssuerScript
            // 
            this.tbIssuerScript.Location = new System.Drawing.Point(11, 137);
            this.tbIssuerScript.Multiline = true;
            this.tbIssuerScript.Name = "tbIssuerScript";
            this.tbIssuerScript.Size = new System.Drawing.Size(256, 80);
            this.tbIssuerScript.TabIndex = 7;
            // 
            // cbIssuerScript
            // 
            this.cbIssuerScript.AutoSize = true;
            this.cbIssuerScript.Location = new System.Drawing.Point(11, 115);
            this.cbIssuerScript.Name = "cbIssuerScript";
            this.cbIssuerScript.Size = new System.Drawing.Size(79, 16);
            this.cbIssuerScript.TabIndex = 6;
            this.cbIssuerScript.Text = "Issuer script";
            this.cbIssuerScript.UseVisualStyleBackColor = true;
            // 
            // tbIAD
            // 
            this.tbIAD.Location = new System.Drawing.Point(61, 89);
            this.tbIAD.Name = "tbIAD";
            this.tbIAD.Size = new System.Drawing.Size(205, 22);
            this.tbIAD.TabIndex = 5;
            // 
            // cbIAD
            // 
            this.cbIAD.AutoSize = true;
            this.cbIAD.Location = new System.Drawing.Point(11, 91);
            this.cbIAD.Name = "cbIAD";
            this.cbIAD.Size = new System.Drawing.Size(44, 16);
            this.cbIAD.TabIndex = 4;
            this.cbIAD.Text = "IAD";
            this.cbIAD.UseVisualStyleBackColor = true;
            // 
            // cbARC
            // 
            this.cbARC.AutoCheck = false;
            this.cbARC.AutoSize = true;
            this.cbARC.Checked = true;
            this.cbARC.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbARC.Location = new System.Drawing.Point(11, 65);
            this.cbARC.Name = "cbARC";
            this.cbARC.Size = new System.Drawing.Size(48, 16);
            this.cbARC.TabIndex = 3;
            this.cbARC.Text = "ARC";
            this.cbARC.UseVisualStyleBackColor = true;
            // 
            // comBoxARC
            // 
            this.comBoxARC.FormattingEnabled = true;
            this.comBoxARC.Items.AddRange(new object[] {
            "3030    (Approve)",
            "3531    (Decline)"});
            this.comBoxARC.Location = new System.Drawing.Point(61, 63);
            this.comBoxARC.Name = "comBoxARC";
            this.comBoxARC.Size = new System.Drawing.Size(110, 20);
            this.comBoxARC.TabIndex = 2;
            // 
            // cbNoAuthRes
            // 
            this.cbNoAuthRes.AutoSize = true;
            this.cbNoAuthRes.Location = new System.Drawing.Point(11, 43);
            this.cbNoAuthRes.Name = "cbNoAuthRes";
            this.cbNoAuthRes.Size = new System.Drawing.Size(145, 16);
            this.cbNoAuthRes.TabIndex = 1;
            this.cbNoAuthRes.Text = "No authorization response";
            this.cbNoAuthRes.UseVisualStyleBackColor = true;
            // 
            // cbAutoReply
            // 
            this.cbAutoReply.AutoSize = true;
            this.cbAutoReply.Checked = true;
            this.cbAutoReply.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAutoReply.Location = new System.Drawing.Point(11, 21);
            this.cbAutoReply.Name = "cbAutoReply";
            this.cbAutoReply.Size = new System.Drawing.Size(116, 16);
            this.cbAutoReply.TabIndex = 0;
            this.cbAutoReply.Text = "Automatically reply";
            this.cbAutoReply.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox3.Location = new System.Drawing.Point(536, 60);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(377, 416);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Receipt";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnCancel);
            this.groupBox5.Controls.Add(this.btnStart);
            this.groupBox5.Controls.Add(this.lbMs);
            this.groupBox5.Controls.Add(this.tbAutoRunTime);
            this.groupBox5.Controls.Add(this.checkBox1);
            this.groupBox5.Location = new System.Drawing.Point(404, 2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(132, 245);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Execution";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(6, 102);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 74);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(6, 18);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(120, 78);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lbMs
            // 
            this.lbMs.AutoSize = true;
            this.lbMs.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbMs.Location = new System.Drawing.Point(92, 212);
            this.lbMs.Name = "lbMs";
            this.lbMs.Size = new System.Drawing.Size(23, 15);
            this.lbMs.TabIndex = 2;
            this.lbMs.Text = "ms";
            // 
            // tbAutoRunTime
            // 
            this.tbAutoRunTime.Location = new System.Drawing.Point(6, 209);
            this.tbAutoRunTime.Name = "tbAutoRunTime";
            this.tbAutoRunTime.Size = new System.Drawing.Size(80, 22);
            this.tbAutoRunTime.TabIndex = 1;
            this.tbAutoRunTime.Text = "2000";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(6, 187);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(66, 16);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Auto run";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // tbOutcome
            // 
            this.tbOutcome.Font = new System.Drawing.Font("Arial Black", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbOutcome.Location = new System.Drawing.Point(538, 12);
            this.tbOutcome.Name = "tbOutcome";
            this.tbOutcome.ReadOnly = true;
            this.tbOutcome.Size = new System.Drawing.Size(375, 38);
            this.tbOutcome.TabIndex = 5;
            this.tbOutcome.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TxnForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 491);
            this.Controls.Add(this.tbOutcome);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "TxnForm";
            this.Text = "TxnForm";
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanelTxn.ResumeLayout(false);
            this.tableLayoutPanelTxn.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
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
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox tbOnlineData;
        private System.Windows.Forms.Button btnHostSend;
        private System.Windows.Forms.TextBox tbOutcome;
    }
}