using System.Collections.Generic;
using Newtonsoft.Json;

namespace Rocket.Battlerite
{
    public partial class TeamStats
    {
        [JsonProperty("avatar")]
        public long Avatar { get; set; }

        [JsonProperty("division")]
        public int Division { get; set; }

        [JsonProperty("divisionRating")]
        public int DivisionRating { get; set; }

        [JsonProperty("league")]
        public int League { get; set; }

        [JsonProperty("losses")]
        public int Losses { get; set; }

        [JsonProperty("members")]
        public List<string> Members { get; set; }

        [JsonProperty("placementGamesLeft")]
        public int PlacementGamesLeft { get; set; }

        [JsonProperty("topDivision")]
        public int TopDivision { get; set; }

        [JsonProperty("topDivisionRating")]
        public int TopDivisionRating { get; set; }

        [JsonProperty("topLeague")]
        public int TopLeague { get; set; }

        [JsonProperty("wins")]
        public int Wins { get; set; }
    }

}