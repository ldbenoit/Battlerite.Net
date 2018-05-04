using Newtonsoft.Json;

namespace Rocket.Battlerite
{
    public partial class ParticipantInclude : IInclude
    {
        [JsonProperty("type")]
        public AssetType Type { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("attributes")]
        public ParticipantAttributes Attributes { get; set; }

        [JsonProperty("relationships")]
        public Relationships Relationships { get; set; }
    }
}