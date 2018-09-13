using BoomiSharp.Dtos.BoomiObjects;
using BoomiSharp.Extensions;
using Newtonsoft.Json;
using System;

namespace BoomiSharp.Json
{
    public class ProcessSchedulesJsonConverter : JsonConverter<ProcessSchedules>
    {
        public override bool CanRead => false;

        public override ProcessSchedules ReadJson(JsonReader reader, Type objectType, ProcessSchedules existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, ProcessSchedules value, JsonSerializer serializer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName(nameof(ProcessSchedules.AtomId).ToCamelCase());
            serializer.Serialize(writer, value.AtomId);
            writer.WritePropertyName(nameof(ProcessSchedules.Id).ToCamelCase());
            serializer.Serialize(writer, value.Id);
            writer.WritePropertyName(nameof(ProcessSchedules.ProcessId).ToCamelCase());
            serializer.Serialize(writer, value.ProcessId);
            writer.WritePropertyName(nameof(ProcessSchedules.Retry));
            serializer.Serialize(writer, value.Retry);
            writer.WritePropertyName(nameof(ProcessSchedules.Schedule));
            serializer.Serialize(writer, value.Schedule);
            writer.WriteEndObject();
        }
    }
}
