namespace OBD2_Display
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.lblTime = new System.Windows.Forms.Label();
            this.valTime = new System.Windows.Forms.Label();
            this.chartTemp = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartLight = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.numMaxPoints = new System.Windows.Forms.NumericUpDown();
            this.labelMaxpoints = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartTemp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartLight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxPoints)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(13, 13);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(73, 13);
            this.lblTime.TabIndex = 0;
            this.lblTime.Text = "Current Time: ";
            // 
            // valTime
            // 
            this.valTime.AutoSize = true;
            this.valTime.Location = new System.Drawing.Point(93, 13);
            this.valTime.Name = "valTime";
            this.valTime.Size = new System.Drawing.Size(27, 13);
            this.valTime.TabIndex = 1;
            this.valTime.Text = "N/A";
            // 
            // chartTemp
            // 
            chartArea1.AxisX.Title = "Time (ms)";
            chartArea1.AxisY.Title = "Analog Value";
            chartArea1.Name = "ChartArea1";
            this.chartTemp.ChartAreas.Add(chartArea1);
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.chartTemp.Legends.Add(legend1);
            this.chartTemp.Location = new System.Drawing.Point(12, 306);
            this.chartTemp.Name = "chartTemp";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "seriesTemp";
            this.chartTemp.Series.Add(series1);
            this.chartTemp.Size = new System.Drawing.Size(776, 244);
            this.chartTemp.TabIndex = 2;
            this.chartTemp.Text = "chart1";
            title1.Name = "Title1";
            title1.Text = "Temperature";
            this.chartTemp.Titles.Add(title1);
            // 
            // chartLight
            // 
            chartArea2.AxisX.Title = "Time (ms)";
            chartArea2.AxisY.Title = "Analog Value";
            chartArea2.Name = "ChartArea1";
            this.chartLight.ChartAreas.Add(chartArea2);
            legend2.Enabled = false;
            legend2.Name = "Legend1";
            this.chartLight.Legends.Add(legend2);
            this.chartLight.Location = new System.Drawing.Point(12, 56);
            this.chartLight.Name = "chartLight";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "seriesLight";
            this.chartLight.Series.Add(series2);
            this.chartLight.Size = new System.Drawing.Size(776, 244);
            this.chartLight.TabIndex = 3;
            this.chartLight.Text = "chart1";
            title2.Name = "Title1";
            title2.Text = "Light";
            this.chartLight.Titles.Add(title2);
            // 
            // numMaxPoints
            // 
            this.numMaxPoints.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numMaxPoints.Location = new System.Drawing.Point(96, 30);
            this.numMaxPoints.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.numMaxPoints.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMaxPoints.Name = "numMaxPoints";
            this.numMaxPoints.Size = new System.Drawing.Size(120, 20);
            this.numMaxPoints.TabIndex = 4;
            this.numMaxPoints.ThousandsSeparator = true;
            this.numMaxPoints.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMaxPoints.ValueChanged += new System.EventHandler(this.numMaxPoints_ValueChanged);
            // 
            // labelMaxpoints
            // 
            this.labelMaxpoints.AutoSize = true;
            this.labelMaxpoints.Location = new System.Drawing.Point(13, 32);
            this.labelMaxpoints.Name = "labelMaxpoints";
            this.labelMaxpoints.Size = new System.Drawing.Size(62, 13);
            this.labelMaxpoints.TabIndex = 5;
            this.labelMaxpoints.Text = "Max Points:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 562);
            this.Controls.Add(this.labelMaxpoints);
            this.Controls.Add(this.numMaxPoints);
            this.Controls.Add(this.chartLight);
            this.Controls.Add(this.chartTemp);
            this.Controls.Add(this.valTime);
            this.Controls.Add(this.lblTime);
            this.Name = "Form1";
            this.Text = "OBD2 Display - Beta";
            ((System.ComponentModel.ISupportInitialize)(this.chartTemp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartLight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxPoints)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label valTime;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTemp;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartLight;
        private System.Windows.Forms.NumericUpDown numMaxPoints;
        private System.Windows.Forms.Label labelMaxpoints;
    }
}

