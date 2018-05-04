using System.Collections.Generic;
using Newtonsoft.Json;

namespace Rocket.Battlerite
{
    public partial class PlayerInclude : IInclude
    {
        [JsonProperty("type")]
        public AssetType Type { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("attributes")]
        public PlayerAttributes Attributes { get; set; }

        [JsonProperty("relationships")]
        public Relationships Relationships { get; set; }

        [JsonProperty("links")]
        public Links Links { get; set; }
    }
}