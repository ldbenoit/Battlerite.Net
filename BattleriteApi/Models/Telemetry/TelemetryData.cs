using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Rocket.Battlerite.Converters;

namespace Rocket.Battlerite
{
    [JsonConverter(typeof(TelemetryDataConverter))]
    public class TelemetryData
    {
        [JsonProperty("cursor")]
        public long Cursor { get; set; }

        [JsonProperty("type")]
        public TelemetryType Type { get; set; }

        [JsonIgnore]
        public ITelemetryObject DataObject { get; set; }
    }
}