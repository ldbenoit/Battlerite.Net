using Newtonsoft.Json;

namespace Rocket.Battlerite
{
    public partial class PlayerData
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("attributes")]
        public PlayerAttributes Attributes { get; set; }

        [JsonProperty("relationships")]
        public Relationships Relationships { get; set; }

        [JsonProperty("links")]
        public ResponseLink Links { get; set; }
    }
}