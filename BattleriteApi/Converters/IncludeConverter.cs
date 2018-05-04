using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Rocket.Battlerite.Converters
{
    public class IncludeConverter : JsonConverter
    {
        public override bool CanWrite => false;
        public override bool CanRead => true;
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(IncludeContainer);
        }

        public override void WriteJson(JsonWriter writer,
            object value, JsonSerializer serializer)
        {
            throw new InvalidOperationException("Use default serialization.");
        }

        public override object ReadJson(JsonReader reader,
            Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            var json = JContainer.Load(reader);
            var container = new IncludeContainer();
            foreach (var item in json)
            {
                var include = default(IInclude);
                switch (item["type"].ToString())
                {
                    case "asset":
                        include =  new AssetInclude();
                        container.Assets.Add(include as AssetInclude);
                        break;
                    case "participant":
                        include =  new ParticipantInclude();
                        container.Participants.Add(include as ParticipantInclude);
                        break;
                    case "player":
                        include =  new PlayerInclude();
                        container.Players.Add(include as PlayerInclude);
                        break;
                    case "roster":
                        include =  new RosterInclude();
                        container.Rosters.Add(include as RosterInclude);
                        break;
                    case "round":
                        include =  new RoundInclude();
                        container.Rounds.Add(include as RoundInclude);
                        break;
                    case "team":
                        include =  new TeamInclude();
                        container.Teams.Add(include as TeamInclude);
                        break;
                    default:
                        break;
                }
                serializer.Populate(item.CreateReader(), include);
            }
            return container;
        }
    }
}