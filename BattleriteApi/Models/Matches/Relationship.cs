using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Rocket.Battlerite.Converters;

namespace Rocket.Battlerite
{
    public partial class Relationships
    {
        [JsonProperty("assets")]
        [JsonConverter(typeof(AssetConverter))]
        public List<AssetData> Assets { get; set; }

        [JsonProperty("player")]
        [JsonConverter(typeof(AssetConverter))]
        public AssetData Player { get; set; }
        
        [JsonProperty("participants")]
        [JsonConverter(typeof(AssetConverter))]
        public List<AssetData> Participants { get; set; }
        
        [JsonProperty("rosters")]
        [JsonConverter(typeof(AssetConverter))]
        public List<AssetData> Rosters { get; set; }
        
        [JsonProperty("rounds")]
        [JsonConverter(typeof(AssetConverter))]
        public List<AssetData> Rounds { get; set; }
        
        [JsonProperty("team")]
        [JsonConverter(typeof(AssetConverter))]
        public AssetData Team { get; set; }
        
        [JsonProperty("spectators")]
        [JsonConverter(typeof(AssetConverter))]
        public List<AssetData> Spectators { get; set; }
    }

    public partial class AssetData
    {
        [JsonProperty("type")]
        public AssetType Type { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }
}