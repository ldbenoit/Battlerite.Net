using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Rocket.Battlerite.Converters;

namespace Rocket.Battlerite
{
    public partial class MatchStart : ITelemetryObject
    { 
        [JsonProperty("time")]
        [JsonConverter(typeof(EpochMsConverter))]
        public DateTime Time { get; set; }

        [JsonProperty("matchID")]
        public string MatchId { get; set; }

        [JsonProperty("externalMatchID")]
        public string ExternalMatchId { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("type")]
        public ServerType Type { get; set; }

        [JsonProperty("gameMode")]
        public long GameMode { get; set; }

        [JsonProperty("mapID")]
        public string MapId { get; set; }

        [JsonProperty("teamSize")]
        public int TeamSize { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }
    }
}