using System;
using Newtonsoft.Json;
using Rocket.Battlerite.Converters;

namespace Rocket.Battlerite
{
    public partial class BattleritePickEvent : ITelemetryObject
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
        public long Round { get; set; }

        [JsonProperty("character")]
        public long Character { get; set; }

        [JsonProperty("serverType")]
        public ServerType ServerType { get; set; }

        [JsonProperty("loadoutType")]
        public string LoadoutType { get; set; }

        [JsonProperty("battleriteType")]
        public long BattleriteType { get; set; }
    }
}