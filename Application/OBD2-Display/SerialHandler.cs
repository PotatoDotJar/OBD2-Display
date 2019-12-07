using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace OBD2_Display
{
    public class SerialHandler
    {
        public bool readActive;
        public SerialPort serialPort;
        public Thread readThread;
        public Form1 form;

        //public int maxPoints = 50;

        public SerialHandler(Form1 form, string portName, int baudRate)
        {
            this.form = form;
            serialPort = new SerialPort();

            readThread = new Thread(ReadPort);
            readThread.IsBackground = true;

            serialPort.PortName = portName;
            serialPort.BaudRate = baudRate;
            serialPort.ReadTimeout = 500;
            serialPort.WriteTimeout = 500;

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
                        form.chart.Invoke(new Action(() =>
                        {
                            form.series.Points.AddXY(jsonModel.Time, jsonModel.RPM);
                            
                            if(form.series.Points.Count > 200)
                            {
                                form.series.Points.RemoveAt(0);
                            }

                            form.chart.ChartAreas[0].RecalculateAxesScale();
                        }));
                    }
                    catch (InvalidAsynchronousStateException e)
                    {
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
