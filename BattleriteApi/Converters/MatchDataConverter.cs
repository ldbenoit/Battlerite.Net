using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Rocket.Battlerite.Converters
{
    public class MatchDataConverter : JsonConverter
    {
        public override bool CanWrite => false;
        public override bool CanRead => true;
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(MatchData);
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
            var jsonObject = JToken.Load(reader);
            if (jsonObject.Type == JTokenType.Array)
                return serializer.Deserialize<List<MatchData>>(jsonObject.CreateReader());
            var a = serializer.Deserialize<MatchData>(jsonObject.CreateReader());
            return new List<MatchData>{a};
        }
    }
}