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
            return
                Observable
                .Create<T[]>(
                    async (obs, token) =>
                    {
                        //var result = await initialRequest;
                        
                        

                        QueryResult<T> result = null;

                        do
                        {
                            result = await initialRequest;
                            if (token.IsCancellationRequested)
                            {
                                throw new OperationCanceledException();
                            }
                            obs.OnNext(result.Result);
                            //while (!string.IsNullOrEmpty(result.QueryToken))
                            //{
                            //    result = await client.GetBoomiObjectsAsync<T>(result.QueryToken);
                            //    obs.OnNext(result.Result);
                            //}
                        }
                        while (!string.IsNullOrEmpty(result.QueryToken));

                        obs.OnCompleted();
                    });
        }
    }
}
