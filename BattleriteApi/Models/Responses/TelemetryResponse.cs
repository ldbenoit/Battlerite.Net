namespace Rocket.Battlerite
{
    using System.Collections.Generic;
    using System.Globalization;
    using System;
    using Newtonsoft.Json.Converters;
    using Newtonsoft.Json;
    using System.Runtime.Serialization;
    using System.Linq;
    using Rocket.Battlerite.Converters;

    [JsonConverter(typeof(TelemetryConverter))]
    public partial class TelemetryResponse : IResponse
    {
        public IList<TelemetryData> Data { get; set; }

        [JsonProperty("errors")]
        public List<Error> Errors { get; set; }

        [JsonIgnore]
        public bool IsSuccess { get; set; }
        
        public IList<QueueEvent> QueueEvents { get; set; }
        public IList<MatchReservedUser> MatchReservedUsers { get; set; }
        public IList<RoundEvent> RoundEvents { get; set; }
        public IList<UserRoundSpell> Spells { get; set; }
        public IList<DeathEvent> Deaths { get; set; }
        public IList<RoundFinishedEvent> RoundFinishedEvents { get; set; }
        public IList<TeamUpdateEvent> TeamUpdates { get; set; }

        public ServerShutdown ServerShutdown { get; set; }
        public MatchFinishedEvent MatchFinishedEvent { get; set; }
        public MatchStart MatchStart { get; set; }

    }


}