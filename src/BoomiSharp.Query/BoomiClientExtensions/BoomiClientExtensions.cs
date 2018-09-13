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
        public static Task<QueryResult<TObject>> GetBoomiObjectsAsync<TObject, TBuilder>(
            this BoomiClient client,
            Func<TBuilder, IExpression> expressionBuilder)
            where TBuilder : IExpressionBuilder<TObject>, new()
            where TObject : IBoomiObject, ICanQuery
        {
            var builder = new TBuilder();
            var expression = expressionBuilder(builder);
            var response = client.GetBoomiObjectsAsync<TObject>(expression);
            return response;
        }
    }
}
