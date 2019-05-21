namespace Bezel8PlusApp
{
    partial class CapkForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewCAPK = new System.Windows.Forms.DataGridView();
            this.listBoxCAPK = new System.Windows.Forms.ListBox();
            this.btnOpenCAPK = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRemoveAll = new System.Windows.Forms.Button();
            this.btnGetAll = new System.Windows.Forms.Button();
            this.btnSetAll = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbStatus = new System.Windows.Forms.TextBox();
            this.listBoxReaderCAPK = new System.Windows.Forms.ListBox();
            this.btnRemoveOne = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCAPK)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewCAPK
            // 
            this.dataGridViewCAPK.AllowUserToAddRows = false;
            this.dataGridViewCAPK.AllowUserToDeleteRows = false;
            this.dataGridViewCAPK.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ActiveBorder;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCAPK.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewCAPK.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCAPK.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewCAPK.Dock = System.Windows.Forms.DockStyle.Right;
            this.dataGridViewCAPK.Location = new System.Drawing.Point(620, 0);
            this.dataGridViewCAPK.Name = "dataGridViewCAPK";
            this.dataGridViewCAPK.RowTemplate.Height = 24;
            this.dataGridViewCAPK.Size = new System.Drawing.Size(555, 607);
            this.dataGridViewCAPK.TabIndex = 1;
            // 
            // listBoxCAPK
            // 
            this.listBoxCAPK.Font = new System.Drawing.Font("Arial Narrow", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.listBoxCAPK.FormattingEnabled = true;
            this.listBoxCAPK.ItemHeight = 21;
            this.listBoxCAPK.Location = new System.Drawing.Point(418, 0);
            this.listBoxCAPK.Name = "listBoxCAPK";
            this.listBoxCAPK.Size = new System.Drawing.Size(196, 361);
            this.listBoxCAPK.TabIndex = 4;
            this.listBoxCAPK.SelectedIndexChanged += new System.EventHandler(this.listBoxCAPK_SelectedIndexChanged);
            // 
            // btnOpenCAPK
            // 
            this.btnOpenCAPK.Location = new System.Drawing.Point(6, 42);
            this.btnOpenCAPK.Name = "btnOpenCAPK";
            this.btnOpenCAPK.Size = new System.Drawing.Size(95, 97);
            this.btnOpenCAPK.TabIndex = 5;
            this.btnOpenCAPK.Text = "OPEN";
            this.btnOpenCAPK.UseVisualStyleBackColor = true;
            this.btnOpenCAPK.Click += new System.EventHandler(this.btnOpenCAPK_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRemoveAll);
            this.groupBox1.Controls.Add(this.btnGetAll);
            this.groupBox1.Controls.Add(this.btnSetAll);
            this.groupBox1.Controls.Add(this.btnOpenCAPK);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(124, 607);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.Location = new System.Drawing.Point(6, 369);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(93, 106);
            this.btnRemoveAll.TabIndex = 8;
            this.btnRemoveAll.Text = "Remove All";
            this.btnRemoveAll.UseVisualStyleBackColor = true;
            this.btnRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click);
            // 
            // btnGetAll
            // 
            this.btnGetAll.Location = new System.Drawing.Point(6, 257);
            this.btnGetAll.Name = "btnGetAll";
            this.btnGetAll.Size = new System.Drawing.Size(93, 106);
            this.btnGetAll.TabIndex = 7;
            this.btnGetAll.Text = "Get All";
            this.btnGetAll.UseVisualStyleBackColor = true;
            this.btnGetAll.Click += new System.EventHandler(this.btnGetAll_Click);
            // 
            // btnSetAll
            // 
            this.btnSetAll.Location = new System.Drawing.Point(6, 145);
            this.btnSetAll.Name = "btnSetAll";
            this.btnSetAll.Size = new System.Drawing.Size(93, 106);
            this.btnSetAll.TabIndex = 6;
            this.btnSetAll.Text = "Set All";
            this.btnSetAll.UseVisualStyleBackColor = true;
            this.btnSetAll.Click += new System.EventHandler(this.btnSetAll_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnRemoveOne);
            this.groupBox2.Controls.Add(this.tbStatus);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(124, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(288, 607);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // tbStatus
            // 
            this.tbStatus.Location = new System.Drawing.Point(6, 98);
            this.tbStatus.Multiline = true;
            this.tbStatus.Name = "tbStatus";
            this.tbStatus.ReadOnly = true;
            this.tbStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbStatus.Size = new System.Drawing.Size(276, 41);
            this.tbStatus.TabIndex = 9;
            // 
            // listBoxReaderCAPK
            // 
            this.listBoxReaderCAPK.FormattingEnabled = true;
            this.listBoxReaderCAPK.ItemHeight = 12;
            this.listBoxReaderCAPK.Location = new System.Drawing.Point(418, 369);
            this.listBoxReaderCAPK.Name = "listBoxReaderCAPK";
            this.listBoxReaderCAPK.Size = new System.Drawing.Size(195, 232);
            this.listBoxReaderCAPK.TabIndex = 8;
            this.listBoxReaderCAPK.SelectedIndexChanged += new System.EventHandler(this.listBoxReaderCAPK_SelectedIndexChanged);
            // 
            // btnRemoveOne
            // 
            this.btnRemoveOne.Location = new System.Drawing.Point(229, 369);
            this.btnRemoveOne.Name = "btnRemoveOne";
            this.btnRemoveOne.Size = new System.Drawing.Size(53, 47);
            this.btnRemoveOne.TabIndex = 10;
            this.btnRemoveOne.Text = "-";
            this.btnRemoveOne.UseVisualStyleBackColor = true;
            this.btnRemoveOne.Click += new System.EventHandler(this.btnRemoveOne_Click);
            // 
            // CapkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1175, 607);
            this.Controls.Add(this.listBoxReaderCAPK);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listBoxCAPK);
            this.Controls.Add(this.dataGridViewCAPK);
            this.Name = "CapkForm";
            this.Text = "CapkForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCAPK)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewCAPK;
        private System.Windows.Forms.ListBox listBoxCAPK;
        private System.Windows.Forms.Button btnOpenCAPK;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnRemoveAll;
        private System.Windows.Forms.Button btnGetAll;
        private System.Windows.Forms.Button btnSetAll;
        private System.Windows.Forms.ListBox listBoxReaderCAPK;
        private System.Windows.Forms.TextBox tbStatus;
        private System.Windows.Forms.Button btnRemoveOne;
    }
}