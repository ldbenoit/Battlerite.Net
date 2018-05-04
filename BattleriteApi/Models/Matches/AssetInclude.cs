using System;
using Newtonsoft.Json;

namespace Rocket.Battlerite
{
    public partial class AssetInclude : IInclude
    {
        [JsonProperty("type")]
        public AssetType Type { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("attributes")]
        public AssetAttributes Attributes { get; set; }
    }
}