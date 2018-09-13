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
        public static Task<QueryResult<BoomiObjects.EnvironmentExtensions>> GetEnvironmentExtensionsAsync(this BoomiClient client)
        {
            return client.GetBoomiObjectsAsync<BoomiObjects.EnvironmentExtensions>();
        }

        public static Task<QueryResult<BoomiObjects.EnvironmentExtensions>> GetEnvironmentExtensionsAsync(
            this BoomiClient client,
            Func<EnvironmentExtensionsExpressionBuilder, IExpression> expressionBuilder)
        {
            return client.GetBoomiObjectsAsync<BoomiObjects.EnvironmentExtensions, EnvironmentExtensionsExpressionBuilder>(expressionBuilder);
        }        
    }
}
