using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Rocket.Battlerite
{
    public interface ITelemetryObject
    {
        [JsonProperty("time")]
        DateTime Time { get; set; }
    }

}