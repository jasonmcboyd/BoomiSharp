using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

namespace BoomiSharp.Dtos.Serialization
{
    public class BoomiDtoSerializer
    {
        private BoomiDtoSerializer() { }

        public static BoomiDtoSerializer Instance { get; } = new BoomiDtoSerializer();

        private readonly JsonSerializerSettings _SerializerSettings =
            new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Converters =
                    new List<JsonConverter>()
                    {
                        new AccountStatusJsonConverter(),
                        new AtomStatusJsonConverter(),
                        new AtomTypeJsonConverter(),
                        new ComponentTypeJsonConverter(),
                        new DeleteResultJsonConverter(),
                        new EnvironmentClassificationJsonConverter(),
                        new LogicalOperatorJsonConverter(),
                        new ProcessExecutionJsonConverter(),
                        new ProcessSchedulesJsonConverter(),
                        new QueryOperatorJsonConverter(),
                        new QueryRequestJsonConverter(),
                        new RetrySchedulesJsonConverter(),
                        new SimpleExpressionJsonConverter()
                    }
            };
        private static BoomiDtoSerializer Serializer { get; } = new BoomiDtoSerializer();

        public string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj, this._SerializerSettings);
        }

        public T Deserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json, this._SerializerSettings);
        }
    }
}
