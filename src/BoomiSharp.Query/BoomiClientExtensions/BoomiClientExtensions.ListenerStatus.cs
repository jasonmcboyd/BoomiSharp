using BoomiSharp.Dtos;
using BoomiSharp.Dtos.BoomiObjects;
using BoomiSharp.Dtos.Expressions;
using BoomiSharp.Query.ExpressionBuilders;
using System;
using System.Threading.Tasks;

namespace BoomiSharp.Query
{
    public static partial class BoomiClientExtensions
    {
        public static Task<QueryResult<ListenerStatus>> GetListenerStatusesAsync(
            this BoomiClient client,
            Func<ListenerStatusExpressionBuilder, IExpression> expressionBuilder)
        {
            return client.GetBoomiObjectsAsync<ListenerStatus, ListenerStatusExpressionBuilder>(expressionBuilder);
        }
    }
}
