using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Rocket.Battlerite.Converters;

namespace Rocket.Battlerite
{
    public partial class RoundEvent : ITelemetryObject
    { 
        [JsonProperty("time")]
        [JsonConverter(typeof(EpochMsConverter))]
        public DateTime Time { get; set; }

        [JsonProperty("matchID")]
        public string MatchId { get; set; }

        [JsonProperty("externalMatchID")]
        public string ExternalMatchId { get; set; }

        [JsonProperty("userID")]
        public string UserId { get; set; }

        [JsonProperty("round")]
        public int Round { get; set; }

        [JsonProperty("character")]
        public long Character { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("value")]
        public long Value { get; set; }

        [JsonProperty("timeIntoRound")]
        public long TimeIntoRound { get; set; }
    }
}