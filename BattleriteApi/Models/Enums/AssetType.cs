using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Rocket.Battlerite
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AssetType
    {
        Asset,
        Team,
        Roster,
        Round,
        Player,
        Participant
    }
}