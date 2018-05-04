using Newtonsoft.Json;

namespace Rocket.Battlerite
{
    public partial class MatchResponse : MatchResponseBase
    {
        [JsonIgnore]
        public MatchData Match { get => Data[0]; }
    }

}