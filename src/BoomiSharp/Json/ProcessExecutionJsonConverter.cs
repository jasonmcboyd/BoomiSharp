using BoomiSharp.Dtos.BoomiObjects;
using BoomiSharp.Extensions;
using Newtonsoft.Json;
using System;

namespace BoomiSharp.Json
{
    public class ProcessExecutionJsonConverter : JsonConverter<ProcessExecution>
    {
        public override bool CanRead => false;

        public override ProcessExecution ReadJson(JsonReader reader, Type objectType, ProcessExecution existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanWrite => true;

        public override void WriteJson(JsonWriter writer, ProcessExecution value, JsonSerializer serializer)
        {
            writer.WriteStartObject();
            foreach (var prop in value.GetType().GetProperties())
            {
                if (prop.Name != nameof(value.ProcessProperties))
                {
                    writer.WritePropertyName(prop.Name.ToCamelCase());
                    serializer.Serialize(writer, prop.GetValue(value));
                }
            }
            if (value.ProcessProperties != null && value.ProcessProperties.Length > 0)
            {
                writer.WritePropertyName("ProcessProperties");
                writer.WriteStartObject();
                writer.WritePropertyName("ProcessProperty");
                writer.WriteStartArray();
                foreach (var property in value.ProcessProperties)
                {
                    writer.WriteStartObject();
                    writer.WritePropertyName("Name");
                    writer.WriteValue(property.Name);
                    writer.WritePropertyName("Value");
                    writer.WriteValue(property.Value);
                    writer.WriteEndObject();
                }
                writer.WriteEndArray();
                writer.WriteEndObject();
            }
            writer.WriteEndObject();
        }
    }
}
