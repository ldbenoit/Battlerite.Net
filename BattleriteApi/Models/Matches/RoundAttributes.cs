using Newtonsoft.Json;

namespace Rocket.Battlerite
{
    public partial class RoundAttributes : IAttributes
    {
        [JsonProperty("duration")]
        public int Duration { get; set; }

        [JsonProperty("ordinal")]
        public long Ordinal { get; set; }

        [JsonProperty("stats")]
        public RoundStats Stats { get; set; }
    }
}