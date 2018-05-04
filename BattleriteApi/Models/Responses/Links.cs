using Newtonsoft.Json;

namespace Rocket.Battlerite
{
    
    public partial class Links
    {
        [JsonProperty("schema")]
        public string Schema { get; set; }

        [JsonProperty("self")]
        public string Self { get; set; }
    }
}