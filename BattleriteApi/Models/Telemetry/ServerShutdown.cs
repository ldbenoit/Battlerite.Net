using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Rocket.Battlerite.Converters;

namespace Rocket.Battlerite
{
    public partial class ServerShutdown : ITelemetryObject
    { 
        [JsonProperty("time")]
        [JsonConverter(typeof(EpochMsConverter))]
        public DateTime Time { get; set; }

        [JsonProperty("matchID")]
        public string MatchId { get; set; }

        [JsonProperty("externalMatchID")]
        public string ExternalMatchId { get; set; }

        [JsonProperty("matchTime")]
        public int MatchTime { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }
    }
}