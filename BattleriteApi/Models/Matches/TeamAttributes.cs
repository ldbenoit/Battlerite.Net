using Newtonsoft.Json;

namespace Rocket.Battlerite
{
    
    public partial class TeamAttributes : IAttributes
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("shardId")]
        public string ShardId { get; set; }

        [JsonProperty("titleId")]
        public string TitleId { get; set; }

        [JsonProperty("stats")]
        public TeamStats Stats { get; set; }
    }
}