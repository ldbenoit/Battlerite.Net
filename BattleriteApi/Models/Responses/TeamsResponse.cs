using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
namespace Rocket.Battlerite
{
    public partial class TeamsResponse : DataResponse<TeamInclude>,  IResponse
    {
        [JsonProperty("links")]
        public ResponseLink Links { get; set; }

        [JsonProperty("meta")]
        public Meta Meta { get; set; }
    }


}
