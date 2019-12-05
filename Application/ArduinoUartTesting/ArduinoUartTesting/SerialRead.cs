using ArduinoUartTesting.Models;
using System;
using System.IO.Ports;
using Newtonsoft.Json;
using System.Threading;

namespace ArduinoUartTesting
{
    public class SerialRead
    {

        public bool readActive;
        public SerialPort serialPort;
        public Thread readThread;

        public SerialRead(string portName, int baudRate)
        {
            serialPort = new SerialPort();

            readThread = new Thread(ReadPort);

            serialPort.PortName = portName;
            serialPort.BaudRate = baudRate;
            serialPort.ReadTimeout = 500;
            serialPort.WriteTimeout = 500;



            serialPort.Open();
            readActive = true;
            readThread.Start();
            Console.WriteLine("Read Thread Started! Push ESC to exit.");

            while(Console.ReadKey().Key != ConsoleKey.Escape)
            {

            }

            readActive = false;
            readThread.Join();
            serialPort.Close();

            Console.WriteLine("Press enter to close...");
            Console.ReadLine();
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

                    Console.WriteLine($"{jsonModel}");
                }
                catch (TimeoutException e) { }
                catch (JsonException ex) { }
            }

            serialPort.Close();
        }
    }
}
