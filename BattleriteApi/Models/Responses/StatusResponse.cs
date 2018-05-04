using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
namespace Rocket.Battlerite
{
    public partial class StatusResponse : IResponse
    {
        [JsonProperty("data")]
        public StatusData Data { get; set; }

        [JsonProperty("errors")]
        public List<Error> Errors { get; set; }
        
        [JsonIgnore]
        public bool IsSuccess { get; set; }
    }

    public class StatusData
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("attributes")]
        public StatusAttributes Attributes { get; set; }
    }

    public class StatusAttributes
    {
        [JsonProperty("releasedAt")]
        public DateTime ReleasedAt { get; set; }
        [JsonProperty("version")]
        public string Version { get; set; }
    }


}
