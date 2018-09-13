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
        public static Task<QueryResult<Deployment>> GetDeploymentsAsync(this BoomiClient client)
        {
            return client.GetBoomiObjectsAsync<Deployment>();
        }

        public static Task<QueryResult<Deployment>> GetDeploymentsAsync(
            this BoomiClient client,
            Func<DeploymentExpressionBuilder, IExpression> expressionBuilder)
        {
            return client.GetBoomiObjectsAsync<Deployment, DeploymentExpressionBuilder>(expressionBuilder);
        }
    }
}
