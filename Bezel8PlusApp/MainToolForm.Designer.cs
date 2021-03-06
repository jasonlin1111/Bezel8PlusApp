﻿namespace Bezel8PlusApp
{
    partial class MainToolForm
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
            this.tabCrlTool = new System.Windows.Forms.TabControl();
            this.tabTlvParser = new System.Windows.Forms.TabPage();
            this.tabConverter = new System.Windows.Forms.TabPage();
            this.tabCrlTool.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabCrlTool
            // 
            this.tabCrlTool.Controls.Add(this.tabTlvParser);
            this.tabCrlTool.Controls.Add(this.tabConverter);
            this.tabCrlTool.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCrlTool.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold);
            this.tabCrlTool.ItemSize = new System.Drawing.Size(75, 35);
            this.tabCrlTool.Location = new System.Drawing.Point(0, 0);
            this.tabCrlTool.Name = "tabCrlTool";
            this.tabCrlTool.SelectedIndex = 0;
            this.tabCrlTool.Size = new System.Drawing.Size(800, 450);
            this.tabCrlTool.TabIndex = 0;
            // 
            // tabTlvParser
            // 
            this.tabTlvParser.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold);
            this.tabTlvParser.Location = new System.Drawing.Point(4, 39);
            this.tabTlvParser.Name = "tabTlvParser";
            this.tabTlvParser.Padding = new System.Windows.Forms.Padding(3);
            this.tabTlvParser.Size = new System.Drawing.Size(792, 407);
            this.tabTlvParser.TabIndex = 0;
            this.tabTlvParser.Text = "TLV Parser";
            this.tabTlvParser.UseVisualStyleBackColor = true;
            // 
            // tabConverter
            // 
            this.tabConverter.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold);
            this.tabConverter.Location = new System.Drawing.Point(4, 39);
            this.tabConverter.Name = "tabConverter";
            this.tabConverter.Padding = new System.Windows.Forms.Padding(3);
            this.tabConverter.Size = new System.Drawing.Size(792, 407);
            this.tabConverter.TabIndex = 1;
            this.tabConverter.Text = "Converter";
            this.tabConverter.UseVisualStyleBackColor = true;
            // 
            // MainToolForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabCrlTool);
            this.Name = "MainToolForm";
            this.Text = "MainToolForm";
            this.tabCrlTool.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabCrlTool;
        private System.Windows.Forms.TabPage tabTlvParser;
        private System.Windows.Forms.TabPage tabConverter;
    }
}