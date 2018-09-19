using BoomiSharp.Dtos;
using BoomiSharp.Dtos.BoomiObjects;
using BoomiSharp.Dtos.Expressions;
using System;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace BoomiSharp.Rx
{
    public static class BoomiClientReactiveExtensions
    {
        public static IObservable<T[]> GetBoomiObjectsObserable<T>(this BoomiClient client)
            where T : IBoomiObject, ICanQuery
        {
            return GetBoomiObjectsObservable_Internal(client, client.GetBoomiObjectsAsync<T>());
        }

        public static IObservable<T[]> GetBoomiObjectsAsync<T>(this BoomiClient client, IExpression expression)
            where T : IBoomiObject, ICanQuery
        {
            return GetBoomiObjectsObservable_Internal(client, client.GetBoomiObjectsAsync<T>(expression));
        }

        private static IObservable<T[]> GetBoomiObjectsObservable_Internal<T>(BoomiClient client, Task<QueryResult<T>> initialRequest)
            where T : IBoomiObject, ICanQuery
        {
            throw new NotImplementedException();
            // TODO:
            //return
            //    Observable
            //    .Create<T[]>(
            //        async (obs, token) =>
            //        {
            //            var task = initialRequest;
            //            QueryResult<T> result = null;

            //            try
            //            {
            //                do
            //                {
            //                    response = await task;
            //                    response.EnsureSuccessStatusCode();
            //                    token.ThrowIfCancellationRequested();
            //                    result = await response.DeserializeContentAsync();
            //                    response.Dispose();
            //                    token.ThrowIfCancellationRequested();
            //                    obs.OnNext(result);
            //                    task = client.GetBoomiObjectsAsync<T>(result.QueryToken);
            //                }
            //                while (!string.IsNullOrEmpty(result.QueryToken));

            //                obs.OnCompleted();
            //            }
            //            catch (OperationCanceledException e)
            //            {
            //                obs.OnCompleted();
            //            }
            //            catch (Exception e)
            //            {
            //                obs.OnError(e);
            //            }
            //            finally
            //            {
            //                if (response != null)
            //                {
            //                    response.Dispose();
            //                }
            //            }
            //        });
        }
    }
}
