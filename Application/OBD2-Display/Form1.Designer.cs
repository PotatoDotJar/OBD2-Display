namespace OBD2_Display
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
            this.labelPtCount = new System.Windows.Forms.Label();
            this.ptCount = new System.Windows.Forms.Label();
            this.labelAvg = new System.Windows.Forms.Label();
            this.avg = new System.Windows.Forms.Label();
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
            // labelPtCount
            // 
            this.labelPtCount.AutoSize = true;
            this.labelPtCount.Location = new System.Drawing.Point(322, 13);
            this.labelPtCount.Name = "labelPtCount";
            this.labelPtCount.Size = new System.Drawing.Size(109, 25);
            this.labelPtCount.TabIndex = 2;
            this.labelPtCount.Text = "Point Count:";
            // 
            // ptCount
            // 
            this.ptCount.AutoSize = true;
            this.ptCount.Location = new System.Drawing.Point(428, 13);
            this.ptCount.Name = "ptCount";
            this.ptCount.Size = new System.Drawing.Size(44, 25);
            this.ptCount.TabIndex = 3;
            this.ptCount.Text = "N/A";
            // 
            // labelAvg
            // 
            this.labelAvg.AutoSize = true;
            this.labelAvg.Location = new System.Drawing.Point(614, 13);
            this.labelAvg.Name = "labelAvg";
            this.labelAvg.Size = new System.Drawing.Size(81, 25);
            this.labelAvg.TabIndex = 2;
            this.labelAvg.Text = "Average:";
            // 
            // avg
            // 
            this.avg.AutoSize = true;
            this.avg.Location = new System.Drawing.Point(701, 13);
            this.avg.Name = "avg";
            this.avg.Size = new System.Drawing.Size(44, 25);
            this.avg.TabIndex = 3;
            this.avg.Text = "N/A";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1258, 664);
            this.Controls.Add(this.avg);
            this.Controls.Add(this.labelAvg);
            this.Controls.Add(this.ptCount);
            this.Controls.Add(this.labelPtCount);
            this.Controls.Add(this.maxPointsSelector);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OBD2 Display - Beta";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.maxPointsSelector)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.NumericUpDown maxPointsSelector;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelPtCount;
        public System.Windows.Forms.Label ptCount;
        private System.Windows.Forms.Label labelAvg;
        public System.Windows.Forms.Label avg;
    }
}

