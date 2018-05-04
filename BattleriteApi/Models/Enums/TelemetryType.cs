using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Rocket.Battlerite
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TelemetryType
    {
        [EnumMember(Value = "Structures.RoundEvent")] 
        RoundEvent,
        [EnumMember(Value = "Structures.MatchReservedUser")] 
        MatchReservedUser,
        [EnumMember(Value = "Structures.BattleritePickEvent")] 
        BattleritePickEvent,
        [EnumMember(Value = "Structures.UserRoundSpell")] 
        UserRoundSpell,
        [EnumMember(Value = "com.stunlock.service.matchmaking.avro.QueueEvent")] 
        QueueEvent,
        [EnumMember(Value = "Structures.RoundFinishedEvent")] 
        RoundFinishedEvent,
        [EnumMember(Value = "Structures.DeathEvent")] 
        DeathEvent,
        [EnumMember(Value = "Structures.ServerShutdown")] 
        ServerShutdown,
        [EnumMember(Value = "com.stunlock.battlerite.team.TeamUpdateEvent")] 
        TeamUpdateEvent,
        [EnumMember(Value = "Structures.MatchFinishedEvent")] 
        MatchFinishedEvent,
        [EnumMember(Value = "Structures.MatchStart")] 
        MatchStart,
    }
}