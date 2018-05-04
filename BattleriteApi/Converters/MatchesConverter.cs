using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Rocket.Battlerite.Converters
{
    public class MatchesConverter : JsonConverter
    {
        public override bool CanWrite => false;
        public override bool CanRead => true;
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(MatchResponseBase);
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
            var jsonObject = JObject.Load(reader);
            var profession = default(MatchResponseBase);
            var matches = new List<MatchData>();
            foreach ( var data in jsonObject["data"])
            {
                serializer.Deserialize<MatchData>(data.CreateReader());
            }
            serializer.Populate(jsonObject.CreateReader(), profession);
            return profession;
        }
    }
}