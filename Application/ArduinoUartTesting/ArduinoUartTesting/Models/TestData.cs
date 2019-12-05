using Newtonsoft.Json;

namespace ArduinoUartTesting.Models
{
    public class TestData
    {
        public long Time { get; set; }

        [JsonProperty("r1")]
        public long Rand1 { get; set; }

        [JsonProperty("r2")]
        public long Rand2 { get; set; }

        [JsonProperty("r3")]
        public long Rand3 { get; set; }

        [JsonProperty("r4")]
        public long Rand4 { get; set; }

        public override string ToString()
        {
            return $"[Time]: {Time}\t" +
                $"[Rand1]: {Rand1}\t" +
                $"[Rand2]: {Rand2}\t" +
                $"[Rand3]: {Rand3}\t" +
                $"[Rand4]: {Rand4}";
        }
    }
}
