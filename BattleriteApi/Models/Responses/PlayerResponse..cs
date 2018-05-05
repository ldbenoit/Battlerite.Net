using System;
using System.Collections.Generic;

using System.Globalization;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
namespace Rocket.Battlerite
{
    public partial class PlayerResponse : PlayerResponseBase
    {
        [JsonIgnore]
        public PlayerData Player { get => Data.ElementAtOrDefault(0); }
    }


}
