using Newtonsoft.Json;

namespace Rocket.Battlerite
{
    
    public class Tags
    {
        [JsonProperty("rankingType")]
        public RankingType RankingType { get; set; }
        [JsonProperty("serverType")]
        public ServerType ServerType { get; set; }
    }
}
