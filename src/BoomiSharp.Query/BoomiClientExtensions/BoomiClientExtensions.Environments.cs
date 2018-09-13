using BoomiSharp.Dtos;
using BoomiSharp.Dtos.Expressions;
using BoomiSharp.Query.ExpressionBuilders;
using System;
using System.Threading.Tasks;
using BoomiObjects = BoomiSharp.Dtos.BoomiObjects;

namespace BoomiSharp.Query
{
    public static partial class BoomiClientExtensions
    {
        public static Task<QueryResult<BoomiObjects.Environment>> GetEnvironmentsAsync(this BoomiClient client)
        {
            return client.GetBoomiObjectsAsync<BoomiObjects.Environment>();
        }

        public static Task<QueryResult<BoomiObjects.Environment>> GetEnvironmentsAsync(
            this BoomiClient client,
            Func<EnvironmentExpressionBuilder, IExpression> expressionBuilder)
        {
            return client.GetBoomiObjectsAsync<BoomiObjects.Environment, EnvironmentExpressionBuilder >(expressionBuilder);
        }        
    }
}
