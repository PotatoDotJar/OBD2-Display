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
        public Series series;
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

            chartArea.Name = "ChartArea1";
            chart.ChartAreas.Add(chartArea);
            chart.Dock = DockStyle.Bottom;

            legend.Name = "Legend1";
            chart.Legends.Add(legend);
            chart.Location = new Point(0, 0);
            chart.Name = "chart";
            chart.Size = new Size(284, 600);
            chart.TabIndex = 0;
            chart.Text = "chart";


            chart.Series.Clear();
            series = new Series
            {
                Name = "Series",
                Color = Color.Green,
                IsVisibleInLegend = true,
                IsXValueIndexed = true,
                BorderWidth = 3,
                ChartType = SeriesChartType.Line
            };
            chart.Series.Add(series);

            chart.Invalidate();

            this.Controls.Add(chart);
        }

        private void maxPointsSelector_ValueChanged(object sender, EventArgs e)
        {
            var sendr = (NumericUpDown) sender;

            //max sendr.Value
        }
    }
}
