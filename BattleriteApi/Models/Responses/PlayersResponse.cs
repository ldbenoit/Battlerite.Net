using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
namespace Rocket.Battlerite
{
    public partial class PlayersResponse : PlayerResponseBase
    {
        [JsonIgnore]
        public IList<PlayerData> Players { get => Data; }
    }


}
