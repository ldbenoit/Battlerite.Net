using Newtonsoft.Json;

namespace Rocket.Battlerite
{
    public partial class TeamInclude : IInclude
    {
        [JsonProperty("type")]
        public AssetType Type { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("attributes")]
        public TeamAttributes Attributes { get; set; }

        [JsonProperty("relationships")]
        public Relationships Relationships { get; set; }
    }
}