using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace OBD2_Display
{
    public partial class Form1 : Form
    {

        public SerialHandler serialHandler;
        public Chart chart;

        public Form1()
        {
            InitializeComponent();

            serialHandler = new SerialHandler(this, "COM4", 115200);
            serialHandler.Start();
        }

        private void Form1_FormClosing(Object sender, FormClosingEventArgs e)
        {
            serialHandler.Stop();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ChartArea chartArea = new ChartArea();
            Legend legend = new Legend();
            chart = new Chart();
            ((ISupportInitialize)(chart)).BeginInit();

            chartArea.Name = "ChartArea";
            chart.ChartAreas.Add(chartArea);
            chart.Dock = DockStyle.Bottom;

            legend.Name = "Legend";
            chart.Legends.Add(legend);
            chart.Location = new Point(0, 0);
            chart.Name = "chart";
            chart.Size = new Size(284, 600);
            chart.TabIndex = 0;
            chart.Text = "chart";


            chart.Series.Clear();
            Series series1 = new Series
            {
                Name = "Light",
                Color = Color.Yellow,
                IsVisibleInLegend = false,
                IsXValueIndexed = true,
                BorderWidth = 3,
                ChartType = SeriesChartType.Line
            };
            chart.Series.Add(series1);

            Series series2 = new Series
            {
                Name = "ChangeInLight",
                Color = Color.Red,
                IsVisibleInLegend = false,
                IsXValueIndexed = true,
                BorderWidth = 2,
                ChartType = SeriesChartType.Line
            };
            chart.Series.Add(series2);

            chart.Invalidate();

            this.Controls.Add(chart);
        }

        private void maxPointsSelector_ValueChanged(object sender, EventArgs e)
        {
            var value = (int) ((NumericUpDown)sender).Value;
            serialHandler.maxPoints = value;
        }
    }
}
