using Newtonsoft.Json;

namespace Rocket.Battlerite
{
    public partial class ParticipantAttributes : IAttributes
    {
        [JsonProperty("actor")]
        public string Actor { get; set; }

        [JsonProperty("shardId")]
        public string ShardId { get; set; }

        [JsonProperty("stats")]
        public ParticipantStats Stats { get; set; }
    }
}