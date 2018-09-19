using BoomiSharp.Dtos;
using BoomiSharp.Dtos.Serialization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BoomiSharp.Http
{
    static class HttpClientExtensions
    {
        internal async static Task<T> GetAsync<T>(this HttpClient httpClient, string requestUri)
        {
            var json = await httpClient.GetStringAsync(requestUri);
            return BoomiDtoSerializer.Instance.Deserialize<T>(json);
        }

        internal static Task<TResult> PostAsync<TBody, TResult>(
            this HttpClient httpClient, 
            string requestUri, 
            TBody body)
        {
            var json = BoomiDtoSerializer.Instance.Serialize(body);
            return httpClient.PostJsonAsync<TResult>(requestUri, json);
        }

        internal async static Task<TResult> PostJsonAsync<TResult>(
            this HttpClient httpClient,
            string requestUri,
            string json)
        {
            var content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            using (var response = await httpClient.PostAsync(requestUri, content))
            {
                json = await response.Content.ReadAsStringAsync();
                return BoomiDtoSerializer.Instance.Deserialize<TResult>(json);
            }
        }

        internal async static Task PostAsync<TBody>(
            this HttpClient httpClient, 
            string requestUri, 
            TBody body)
        {
            var json = BoomiDtoSerializer.Instance.Serialize(body);
            var content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            (await httpClient.PostAsync(requestUri, content)).Dispose();
        }

        internal async static Task<DeleteResult> DeleteWithResultAsync(
            this HttpClient httpClient, 
            string requestUri)
        {
            using (var response = await httpClient.DeleteAsync(requestUri))
            {
                var json = await response.Content.ReadAsStringAsync();
                return BoomiDtoSerializer.Instance.Deserialize<DeleteResult>(json);
            }
        }
    }
}
