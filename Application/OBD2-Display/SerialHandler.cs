using MathNet.Numerics.Interpolation;
using MathNet.Numerics.LinearAlgebra.Double;
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

            while (readActive)
            {

                if (serialPort.BytesToRead > 0)
                {
                    try
                    {
                        string message = serialPort.ReadLine();
                        
                        // Thread safe
                        try
                        {
                            // Deserializing JSON data
                            var jsonModel = JsonConvert.DeserializeObject<TestData>(message);

                            form.Invoke(new Action(() =>
                            {
                                var series1 = form.chart.Series[0];
                                var series2 = form.chart.Series[1];


                                series1.Points.AddXY(Math.Round(jsonModel.Time, 2), jsonModel.RPM);

                                // Remove Points overflow; added to handle maxPoints change
                                while (series1.Points.Count - maxPoints >= 1)
                                {
                                    series1.Points.RemoveAt(0);
                                }

                                // Label Updates
                                form.ptCount.Text = series1.Points.Count.ToString() + " points";


                                if (series1.Points.Count >= 2)
                                {
                                    // Testing some stuff I learned in calculus 1
                                    var xPtsList = new List<double>();
                                    var yPtsList = new List<double>();

                                    var points = series1.Points;

                                    foreach (var pt in points)
                                    {
                                        xPtsList.Add(pt.XValue);
                                        yPtsList.Add(pt.YValues[0]);
                                    }

                                    // Testing some stuff I learned in calculus 1
                                    var xPts = new DenseVector(xPtsList.ToArray());
                                    var yPts = new DenseVector(yPtsList.ToArray());


                                    var cs = CubicSpline.InterpolateNatural(xPts, yPts);


                                    series2.Points.AddXY(Math.Round(jsonModel.Time, 2), cs.Differentiate(Math.Round(jsonModel.Time, 2)));

                                    // Remove Points overflow; added to handle maxPoints change
                                    while (series2.Points.Count - maxPoints >= 1)
                                    {
                                        series2.Points.RemoveAt(0);
                                    }

                                    //var x = new DenseVector(xPts.Count);
                                    //var y = new DenseVector(x.Count);
                                    //var dydx = new DenseVector(x.Count);
                                    //for (int i = 0; i < x.Count; i++)
                                    //{
                                    //    x[i] = (4.0 * i) / (x.Count - 1);
                                    //    y[i] = cs.Interpolate(x[i]);
                                    //    dydx[i] = cs.Differentiate(x[i]);
                                    //    Console.WriteLine($"{x[i],12:G5} {y[i],12:G5} {dydx[i],12:G5}");
                                    //}
                                }
                                else
                                {
                                    series2.Points.AddXY(Math.Round(jsonModel.Time, 2), 0);


                                    // Remove Points overflow; added to handle maxPoints change
                                    while (series2.Points.Count - maxPoints >= 1)
                                    {
                                        series2.Points.RemoveAt(0);
                                    }
                                }


                                //form.chart.ChartAreas[0].RecalculateAxesScale();
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
