using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Rocket.Battlerite.Converters;

namespace Rocket.Battlerite
{
    public partial class MatchFinishedEvent : ITelemetryObject
    { 
        [JsonProperty("time")]
        [JsonConverter(typeof(EpochMsConverter))]
        public DateTime Time { get; set; }

        [JsonProperty("teamOneScore")]
        public int TeamOneScore { get; set; }

        [JsonProperty("teamTwoScore")]
        public int TeamTwoScore { get; set; }

        [JsonProperty("matchLength")]
        public int MatchLength { get; set; }

        [JsonProperty("matchID")]
        public string MatchId { get; set; }

        [JsonProperty("externalMatchID")]
        public string ExternalMatchId { get; set; }

        [JsonProperty("leavers")]
        public List<string> Leavers { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }
    }
}