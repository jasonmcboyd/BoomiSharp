using BoomiSharp.Dtos.Expressions;
using BoomiSharp.Extensions;
using Newtonsoft.Json;
using System;

namespace BoomiSharp.Json
{
    internal class LogicalOperatorJsonConverter : JsonConverter<LogicalOperator>
    {
        public override bool CanRead => true;

        public override LogicalOperator ReadJson(JsonReader reader, Type objectType, LogicalOperator existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var value = (string)reader.Value;

            return (LogicalOperator)Enum.Parse(typeof(LogicalOperator), value.ToProperCase());
            
        }

        public override bool CanWrite => true;

        public override void WriteJson(JsonWriter writer, LogicalOperator value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString().ToLower());
        }
    }
}
