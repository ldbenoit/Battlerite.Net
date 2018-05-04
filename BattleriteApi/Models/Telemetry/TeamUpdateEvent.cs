using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Rocket.Battlerite.Converters;

namespace Rocket.Battlerite
{
    public partial class TeamUpdateEvent : ITelemetryObject
    { 
        [JsonProperty("time")]
        [JsonConverter(typeof(EpochMsConverter))]
        public DateTime Time { get; set; }

        [JsonProperty("season")]
        public long Season { get; set; }

        [JsonProperty("teamID")]
        public string TeamId { get; set; }

        [JsonProperty("matchID")]
        public string MatchId { get; set; }

        [JsonProperty("externalMatchID")]
        public string ExternalMatchId { get; set; }

        [JsonProperty("userIDs")]
        public List<string> UserIDs { get; set; }

        [JsonProperty("mode")]
        public string Mode { get; set; }

        [JsonProperty("prevLeague")]
        public int PrevLeague { get; set; }

        [JsonProperty("league")]
        public int League { get; set; }

        [JsonProperty("prevDivision")]
        public int PrevDivision { get; set; }

        [JsonProperty("division")]
        public int Division { get; set; }

        [JsonProperty("prevDivisionRating")]
        public int PrevDivisionRating { get; set; }

        [JsonProperty("divisionRating")]
        public int DivisionRating { get; set; }

        [JsonProperty("prevWins")]
        public int PrevWins { get; set; }

        [JsonProperty("wins")]
        public int Wins { get; set; }

        [JsonProperty("prevLosses")]
        public int PrevLosses { get; set; }

        [JsonProperty("losses")]
        public int Losses { get; set; }

        [JsonProperty("roundsWon")]
        public int RoundsWon { get; set; }

        [JsonProperty("roundsLost")]
        public int RoundsLost { get; set; }

        [JsonProperty("teamSize")]
        public int TeamSize { get; set; }

        [JsonProperty("rankingChangeType")]
        public string RankingChangeType { get; set; }

        [JsonProperty("prevPlacementGamesLeft")]
        public int PrevPlacementGamesLeft { get; set; }

        [JsonProperty("placementGamesLeft")]
        public int PlacementGamesLeft { get; set; }

        [JsonProperty("matchRegion")]
        public string MatchRegion { get; set; }
    }
}