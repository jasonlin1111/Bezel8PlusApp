namespace Bezel8PlusApp
{
    partial class MainConfigForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpConfig = new System.Windows.Forms.TabPage();
            this.tpCAPK = new System.Windows.Forms.TabPage();
            this.tpDRL = new System.Windows.Forms.TabPage();
            this.tpTime = new System.Windows.Forms.TabPage();
            this.tpParameter = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpParameter);
            this.tabControl1.Controls.Add(this.tpDRL);
            this.tabControl1.Controls.Add(this.tpCAPK);
            this.tabControl1.Controls.Add(this.tpConfig);
            this.tabControl1.Controls.Add(this.tpTime);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(500, 35);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(671, 315);
            this.tabControl1.TabIndex = 0;
            // 
            // tpConfig
            // 
            this.tpConfig.BackColor = System.Drawing.Color.Transparent;
            this.tpConfig.Location = new System.Drawing.Point(4, 39);
            this.tpConfig.Name = "tpConfig";
            this.tpConfig.Padding = new System.Windows.Forms.Padding(3);
            this.tpConfig.Size = new System.Drawing.Size(663, 272);
            this.tpConfig.TabIndex = 0;
            this.tpConfig.Text = "Terminal & Application";
            // 
            // tpCAPK
            // 
            this.tpCAPK.AutoScroll = true;
            this.tpCAPK.Location = new System.Drawing.Point(4, 39);
            this.tpCAPK.Name = "tpCAPK";
            this.tpCAPK.Padding = new System.Windows.Forms.Padding(3);
            this.tpCAPK.Size = new System.Drawing.Size(663, 272);
            this.tpCAPK.TabIndex = 2;
            this.tpCAPK.Text = "CA Keys";
            this.tpCAPK.UseVisualStyleBackColor = true;
            // 
            // tpDRL
            // 
            this.tpDRL.Location = new System.Drawing.Point(4, 39);
            this.tpDRL.Name = "tpDRL";
            this.tpDRL.Padding = new System.Windows.Forms.Padding(3);
            this.tpDRL.Size = new System.Drawing.Size(663, 272);
            this.tpDRL.TabIndex = 3;
            this.tpDRL.Text = "DRL";
            this.tpDRL.UseVisualStyleBackColor = true;
            // 
            // tpTime
            // 
            this.tpTime.Location = new System.Drawing.Point(4, 39);
            this.tpTime.Name = "tpTime";
            this.tpTime.Padding = new System.Windows.Forms.Padding(3);
            this.tpTime.Size = new System.Drawing.Size(663, 272);
            this.tpTime.TabIndex = 4;
            this.tpTime.Text = "Time & Exception";
            this.tpTime.UseVisualStyleBackColor = true;
            // 
            // tpParameter
            // 
            this.tpParameter.Location = new System.Drawing.Point(4, 39);
            this.tpParameter.Name = "tpParameter";
            this.tpParameter.Padding = new System.Windows.Forms.Padding(3);
            this.tpParameter.Size = new System.Drawing.Size(663, 272);
            this.tpParameter.TabIndex = 5;
            this.tpParameter.Text = "Parameter Setting";
            this.tpParameter.UseVisualStyleBackColor = true;
            // 
            // MainConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 315);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainConfigForm";
            this.Text = "ConfigForm";
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpConfig;
        private System.Windows.Forms.TabPage tpCAPK;
        private System.Windows.Forms.TabPage tpDRL;
        private System.Windows.Forms.TabPage tpTime;
        private System.Windows.Forms.TabPage tpParameter;
    }
}