﻿namespace OBD2_Display
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.maxPointsSelector = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.maxPointsSelector)).BeginInit();
            this.SuspendLayout();
            // 
            // maxPointsSelector
            // 
            this.maxPointsSelector.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.maxPointsSelector.Location = new System.Drawing.Point(136, 11);
            this.maxPointsSelector.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.maxPointsSelector.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxPointsSelector.Name = "maxPointsSelector";
            this.maxPointsSelector.Size = new System.Drawing.Size(180, 31);
            this.maxPointsSelector.TabIndex = 0;
            this.maxPointsSelector.ThousandsSeparator = true;
            this.maxPointsSelector.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.maxPointsSelector.ValueChanged += new System.EventHandler(this.maxPointsSelector_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Max Points";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1258, 664);
            this.Controls.Add(this.maxPointsSelector);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.maxPointsSelector)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.NumericUpDown maxPointsSelector;
        private System.Windows.Forms.Label label1;
    }
}
