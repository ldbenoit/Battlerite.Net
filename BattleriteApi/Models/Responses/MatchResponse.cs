using System.Linq;
using Newtonsoft.Json;

namespace Rocket.Battlerite
{
    public partial class MatchResponse : MatchResponseBase
    {
        [JsonIgnore]
        public MatchData Match { get => Data.ElementAtOrDefault(0); }
    }

}