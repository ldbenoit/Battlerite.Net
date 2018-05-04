using System;
using Newtonsoft.Json;

namespace Rocket.Battlerite
{
    public partial class AssetAttributes : IAttributes
    {
        [JsonProperty("URL")]
        public string Url { get; set; }

        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}