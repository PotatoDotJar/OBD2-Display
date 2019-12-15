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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title4 = new System.Windows.Forms.DataVisualization.Charting.Title();
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
            this.lblTime.Location = new System.Drawing.Point(20, 20);
            this.lblTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(108, 20);
            this.lblTime.TabIndex = 0;
            this.lblTime.Text = "Current Time: ";
            // 
            // valTime
            // 
            this.valTime.AutoSize = true;
            this.valTime.Location = new System.Drawing.Point(140, 20);
            this.valTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.valTime.Name = "valTime";
            this.valTime.Size = new System.Drawing.Size(35, 20);
            this.valTime.TabIndex = 1;
            this.valTime.Text = "N/A";
            // 
            // chartTemp
            // 
            chartArea3.AxisX.Title = "Time (ms)";
            chartArea3.AxisY.Title = "Analog Value";
            chartArea3.Name = "ChartArea1";
            this.chartTemp.ChartAreas.Add(chartArea3);
            legend3.Enabled = false;
            legend3.Name = "Legend1";
            this.chartTemp.Legends.Add(legend3);
            this.chartTemp.Location = new System.Drawing.Point(18, 471);
            this.chartTemp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chartTemp.Name = "chartTemp";
            series3.BorderWidth = 2;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Color = System.Drawing.Color.Red;
            series3.Legend = "Legend1";
            series3.Name = "seriesTemp";
            this.chartTemp.Series.Add(series3);
            this.chartTemp.Size = new System.Drawing.Size(1164, 375);
            this.chartTemp.TabIndex = 2;
            this.chartTemp.Text = "chart1";
            title3.Name = "Title1";
            title3.Text = "Temperature";
            this.chartTemp.Titles.Add(title3);
            // 
            // chartLight
            // 
            chartArea4.AxisX.Title = "Time (ms)";
            chartArea4.AxisY.Title = "Analog Value";
            chartArea4.Name = "ChartArea1";
            this.chartLight.ChartAreas.Add(chartArea4);
            legend4.Enabled = false;
            legend4.Name = "Legend1";
            this.chartLight.Legends.Add(legend4);
            this.chartLight.Location = new System.Drawing.Point(18, 86);
            this.chartLight.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chartLight.Name = "chartLight";
            series4.BorderWidth = 2;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Color = System.Drawing.Color.Lime;
            series4.Legend = "Legend1";
            series4.Name = "seriesLight";
            this.chartLight.Series.Add(series4);
            this.chartLight.Size = new System.Drawing.Size(1164, 375);
            this.chartLight.TabIndex = 3;
            this.chartLight.Text = "chart1";
            title4.Name = "Title1";
            title4.Text = "Light";
            this.chartLight.Titles.Add(title4);
            // 
            // numMaxPoints
            // 
            this.numMaxPoints.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numMaxPoints.Location = new System.Drawing.Point(144, 46);
            this.numMaxPoints.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
            this.numMaxPoints.Size = new System.Drawing.Size(180, 26);
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
            this.labelMaxpoints.Location = new System.Drawing.Point(20, 49);
            this.labelMaxpoints.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMaxpoints.Name = "labelMaxpoints";
            this.labelMaxpoints.Size = new System.Drawing.Size(90, 20);
            this.labelMaxpoints.TabIndex = 5;
            this.labelMaxpoints.Text = "Max Points:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 865);
            this.Controls.Add(this.labelMaxpoints);
            this.Controls.Add(this.numMaxPoints);
            this.Controls.Add(this.chartLight);
            this.Controls.Add(this.chartTemp);
            this.Controls.Add(this.valTime);
            this.Controls.Add(this.lblTime);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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

