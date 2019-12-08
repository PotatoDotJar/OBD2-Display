using MathNet.Numerics.Interpolation;
using MathNet.Numerics.LinearAlgebra.Complex;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Threading;

namespace OBD2_Display
{
    public class SerialHandler
    {
        public bool readActive;
        public SerialPort serialPort;
        public Thread readThread;
        public Form1 form;

        public int maxPoints { get; set; }

        public SerialHandler(Form1 form, string portName, int baudRate)
        {
            this.form = form;
            serialPort = new SerialPort();

            readThread = new Thread(ReadPort);
            readThread.IsBackground = true; // Run as BG thread

            serialPort.PortName = portName;
            serialPort.BaudRate = baudRate;
            serialPort.ReadTimeout = 500;
            serialPort.WriteTimeout = 500;


            maxPoints = 50;
        }

        public void ReadPort()
        {
            serialPort.ReadLine();  // Read first line to purge stream
            while (readActive)
            {
                try
                {
                    string message = serialPort.ReadLine();

                    // Deserializing JSON data
                    var jsonModel = JsonConvert.DeserializeObject<TestData>(message);

                    // Thread safe
                    try
                    {
                        form.Invoke(new Action(() =>
                        {
                            form.series.Points.AddXY(Math.Round(jsonModel.Time, 2), jsonModel.RPM);

                            // Remove Points overflow; added to handle maxPoints change
                            while (form.series.Points.Count - maxPoints >= 1)
                            {
                                form.series.Points.RemoveAt(0);
                            }

                            form.chart.ChartAreas[0].RecalculateAxesScale();

                            // Label Updates
                            form.ptCount.Text = form.series.Points.Count.ToString() + " points";


                            // Average Value
                            double total = 0;
                            foreach (var pt in form.series.Points)
                            {
                                total += pt.YValues[0];
                            }

                            form.avg.Text = Math.Round((total / form.series.Points.Count), 3).ToString();

                            if (form.series.Points.Count >= 2)
                            {
                                // Testing some stuff I learned in calculus 1
                                var xPts = new List<double>();
                                var yPts = new List<double>();

                                var points = form.series.Points;

                                foreach (var pt in points)
                                {
                                    xPts.Add(pt.XValue);
                                    yPts.Add(pt.YValues[0]);
                                }

                                var cs = CubicSpline.InterpolateNatural(xPts, yPts);

                                var x = new DenseVector(15);
                                var y = new DenseVector(x.Count);
                                var dydx = new DenseVector(x.Count);
                                for (int i = 0; i < x.Count; i++)
                                {
                                    x[i] = (4.0 * i) / (x.Count - 1);
                                    y[i] = cs.Interpolate(x[i]);
                                    dydx[i] = cs.Differentiate(x[i]);
                                }
                            }
                        }));
                    }
                    catch (InvalidAsynchronousStateException e)
                    {
                        // Kill the thread
                        readActive = false;
                    }
                    catch (ObjectDisposedException e)
                    {
                        // Kill the thread
                        readActive = false;
                    }

                }
                catch (TimeoutException e) { }
                catch (JsonException ex) { }
            }

            serialPort.Close();
        }

        public void Start()
        {
            serialPort.Open();
            readActive = true;
            readThread.Start();
        }

        public void Stop()
        {
            // Stop the serial thread
            readActive = false;
        }
    }
}
