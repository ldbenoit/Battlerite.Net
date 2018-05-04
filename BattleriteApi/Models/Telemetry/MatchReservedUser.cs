using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Rocket.Battlerite.Converters;

namespace Rocket.Battlerite
{
    public partial class MatchReservedUser : ITelemetryObject
    { 
        [JsonProperty("time")]
        [JsonConverter(typeof(EpochMsConverter))]
        public DateTime Time { get; set; }

        [JsonProperty("accountId")]
        public string AccountId { get; set; }

        [JsonProperty("matchId")]
        public string MatchId { get; set; }

        [JsonProperty("serverType")]
        public string ServerType { get; set; }

        [JsonProperty("characterLevel")]
        public int CharacterLevel { get; set; }

        [JsonProperty("teamId")]
        public string TeamId { get; set; }

        [JsonProperty("totalTimePlayed")]
        public long TotalTimePlayed { get; set; }

        [JsonProperty("characterTimePlayed")]
        public long CharacterTimePlayed { get; set; }

        [JsonProperty("character")]
        public long Character { get; set; }

        [JsonProperty("team")]
        public int Team { get; set; }

        [JsonProperty("rankingType")]
        public RankingType RankingType { get; set; }

        [JsonProperty("mount")]
        public long Mount { get; set; }

        [JsonProperty("attachment")]
        public long Attachment { get; set; }

        [JsonProperty("outfit")]
        public long Outfit { get; set; }

        [JsonProperty("emote")]
        public long Emote { get; set; }

        [JsonProperty("league")]
        public int League { get; set; }

        [JsonProperty("division")]
        public int Division { get; set; }

        [JsonProperty("divisionRating")]
        public int DivisionRating { get; set; }

        [JsonProperty("seasonId")]
        public int SeasonId { get; set; }
    }
}