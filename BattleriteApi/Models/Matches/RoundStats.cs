using Newtonsoft.Json;

namespace Rocket.Battlerite
{
    public partial class RoundStats
    {
        [JsonProperty("winningTeam")]
        public long WinningTeam { get; set; }
    }
}