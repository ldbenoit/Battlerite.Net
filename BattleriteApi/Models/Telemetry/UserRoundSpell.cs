using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Rocket.Battlerite.Converters;

namespace Rocket.Battlerite
{
    public partial class UserRoundSpell : ITelemetryObject
    { 
        [JsonProperty("time")]
        [JsonConverter(typeof(EpochMsConverter))]
        public DateTime Time { get; set; }

        [JsonProperty("accountId")]
        public string AccountId { get; set; }

        [JsonProperty("matchId")]
        public string MatchId { get; set; }

        [JsonProperty("round")]
        public int Round { get; set; }

        [JsonProperty("character")]
        public long Character { get; set; }

        [JsonProperty("typeId")]
        public long TypeId { get; set; }

        [JsonProperty("sourceTypeId")]
        public long SourceTypeId { get; set; }

        [JsonProperty("scoreType")]
        public string ScoreType { get; set; }

        [JsonProperty("value")]
        public int Value { get; set; }
    }
}