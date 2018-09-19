using BoomiSharp.Dtos;
using BoomiSharp.Dtos.BoomiObjects;
using BoomiSharp.Dtos.Expressions;
using BoomiSharp.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoomiSharp
{
    public partial class BoomiClient
    {
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
                .PostJsonAsync<QueryResult<T>>(
                    BoomiObjectUrlMapper.GetQueryMoreUrl<T>(),
                    queryToken);

            return response;
        }
    }
}
