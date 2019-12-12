using MathNet.Numerics.Interpolation;
using MathNet.Numerics.LinearAlgebra.Double;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms.DataVisualization.Charting;

namespace OBD2_Display
{
    public class DataPoint
    {
        public double x { get; set; }
        public double y { get; set; }

        public DataPoint(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
    }

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

            DataPointCollection data = new DataPointCollection();

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

                                series1.Points.AddXY(jsonModel.Time, jsonModel.Light);

                                // Remove Points overflow; added to handle maxPoints change
                                while (series1.Points.Count - maxPoints >= 1)
                                {
                                    series1.Points.RemoveAt(0);
                                }

                                // Label Updates
                                form.ptCount.Text = series1.Points.Count.ToString() + " points";




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
