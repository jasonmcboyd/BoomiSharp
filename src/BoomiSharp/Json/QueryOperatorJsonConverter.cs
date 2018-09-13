using BoomiSharp.Dtos.Expressions;
using BoomiSharp.Extensions;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace BoomiSharp.Json
{
    public class QueryOperatorJsonConverter : JsonConverter<QueryOperator>
    {
        public override QueryOperator ReadJson(JsonReader reader, Type objectType, QueryOperator existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var value = string.Join("", reader.Value.ToString().Split("_").Select(StringExtensions.ToProperCase));

            return (QueryOperator)Enum.Parse(typeof(QueryOperator), value);
        }

        public override void WriteJson(JsonWriter writer, QueryOperator value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString().ToSnakeCase().ToUpper());
        }
    }
}
