using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Rocket.Battlerite
{
    public partial class MatchData
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("attributes")]
        public MatchAttribute Attributes { get; set; }

        [JsonProperty("relationships")]
        public Relationships Relationships { get; set; }

        [JsonProperty("links")]
        public Links Links { get; set; }

        [JsonIgnore]
        public string TelemetryUrl { get; set; }
        [JsonIgnore]
        public TelemetryResponse Telemetry { get; set; }
        [JsonIgnore]
        public IList<PlayerMatchInfo> Players { get; set; } = new List<PlayerMatchInfo>();
        [JsonIgnore]
        public IList<RoundAttributes> Rounds { get; set; } = new List<RoundAttributes>();
        [JsonIgnore]
        public IList<TeamMatchInfo> Teams { get; set; } = new List<TeamMatchInfo>();
    }
}