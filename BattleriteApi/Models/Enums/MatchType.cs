using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Rocket.Battlerite
{
    public enum MatchType
    {
        Private,
        Quick2v2,
        Quick3v3,
        League2v2,
        League3v3,
    }
}