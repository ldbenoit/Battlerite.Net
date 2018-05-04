using Newtonsoft.Json;

namespace Rocket.Battlerite
{
    public partial class ParticipantStats
    {
        [JsonProperty("abilityUses")]
        public int AbilityUses { get; set; }

        [JsonProperty("attachment")]
        public long Attachment { get; set; }

        [JsonProperty("damageDone")]
        public int DamageDone { get; set; }

        [JsonProperty("damageReceived")]
        public int DamageReceived { get; set; }

        [JsonProperty("deaths")]
        public int Deaths { get; set; }

        [JsonProperty("disablesDone")]
        public int DisablesDone { get; set; }

        [JsonProperty("disablesReceived")]
        public int DisablesReceived { get; set; }

        [JsonProperty("emote")]
        public long Emote { get; set; }

        [JsonProperty("energyGained")]
        public int EnergyGained { get; set; }

        [JsonProperty("energyUsed")]
        public int EnergyUsed { get; set; }

        [JsonProperty("healingDone")]
        public int HealingDone { get; set; }

        [JsonProperty("healingReceived")]
        public int HealingReceived { get; set; }

        [JsonProperty("kills")]
        public int Kills { get; set; }

        [JsonProperty("mount")]
        public long Mount { get; set; }

        [JsonProperty("outfit")]
        public long Outfit { get; set; }

        [JsonProperty("score")]
        public int Score { get; set; }

        [JsonProperty("side")]
        public int Side { get; set; }

        [JsonProperty("timeAlive")]
        public int TimeAlive { get; set; }
    }
}