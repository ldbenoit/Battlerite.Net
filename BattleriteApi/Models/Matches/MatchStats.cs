using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Rocket.Battlerite
{
    public partial class MatchStats
    {
        [JsonProperty("mapID")]
        public string MapId { get; set; }

        [JsonProperty("type")]
        public MatchType Type { get; set; }
    }
}