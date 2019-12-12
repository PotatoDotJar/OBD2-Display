using Newtonsoft.Json;

namespace OBD2_Display
{
    public class TestData
    {
        [JsonProperty("time_millis")]
        public long Time { get; set; }

        [JsonProperty("temp")]
        public int Temp { get; set; }

        [JsonProperty("light")]
        public int Light { get; set; }

        [JsonProperty("aux")]
        public int Aux { get; set; }

    }
}