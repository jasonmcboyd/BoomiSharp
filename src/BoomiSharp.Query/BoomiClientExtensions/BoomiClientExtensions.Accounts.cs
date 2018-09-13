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
        public static Task<QueryResult<Account>> GetAccountsAsync(this BoomiClient client)
        {
            return client.GetBoomiObjectsAsync<Account>();
        }

        public static Task<QueryResult<Account>> GetAccountsAsync(
            this BoomiClient client,
            Func<AccountExpressionBuilder, IExpression> expressionBuilder)
        {
            return client.GetBoomiObjectsAsync<Account, AccountExpressionBuilder>(expressionBuilder);
        }
    }
}
