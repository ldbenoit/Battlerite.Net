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
    public partial class PlayerResponseBase : DataResponse<PlayerData>, IResponse
    {
        [JsonProperty("data")]
        [JsonConverter(typeof(PlayerDataConverter))]
        public override IList<PlayerData> Data { get; set; }

        [JsonProperty("links")]
        public ResponseLink Links { get; set; }

        [JsonProperty("meta")]
        public Meta Meta { get; set; }
        
        [OnDeserialized]
        internal void OnDeserialized(StreamingContext context)
        {
            // TODO: Parse stats / stackables
        } 
    }



}
