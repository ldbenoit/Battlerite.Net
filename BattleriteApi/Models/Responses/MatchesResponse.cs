using System.Collections.Generic;
using Newtonsoft.Json;

namespace Rocket.Battlerite
{
    public class MatchesResponse : MatchResponseBase
    {
        [JsonIgnore]
        public IList<MatchData> Matches { get => Data; }
    }

}