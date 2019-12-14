

using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO.Ports;
using System.Threading;

namespace OBD2_Display
{
    public class SerialController
    {
        public bool readActive;
        public SerialPort serialPort;
        public Thread readThread;

        public delegate void SerialRecive(ArduinoPacket arduinoPacket);
        public SerialRecive OnSerialRecive;

        public SerialController(string portName, int baudRate)
        {
            serialPort = new SerialPort();

            readThread = new Thread(ReadPort);
            readThread.IsBackground = true; // Run as BG thread

            serialPort.PortName = portName;
            serialPort.BaudRate = baudRate;
            serialPort.ReadTimeout = 30000;
            serialPort.WriteTimeout = 500;

            OnSerialRecive = null;
        }


        public void ReadPort()
        {
            while (readActive)
            {

                if (serialPort.BytesToRead > 0)
                {
                    try
                    {
                        // Deserializing JSON data
                        var packet = JsonConvert.DeserializeObject<ArduinoPacket>(serialPort.ReadLine());
                        OnSerialRecive.Invoke(packet);
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

    public class ArduinoPacket
    {
        [JsonProperty("time_millis")]
        public long TimeMillis { get; set; }

        [JsonProperty("temp")]
        public int Temp { get; set; }

        [JsonProperty("light")]
        public int Light { get; set; }

        [JsonProperty("aux")]
        public int Aux { get; set; }
    }
}
