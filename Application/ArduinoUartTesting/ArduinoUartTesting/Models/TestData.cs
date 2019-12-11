using Newtonsoft.Json;

namespace ArduinoUartTesting.Models
{
    public class TestData
    {
        [JsonProperty("time_millis")]
        public long TimeMilliseconds { get; set; }

        [JsonProperty("temp")]
        public int Temp { get; set; }

        [JsonProperty("light")]
        public int Light { get; set; }

        [JsonProperty("aux")]
        public int Aux { get; set; }
    }

    public class SendPacket
    {
        [JsonProperty("mode")]
        public string Mode { get; set; }

        [JsonProperty("d1")]
        public int D1 { get; set; }

        [JsonProperty("d2")]
        public int D2 { get; set; }

        [JsonProperty("d3")]
        public int D3 { get; set; }


        public SendPacket(string mode, int d1, int d2, int d3)
        {
            this.Mode = mode;
            this.D1 = d1;
            this.D2 = d2;
            this.D3 = d3;
        }
    }
}
