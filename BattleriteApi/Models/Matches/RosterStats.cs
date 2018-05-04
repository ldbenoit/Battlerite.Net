using Newtonsoft.Json;

namespace Rocket.Battlerite
{
    public partial class RosterStats
    {
        [JsonProperty("division")]
        public int Division { get; set; }

        [JsonProperty("divisionRating")]
        public int DivisionRating { get; set; }

        [JsonProperty("league")]
        public int League { get; set; }

        [JsonProperty("losses")]
        public int Losses { get; set; }

        [JsonProperty("matchRegion")]
        public string MatchRegion { get; set; }

        [JsonProperty("placementGamesLeft")]
        public int PlacementGamesLeft { get; set; }

        [JsonProperty("prevDivision")]
        public int PrevDivision { get; set; }

        [JsonProperty("prevDivisionRating")]
        public int PrevDivisionRating { get; set; }

        [JsonProperty("prevLeague")]
        public int PrevLeague { get; set; }

        [JsonProperty("prevLosses")]
        public int PrevLosses { get; set; }

        [JsonProperty("prevPlacementGamesLeft")]
        public int PrevPlacementGamesLeft { get; set; }

        [JsonProperty("prevWins")]
        public int PrevWins { get; set; }

        [JsonProperty("rankingChangeType")]
        public string RankingChangeType { get; set; }

        [JsonProperty("roundsLost")]
        public int RoundsLost { get; set; }

        [JsonProperty("roundsWon")]
        public int RoundsWon { get; set; }

        [JsonProperty("score")]
        public int Score { get; set; }

        [JsonProperty("season")]
        public int Season { get; set; }

        [JsonProperty("teamSize")]
        public int TeamSize { get; set; }

        [JsonProperty("wins")]
        public int Wins { get; set; }
    }
}