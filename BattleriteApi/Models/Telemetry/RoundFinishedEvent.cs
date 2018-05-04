using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Rocket.Battlerite.Converters;

namespace Rocket.Battlerite
{
    public partial class RoundFinishedEvent : ITelemetryObject
    { 
        [JsonProperty("time")]
        [JsonConverter(typeof(EpochMsConverter))]
        public DateTime Time { get; set; }

        [JsonProperty("matchID")]
        public string MatchId { get; set; }

        [JsonProperty("externalMatchID")]
        public string ExternalMatchId { get; set; }

        [JsonProperty("round")]
        public int Round { get; set; }

        [JsonProperty("roundLength")]
        public int RoundLength { get; set; }

        [JsonProperty("winningTeam")]
        public int WinningTeam { get; set; }

        [JsonProperty("playerStats")]
        public List<PlayerStat> PlayerStats { get; set; }
    }

    public partial class PlayerStat
    {
        [JsonProperty("userID")]
        public string UserId { get; set; }

        [JsonProperty("kills")]
        public int Kills { get; set; }

        [JsonProperty("deaths")]
        public int Deaths { get; set; }

        [JsonProperty("score")]
        public int Score { get; set; }

        [JsonProperty("damageDone")]
        public int DamageDone { get; set; }

        [JsonProperty("damageReceived")]
        public int DamageReceived { get; set; }

        [JsonProperty("healingDone")]
        public int HealingDone { get; set; }

        [JsonProperty("healingReceived")]
        public int HealingReceived { get; set; }

        [JsonProperty("disablesDone")]
        public int DisablesDone { get; set; }

        [JsonProperty("disablesReceived")]
        public int DisablesReceived { get; set; }

        [JsonProperty("energyGained")]
        public int EnergyGained { get; set; }

        [JsonProperty("energyUsed")]
        public int EnergyUsed { get; set; }

        [JsonProperty("timeAlive")]
        public int TimeAlive { get; set; }

        [JsonProperty("abilityUses")]
        public int AbilityUses { get; set; }
    }
}