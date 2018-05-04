using System.Collections.Generic;
using Newtonsoft.Json;

namespace Rocket.Battlerite
{
    public partial class Error
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("detail")]
        public string Detail { get; set; }
    }
}