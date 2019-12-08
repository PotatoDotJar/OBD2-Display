using Newtonsoft.Json;

namespace OBD2_Display
{
    public class TestData
    {
        [JsonProperty("time")]
        public float Time { get; set; }

        [JsonProperty("rpm")]
        public int RPM { get; set; }

    }
}