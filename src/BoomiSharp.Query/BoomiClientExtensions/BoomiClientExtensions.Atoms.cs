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
        public static Task<QueryResult<Atom>> GetAtomsAsync(this BoomiClient client)
        {
            return client.GetBoomiObjectsAsync<Atom>();
        }

        public static Task<QueryResult<Atom>> GetAtomsAsync(
            this BoomiClient client,
            Func<AtomExpressionBuilder, IExpression> expressionBuilder)
        {
            return client.GetBoomiObjectsAsync<Atom, AtomExpressionBuilder>(expressionBuilder);
        }
    }
}
