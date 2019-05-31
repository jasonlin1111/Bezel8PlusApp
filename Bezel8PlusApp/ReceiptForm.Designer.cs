namespace Bezel8PlusApp
{
    partial class ReceiptForm
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
            this.gbReceipt = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbSign = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbMerchantID = new System.Windows.Forms.Label();
            this.lbTerminalID = new System.Windows.Forms.Label();
            this.lbAID = new System.Windows.Forms.Label();
            this.lbCardNo = new System.Windows.Forms.Label();
            this.lbTxnType = new System.Windows.Forms.Label();
            this.lbDateTime = new System.Windows.Forms.Label();
            this.lbAmount = new System.Windows.Forms.Label();
            this.lbAOSA = new System.Windows.Forms.Label();
            this.gbReceipt.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbReceipt
            // 
            this.gbReceipt.Controls.Add(this.tableLayoutPanel2);
            this.gbReceipt.Controls.Add(this.lbSign);
            this.gbReceipt.Controls.Add(this.tableLayoutPanel1);
            this.gbReceipt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbReceipt.Location = new System.Drawing.Point(0, 0);
            this.gbReceipt.Name = "gbReceipt";
            this.gbReceipt.Size = new System.Drawing.Size(346, 460);
            this.gbReceipt.TabIndex = 0;
            this.gbReceipt.TabStop = false;
            this.gbReceipt.Text = "Receipt";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.6092F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.39081F));
            this.tableLayoutPanel1.Controls.Add(this.lbAOSA, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.lbAmount, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lbDateTime, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lbTxnType, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbCardNo, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbAID, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 5);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 172);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(335, 119);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Application ID";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Card No.";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "Transaction Type";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "Date/Time";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "Amount";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "AOSA";
            // 
            // lbSign
            // 
            this.lbSign.AutoSize = true;
            this.lbSign.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSign.Location = new System.Drawing.Point(6, 373);
            this.lbSign.Name = "lbSign";
            this.lbSign.Size = new System.Drawing.Size(286, 27);
            this.lbSign.TabIndex = 1;
            this.lbSign.Text = "Signature: ____________";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.6092F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.39081F));
            this.tableLayoutPanel2.Controls.Add(this.label9, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label8, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lbMerchantID, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lbTerminalID, 1, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(6, 75);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(335, 47);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 12);
            this.label8.TabIndex = 1;
            this.label8.Text = "Merchant ID";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 12);
            this.label9.TabIndex = 2;
            this.label9.Text = "Terminal ID";
            // 
            // lbMerchantID
            // 
            this.lbMerchantID.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbMerchantID.AutoSize = true;
            this.lbMerchantID.Location = new System.Drawing.Point(108, 5);
            this.lbMerchantID.Name = "lbMerchantID";
            this.lbMerchantID.Size = new System.Drawing.Size(14, 12);
            this.lbMerchantID.TabIndex = 3;
            this.lbMerchantID.Text = "...";
            // 
            // lbTerminalID
            // 
            this.lbTerminalID.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbTerminalID.AutoSize = true;
            this.lbTerminalID.Location = new System.Drawing.Point(108, 29);
            this.lbTerminalID.Name = "lbTerminalID";
            this.lbTerminalID.Size = new System.Drawing.Size(14, 12);
            this.lbTerminalID.TabIndex = 4;
            this.lbTerminalID.Text = "...";
            // 
            // lbAID
            // 
            this.lbAID.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbAID.AutoSize = true;
            this.lbAID.Location = new System.Drawing.Point(108, 4);
            this.lbAID.Name = "lbAID";
            this.lbAID.Size = new System.Drawing.Size(14, 12);
            this.lbAID.TabIndex = 6;
            this.lbAID.Text = "...";
            // 
            // lbCardNo
            // 
            this.lbCardNo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbCardNo.AutoSize = true;
            this.lbCardNo.Location = new System.Drawing.Point(108, 24);
            this.lbCardNo.Name = "lbCardNo";
            this.lbCardNo.Size = new System.Drawing.Size(14, 12);
            this.lbCardNo.TabIndex = 7;
            this.lbCardNo.Text = "...";
            // 
            // lbTxnType
            // 
            this.lbTxnType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbTxnType.AutoSize = true;
            this.lbTxnType.Location = new System.Drawing.Point(108, 44);
            this.lbTxnType.Name = "lbTxnType";
            this.lbTxnType.Size = new System.Drawing.Size(14, 12);
            this.lbTxnType.TabIndex = 8;
            this.lbTxnType.Text = "...";
            // 
            // lbDateTime
            // 
            this.lbDateTime.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbDateTime.AutoSize = true;
            this.lbDateTime.Location = new System.Drawing.Point(108, 64);
            this.lbDateTime.Name = "lbDateTime";
            this.lbDateTime.Size = new System.Drawing.Size(14, 12);
            this.lbDateTime.TabIndex = 9;
            this.lbDateTime.Text = "...";
            // 
            // lbAmount
            // 
            this.lbAmount.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbAmount.AutoSize = true;
            this.lbAmount.Location = new System.Drawing.Point(108, 84);
            this.lbAmount.Name = "lbAmount";
            this.lbAmount.Size = new System.Drawing.Size(14, 12);
            this.lbAmount.TabIndex = 10;
            this.lbAmount.Text = "...";
            // 
            // lbAOSA
            // 
            this.lbAOSA.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbAOSA.AutoSize = true;
            this.lbAOSA.Location = new System.Drawing.Point(108, 104);
            this.lbAOSA.Name = "lbAOSA";
            this.lbAOSA.Size = new System.Drawing.Size(14, 12);
            this.lbAOSA.TabIndex = 11;
            this.lbAOSA.Text = "...";
            // 
            // ReceiptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 460);
            this.Controls.Add(this.gbReceipt);
            this.Name = "ReceiptForm";
            this.Text = "ReceiptForm";
            this.gbReceipt.ResumeLayout(false);
            this.gbReceipt.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbReceipt;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbSign;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbMerchantID;
        private System.Windows.Forms.Label lbTerminalID;
        private System.Windows.Forms.Label lbAOSA;
        private System.Windows.Forms.Label lbAmount;
        private System.Windows.Forms.Label lbDateTime;
        private System.Windows.Forms.Label lbTxnType;
        private System.Windows.Forms.Label lbCardNo;
        private System.Windows.Forms.Label lbAID;
    }
}