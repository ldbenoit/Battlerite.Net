using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Rocket.Battlerite.Converters
{
    public class TelemetryConverter : JsonConverter
    {
        public override bool CanWrite => false;
        public override bool CanRead => true;
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(TelemetryResponse);
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
            var response = new TelemetryResponse();
            response.Data = serializer.Deserialize<List<TelemetryData>>(json.CreateReader());

            response.QueueEvents = response.Data
                .Where(x => x.Type == TelemetryType.QueueEvent)
                .Select(x => x.DataObject as QueueEvent)
                .ToList();
            response.MatchReservedUsers = response.Data
                .Where(x => x.Type == TelemetryType.MatchReservedUser)
                .Select(x => x.DataObject as MatchReservedUser)
                .ToList();
            response.RoundEvents = response.Data
                .Where(x => x.Type == TelemetryType.RoundEvent)
                .Select(x => x.DataObject as RoundEvent)
                .ToList();
            response.Spells = response.Data
                .Where(x => x.Type == TelemetryType.UserRoundSpell)
                .Select(x => x.DataObject as UserRoundSpell)
                .ToList();
            response.Deaths = response.Data
                .Where(x => x.Type == TelemetryType.DeathEvent)
                .Select(x => x.DataObject as DeathEvent)
                .ToList();
            response.RoundFinishedEvents = response.Data
                .Where(x => x.Type == TelemetryType.RoundFinishedEvent)
                .Select(x => x.DataObject as RoundFinishedEvent)
                .ToList();
            response.TeamUpdates = response.Data
                .Where(x => x.Type == TelemetryType.TeamUpdateEvent)
                .Select(x => x.DataObject as TeamUpdateEvent)
                .ToList();

            response.ServerShutdown = response.Data
                .Where(x => x.Type == TelemetryType.ServerShutdown)
                .Select(x => x.DataObject as ServerShutdown)
                .First();
            response.MatchFinishedEvent = response.Data
                .Where(x => x.Type == TelemetryType.MatchFinishedEvent)
                .Select(x => x.DataObject as MatchFinishedEvent)
                .First();
            response.MatchStart = response.Data
                .Where(x => x.Type == TelemetryType.MatchStart)
                .Select(x => x.DataObject as MatchStart)
                .First();
            return response;
        }
    }
}