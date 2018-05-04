using System;
using System.Collections.Generic;

using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Rocket.Battlerite.Converters;

namespace Rocket.Battlerite
{
    public partial class MatchResponseBase : IResponse
    {
        [JsonProperty("data")]
        [JsonConverter(typeof(MatchDataConverter))]
        public IList<MatchData> Data { get; set; }
        
        [JsonProperty("errors")]
        public List<Error> Errors { get; set; }

        [JsonProperty("included")]
        [JsonConverter(typeof(IncludeConverter))]
        public IncludeContainer Includes { get; set; }

        [JsonProperty("links")]
        public ResponseLink Links { get; set; }

        [JsonProperty("meta")]
        public Meta Meta { get; set; }

        [JsonIgnore]
        public bool IsSuccess { get; set; }
        
        [OnDeserialized]
        internal void OnDeserialized(StreamingContext context)
        {
            foreach( var match in Data)
            {
                var rosters = Includes.Rosters
                    .Where(x => match.Relationships.Rosters.Any(y => y.Id == x.Id) )
                    .ToList();
                var rounds = Includes.Rounds
                    .Where(x => match.Relationships.Rounds.Any(y => y.Id == x.Id) )
                    .ToList();
                var telemetry = Includes.Assets
                    .First(x => match.Relationships.Assets.Any(y => y.Id == x.Id) );


                match.TelemetryUrl = telemetry.Attributes.Url;
                foreach (var roster in rosters)
                {
                    var team = new TeamMatchInfo{
                        Stats = roster.Attributes.Stats, 
                        IsWinner = roster.Attributes.Won, 
                        Id = roster.Relationships.Team?.Id};

                    team.Players = roster.Relationships.Participants
                        .SelectMany(x => Includes.Participants.Where(y => y.Id == x.Id))
                        .Select(x => new PlayerMatchInfo{
                            Id = x.Relationships.Player.Id,
                            ActorId = x.Attributes.Actor,
                            Stats = x.Attributes.Stats,
                            })
                        .ToList();
                    match.Teams.Add(team);
                }

                foreach (var round in rounds)
                {
                    match.Rounds.Add(round.Attributes);
                }

                match.Players = match.Teams.SelectMany(x => x.Players).ToList();
            }
        } 
    }
}
