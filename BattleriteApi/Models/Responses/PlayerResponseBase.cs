using System;
using System.Collections.Generic;

using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Rocket.Battlerite.Converters;

namespace Rocket.Battlerite
{
    public partial class PlayerResponseBase : IResponse
    {
        [JsonProperty("data")]
        [JsonConverter(typeof(PlayerDataConverter))]
        public IList<PlayerData> Data { get; set; }
        
        [JsonProperty("errors")]
        public List<Error> Errors { get; set; }

        [JsonProperty("links")]
        public ResponseLink Links { get; set; }

        [JsonProperty("meta")]
        public Meta Meta { get; set; }

        [JsonIgnore]
        public bool IsSuccess { get; set; }
        
        [OnDeserialized]
        internal void OnDeserialized(StreamingContext context)
        {
            // TODO: Parse stats / stackables
        } 
    }



}
