using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Rocket.Battlerite.Converters
{
    public class TelemetryDataConverter : JsonConverter
    {
        public override bool CanWrite => false;
        public override bool CanRead => true;
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(ITelemetryObject);
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
            var telemetry = new TelemetryData();
            // telemetry.Type = serializer.Deserialize<TelemetryType>(json["type"].CreateReader());
            serializer.Populate(json.CreateReader(), telemetry);
            ITelemetryObject telemetryObject = default(ITelemetryObject);
            switch(telemetry.Type)
            {
                case TelemetryType.BattleritePickEvent:
                    telemetryObject = new BattleritePickEvent();
                    break;
                case TelemetryType.DeathEvent:
                    telemetryObject = new DeathEvent();
                    break;
                case TelemetryType.MatchFinishedEvent:
                    telemetryObject = new MatchFinishedEvent();
                    break;
                case TelemetryType.MatchReservedUser:
                    telemetryObject = new MatchReservedUser();
                    break;
                case TelemetryType.MatchStart:
                    telemetryObject = new MatchStart();
                    break;
                case TelemetryType.QueueEvent:
                    telemetryObject = new QueueEvent();
                    break;
                case TelemetryType.RoundEvent:
                    telemetryObject = new RoundEvent();
                    break;
                case TelemetryType.RoundFinishedEvent:
                    telemetryObject = new RoundFinishedEvent();
                    break;
                case TelemetryType.ServerShutdown:
                    telemetryObject = new ServerShutdown();
                    break;
                case TelemetryType.TeamUpdateEvent:
                    telemetryObject = new TeamUpdateEvent();
                    break;
                case TelemetryType.UserRoundSpell:
                    telemetryObject = new UserRoundSpell();
                    break;
            }
            serializer.Populate(json["dataObject"].CreateReader(), telemetryObject);
            telemetry.DataObject = telemetryObject;
            return telemetry;
            // var response = serializer;
            // foreach (var item in json)
            // {
            //     var include = default(IInclude);

            //     switch (item["type"].ToString())
            //     {
            //         case nameof(TelemetryType.RoundEvent):
            //             include =  new AssetInclude();
            //             response.Assets.Add(include as AssetInclude);
            //             break;
            //         case "participant":
            //             include =  new ParticipantInclude();
            //             response.Participants.Add(include as ParticipantInclude);
            //             break;
            //         case "player":
            //             include =  new PlayerInclude();
            //             response.Players.Add(include as PlayerInclude);
            //             break;
            //         case "roster":
            //             include =  new RosterInclude();
            //             response.Rosters.Add(include as RosterInclude);
            //             break;
            //         case "round":
            //             include =  new RoundInclude();
            //             response.Rounds.Add(include as RoundInclude);
            //             break;
            //         case "team":
            //             include =  new TeamInclude();
            //             response.Teams.Add(include as TeamInclude);
            //             break;
            //         default:
            //             break;
            //     }
            //     serializer.Populate(item.CreateReader(), include);
            // }
            // return container;
        }
    }
}