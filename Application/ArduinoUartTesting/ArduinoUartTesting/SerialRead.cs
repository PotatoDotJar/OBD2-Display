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
            serialPort.ReadTimeout = 15000;
            serialPort.WriteTimeout = 500;
            serialPort.NewLine = "\n";



            serialPort.Open();
            readActive = true;
            readThread.Start();
            Console.WriteLine("Read Thread Started! Push ESC to exit.");

            string[] command;
            bool quitNow = false;
            while (!quitNow)
            {
                command = Console.ReadLine().Split(' ');

                if (command.Length > 4)
                {

                    string mode = command[0];
                    int v1 = int.Parse(command[1].Trim());
                    int v2 = int.Parse(command[2].Trim());
                    int v3 = int.Parse(command[3].Trim());

                    switch (mode)
                    {
                        case "led":

                            SendPort(new SendPacket(mode, v1, v2, v3));
                            break;

                        case "/quit":
                            quitNow = true;
                            break;

                        default:
                            Console.WriteLine("Unknown Command " + command);
                            break;
                    }
                }
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
                    // Deserializing JSON data
                    var testData = JsonConvert.DeserializeObject<TestData>(serialPort.ReadLine());
                    
                    Console.WriteLine($"{testData.TimeMilliseconds, 12}{testData.Temp, 12}{testData.Light, 12}{testData.Aux,12}");

                }
                catch (TimeoutException e) { }
                catch (JsonException ex) { }
            }

            serialPort.Close();
        }

        public void SendPort(SendPacket packet)
        {
            if(serialPort.IsOpen)
            {
                serialPort.WriteLine(JsonConvert.SerializeObject(packet));
                
            }
        }
    }
}
