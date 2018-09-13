using BoomiSharp.Dtos;
using BoomiSharp.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BoomiSharp.Http
{
    public static class HttpClientExtensions
    {
        private static readonly JsonSerializerSettings _Settings = new JsonSerializerSettings()
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            Converters = new List<JsonConverter>()
                {
                    new QueryRequestJsonConverter(),
                    new QueryOperatorJsonConverter(),
                    new EnvironmentClassificationJsonConverter(),
                    new ComponentTypeJsonConverter(),
                    new AtomStatusJsonConverter(),
                    new AtomTypeJsonConverter(),
                    new AccountStatusJsonConverter(),
                    new LogicalOperatorJsonConverter(),
                    new SimpleExpressionJsonConverter(),
                    new ProcessSchedulesJsonConverter(),
                    new RetrySchedulesJsonConverter()
                }
        };
        
        public async static Task<T> GetAsync<T>(this HttpClient httpClient, string requestUri)
        {
            var result = await httpClient.GetStringAsync(requestUri);
            return JsonConvert.DeserializeObject<T>(result, HttpClientExtensions._Settings);
        }

        public async static Task<TResult> PostAsync<TBody, TResult>(this HttpClient httpClient, string requestUri, TBody body, bool serializeBody = true)
        {
            string json = null;
            if (serializeBody)
            {
                json = JsonConvert.SerializeObject(body, HttpClientExtensions._Settings);
            }
            else
            {
                json = body.ToString();
            }
            var content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await httpClient.PostAsync(requestUri, content);
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResult>(responseContent, HttpClientExtensions._Settings);
        }
        
        public async static Task<DeleteResult> DeleteWithResultAsync(this HttpClient httpClient, string requestUri)
        {
            var response = await httpClient.DeleteAsync(requestUri);
            var result = await response.Content.ReadAsStringAsync();
            if (result == "{true}")
            {
                return new DeleteResult();
            }
            else
            {
                var obj = JObject.Parse(result);
                return new DeleteResult(obj["message"].Value<string>());
            }
        }
    }
}
