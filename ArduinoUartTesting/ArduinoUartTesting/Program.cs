
namespace ArduinoUartTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            // Start reader
            SerialRead serialRead = new SerialRead("COM4", 115200);
        }
    }
}

