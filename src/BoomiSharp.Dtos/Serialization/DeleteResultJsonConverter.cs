using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace BoomiSharp.Dtos.Serialization
{
    public class DeleteResultJsonConverter : JsonConverter<DeleteResult>
    {
        public override bool CanRead => true;

        public override DeleteResult ReadJson(JsonReader reader, Type objectType, DeleteResult existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var value = (string)reader.Value;

            if (value == "{true}")
            {
                return new DeleteResult();
            }
            else
            {
                var obj = JObject.Parse(value);
                return new DeleteResult(obj["message"].Value<string>());
            }

        }

        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, DeleteResult value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
