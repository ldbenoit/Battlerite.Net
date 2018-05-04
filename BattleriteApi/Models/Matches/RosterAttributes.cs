using Newtonsoft.Json;

namespace Rocket.Battlerite
{
    public partial class RosterAttributes : IAttributes
    {
        [JsonProperty("shardId")]
        public string ShardId { get; set; }

        [JsonProperty("stats")]
        public RosterStats Stats { get; set; }

        [JsonProperty("won")]
        public bool Won { get; set; }
    }

}