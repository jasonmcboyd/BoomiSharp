using BoomiSharp.Dtos;
using Newtonsoft.Json;
using System;

namespace BoomiSharp.Json
{
    public class QueryRequestJsonConverter : JsonConverter<QueryRequest>
    {
        public override bool CanRead => false;

        public override QueryRequest ReadJson(JsonReader reader, Type objectType, QueryRequest existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, QueryRequest value, JsonSerializer serializer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName(nameof(QueryRequest.QueryFilter));
            serializer.Serialize(writer, value.QueryFilter);
            writer.WriteEndObject();
        }
    }
}
