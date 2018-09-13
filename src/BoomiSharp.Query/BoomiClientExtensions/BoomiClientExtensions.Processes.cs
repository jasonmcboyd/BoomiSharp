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
        public static Task<QueryResult<Process>> GetProcessesAsync(this BoomiClient client)
        {
            return client.GetBoomiObjectsAsync<Process>();
        }

        public static Task<QueryResult<Process>> GetProcessesAsync(
            this BoomiClient client,
            Func<ProcessExpressionBuilder, IExpression> expressionBuilder)
        {
            return client.GetBoomiObjectsAsync<Process, ProcessExpressionBuilder>(expressionBuilder);
        }
    }
}
