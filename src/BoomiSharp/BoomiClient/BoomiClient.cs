using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BoomiSharp
{
    public partial class BoomiClient
    {
        public BoomiClient(
            string accountId,
            string username,
            string password)
        {
            this._BaseUri = new Uri($"https://api.boomi.com/api/rest/v1/{accountId}/");
            this._Username = username;
            this._Password = password;
        }

        private HttpClient GetClient()
        {
            var client = HttpClientFactory.Create();
            client.BaseAddress = this._BaseUri;
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("BASIC", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{this._Username}:{this._Password}")));
            return client;
        }

        private readonly Uri _BaseUri;
        private readonly string _Username;
        private readonly string _Password;

        #region Buffer

        // TODO:
        public async Task<IList<T>> BatchApiCalls<T>(IEnumerable<Task<T>> jobs)
        {
            var batches = jobs.Buffer(5);
            var tasks = new List<Task>(6);
            var result = new List<T>();

            foreach (var batch in batches)
            {
                tasks.AddRange(batch);
                tasks.Add(Task.Delay(1100));
                await Task.WhenAll(tasks);

                result.AddRange(batch.Select(x => x.Result));
            }

            return result;
        }

        #endregion
    }
}
