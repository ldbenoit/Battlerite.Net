using Newtonsoft.Json;

namespace Rocket.Battlerite
{
    public partial class ResponseLink
    {
        [JsonProperty("schema")]
        public string Schema { get; set; }

        [JsonProperty("next")]
        public string Next { get; set; }

        [JsonProperty("self")]
        public string Self { get; set; }
    }
}