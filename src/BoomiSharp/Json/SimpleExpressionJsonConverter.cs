using BoomiSharp.Dtos.Expressions;
using BoomiSharp.Extensions;
using Newtonsoft.Json;
using System;

namespace BoomiSharp.Json
{
    public class SimpleExpressionJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType.IsGenericType && objectType.GetGenericTypeDefinition() == typeof(SimpleExpression<>);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var se = value as SimpleExpression<object>;

            writer.WriteStartObject();
            foreach (var prop in value.GetType().GetProperties())
            {
                writer.WritePropertyName(prop.Name.ToCamelCase());
                if (prop.Name == nameof(SimpleExpression<object>.Property))
                {
                    writer.WriteValue(prop.GetValue(value).ToString().ToCamelCase());
                }
                else
                {
                    serializer.Serialize(writer, prop.GetValue(value));
                }
            }
            writer.WriteEndObject();
        }
    }
}
