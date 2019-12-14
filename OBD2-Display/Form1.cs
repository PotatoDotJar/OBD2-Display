using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OBD2_Display
{
    public partial class Form1 : Form
    {

        public SerialController serialController;
        private int maxPoints = 200;

        public Form1()
        {
            InitializeComponent();

            numMaxPoints.Value = maxPoints; // Set default or maybe use a settings file? Nah!

            serialController = new SerialController("COM6", 115200);    // Create serial port

            serialController.Start();   // Start serial port thread

            serialController.OnSerialRecive += DataRecived; // "Subscribe" to the serial read thread! Also #youtubeisdead
        }

        public void DataRecived(ArduinoPacket packet)
        {
            //Debug.WriteLine($"{packet.TimeMillis,12} | {packet.Light,12} | {packet.Temp,12}");

            // Make this thread safe? All these damn threads make things so complicated!
            valTime.Invoke(new Action(() => {
                valTime.Text = packet.TimeMillis.ToString();    // Set time value on data recived
            }));

            // Chart light update
            chartLight.Invoke(new Action(() => {
                var chart = chartLight;
                var points = chart.Series[0].Points;

                // Add new datapoint
                points.AddXY(packet.TimeMillis, packet.Light);

                // Remove Points overflow; added to handle maxPoints change
                while (points.Count - maxPoints >= 1)
                {
                    points.RemoveAt(0);
                }

                // Recalculate bounds
                chart.ChartAreas[0].RecalculateAxesScale();

            }));
            // End Chart light update

            // Chart temp update
            chartTemp.Invoke(new Action(() => {
                var chart = chartTemp;
                var points = chart.Series[0].Points;

                // Add new datapoint
                points.AddXY(packet.TimeMillis, packet.Temp);

                // Remove Points overflow; added to handle maxPoints change
                while (points.Count - maxPoints >= 1)
                {
                    points.RemoveAt(0);
                }

                // Recalculate bounds
                chart.ChartAreas[0].RecalculateAxesScale();

            }));
            // End Chart temp update


        }

        private void numMaxPoints_ValueChanged(object sender, EventArgs e)
        {
            maxPoints = (int)((NumericUpDown)sender).Value;
        }
    }
}
