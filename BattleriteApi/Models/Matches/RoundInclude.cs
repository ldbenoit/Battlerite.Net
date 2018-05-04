using Newtonsoft.Json;

namespace Rocket.Battlerite
{
    public partial class RoundInclude : IInclude
    {
        [JsonProperty("type")]
        public AssetType Type { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("attributes")]
        public RoundAttributes Attributes { get; set; }
    }
}