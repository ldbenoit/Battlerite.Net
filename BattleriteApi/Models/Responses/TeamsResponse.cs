using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
namespace Rocket.Battlerite
{
    public partial class TeamsResponse : IResponse
    {
        [JsonProperty("data")]
        public IList<TeamInclude> Data { get; set; }

        [JsonProperty("errors")]
        public List<Error> Errors { get; set; }

        [JsonProperty("links")]
        public ResponseLink Links { get; set; }

        [JsonProperty("meta")]
        public Meta Meta { get; set; }

        [JsonIgnore]
        public bool IsSuccess { get; set; }
    }


}
