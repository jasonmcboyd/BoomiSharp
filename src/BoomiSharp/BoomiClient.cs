using BoomiSharp.Dtos;
using BoomiSharp.Dtos.BoomiObjects;
using BoomiSharp.Dtos.Expressions;
using BoomiSharp.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BoomiSharp
{
    public class BoomiClient : IDisposable
    {
        public BoomiClient(
            string accountId,
            string username,
            string password)
        {
            var uri = new Uri($"https://api.boomi.com/api/rest/v1/{accountId}/");

            this._Client = new HttpClient()
            {
                BaseAddress = uri
            };
            
            this._Client.DefaultRequestHeaders.Add("Accept", "application/json");
            this._Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("BASIC", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}")));
        }
        
        #region Boomi Objects

        public Task<T> GetBoomiObjectAsync<T>(Guid id) 
            where T : IBoomiObject, ICanGet
        {
            return this._Client.GetAsync<T>(BoomiObjectUrlMapper.GetObjectUrl<T>(id));
        }

        public Task<T> GetBoomiObjectAsync<T>(string id)
            where T : IBoomiObject, ICanGet
        {
            return this._Client.GetAsync<T>(BoomiObjectUrlMapper.GetObjectUrl<T>(id));
        }

        public async Task<IEnumerable<BulkResponse<T>>> GetBoomiObjectsAsync<T>(IEnumerable<Guid> ids)
            where T : IBoomiObject, ICanGet
        {
            var tasks =
                ids
                .Buffer(100)
                .Select(x => new BulkRequest(x))
                .Select(x => this._Client.PostAsync<BulkRequest, BulkResult<T>>(BoomiObjectUrlMapper.GetBulkUrl<T>(), x));

            var result = await Task.WhenAll(tasks);

            return result.SelectMany(x => x.Response);
        }

        public Task<IEnumerable<BulkResponse<T>>> GetBoomiObjectsAsync<T>(IEnumerable<string> ids)
            where T : IBoomiObject, ICanGet
        {
            return this.GetBoomiObjectsAsync<T>(ids.Select(Guid.Parse));
        }

        public Task<QueryResult<T>> GetBoomiObjectsAsync<T>()
            where T : IBoomiObject, ICanQuery
        {
            var response =
                this
                ._Client.PostAsync<QueryRequest, QueryResult<T>>(
                    BoomiObjectUrlMapper.GetQueryUrl<T>(),
                    new QueryRequest());

            return response;
        }

        public Task<QueryResult<T>> GetBoomiObjectsAsync<T>(IExpression expression)
            where T : IBoomiObject, ICanQuery
        {
            var response =
                this
                ._Client
                .PostAsync<QueryRequest, QueryResult<T>>(
                    BoomiObjectUrlMapper.GetQueryUrl<T>(),
                    new QueryRequest(expression));

            return response;
        }

        public Task<QueryResult<T>> GetBoomiObjectsAsync<T>(string queryToken)
            where T : IBoomiObject, ICanQuery
        {
            var response =
                this
                ._Client
                .PostAsync<string, QueryResult<T>>(
                    BoomiObjectUrlMapper.GetQueryMoreUrl<T>(),
                    queryToken,
                    false);

            return response;
        }
                
        public Task<T> CreateBoomiObjectAsync<T>(T boomiObject)
            where T : IBoomiObject, ICanCreate
        {
            var result = 
                this
                ._Client
                .PostAsync<T, T>(
                    BoomiObjectUrlMapper.GetObjectUrl<T>(),
                    boomiObject);

            return result;
        }

        public Task<T> UpdateBoomiObjectAsync<T>(T boomiObject)
            where T : IBoomiObject, ICanUpdate
        {
            var result =
                this
                ._Client
                .PostAsync<T, T>(
                    BoomiObjectUrlMapper.GetUpdateUrl<T>(boomiObject.GetId()),
                    boomiObject);

            return result;
        }

        public Task<DeleteResult> DeleteBoomiObjectAsync<T>(T boomiObject)
            where T : IBoomiObject, ICanDelete
        {
            var result =
                this
                .DeleteBoomiObjectAsync<T>(boomiObject.GetId());

            return result;
        }

        public Task<DeleteResult> DeleteBoomiObjectAsync<T>(string id)
            where T : IBoomiObject, ICanDelete
        {
            return this._Client.DeleteWithResultAsync(BoomiObjectUrlMapper.GetDeleteUrl<T>(id));
        }

        #endregion

        #region Buffer

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


        private readonly HttpClient _Client;

        #region IDisposable Implementation

        // See http://msdn.microsoft.com/en-us/library/b1yfkh5e(v=vs.110).aspx for the proper
        // implementation of the Dispose pattern.

        private readonly object _DisposeLock = new object();

        private bool _IsDisposed = false;
        /// <summary>
        /// Gets a boolean value that indicates if the object has been disposed.
        /// </summary>
        public bool IsDisposed
        {
            get { return this._IsDisposed; }
            private set { this._IsDisposed = value; }
        }

        protected virtual void Dispose(bool disposing)
        {
            // If this object has already been disposed then exit without doing anything.
            if (this.IsDisposed)
            {
                return;
            }

            // Lock the critical section to ensure that more than one thread cannot attempt to 
            // dispose the object at the same time.
            lock (this._DisposeLock)
            {
                // Check IsDisposed again in case more than one thread got to the lock.
                // This ensures that only the first thread through the lock will execute the 
                // critical section and that any other threads will exit without doing anything.
                if (this.IsDisposed)
                {
                    return;
                }

                // Dispose of the object.
                if (disposing)
                {
                    // Dispose of resources here.
                    this._Client.Dispose();
                }

                // Set IsDisposed to true.
                this.IsDisposed = true;
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
