using System.Collections.Generic;
using Newtonsoft.Json;

namespace Rocket.Battlerite
{
    public partial class PlayerAttributes : IAttributes
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("patchVersion")]
        public string PatchVersion { get; set; }

        [JsonProperty("shardId")]
        public string ShardId { get; set; }

        [JsonProperty("titleId")]
        public string TitleId { get; set; }

        [JsonProperty("stats")]
        public Dictionary<string, long> Stats { get; set; }
    }
}