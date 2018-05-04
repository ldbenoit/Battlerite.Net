using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Rocket.Battlerite.Converters;

namespace Rocket.Battlerite
{
    public partial class QueueEvent : ITelemetryObject
    { 
        [JsonProperty("time")]
        [JsonConverter(typeof(EpochMsConverter))]
        public DateTime Time { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonProperty("teamId")]
        public string TeamId { get; set; }

        [JsonProperty("sessionId")]
        public string SessionId { get; set; }

        [JsonProperty("season")]
        public int Season { get; set; }

        [JsonProperty("eventType")]
        public string EventType { get; set; }

        [JsonProperty("timeJoinedQueue")]
        public string TimeJoinedQueue { get; set; }

        [JsonProperty("timeInQueue")]
        public double TimeInQueue { get; set; }

        [JsonProperty("character")]
        public long Character { get; set; }

        [JsonProperty("characterArchetype")]
        public int CharacterArchetype { get; set; }

        [JsonProperty("queueTypes")]
        public List<string> QueueTypes { get; set; }

        [JsonProperty("limitMatchmakingRange")]
        public bool LimitMatchmakingRange { get; set; }

        [JsonProperty("regionSamples")]
        public List<RegionSample> RegionSamples { get; set; }

        [JsonProperty("preferredRegion")]
        public string PreferredRegion { get; set; }

        [JsonProperty("rankingType")]
        public RankingType RankingType { get; set; }

        [JsonProperty("league")]
        public int League { get; set; }

        [JsonProperty("division")]
        public int Division { get; set; }

        [JsonProperty("divisionRating")]
        public int DivisionRating { get; set; }

        [JsonProperty("teamSize")]
        public int TeamSize { get; set; }

        [JsonProperty("teamMembers")]
        public List<string> TeamMembers { get; set; }

        [JsonProperty("placementGamesLeft")]
        public int PlacementGamesLeft { get; set; }

        [JsonProperty("matchId")]
        public string MatchId { get; set; }

        [JsonProperty("matchRegion")]
        public string MatchRegion { get; set; }

        [JsonProperty("teamSide")]
        public int TeamSide { get; set; }

        [JsonProperty("autoMatchmaking")]
        public bool AutoMatchmaking { get; set; }
    }

    public partial class RegionSample
    {
        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("latencyMS")]
        public int Latency { get; set; }
    }
}