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
        public static Task<QueryResult<EnvironmentAtomAttachment>> GetEnvironmentAtomAttachmentsAsync(this BoomiClient client)
        {
            return client.GetBoomiObjectsAsync<EnvironmentAtomAttachment>();
        }

        public static Task<QueryResult<EnvironmentAtomAttachment>> GetEnvironmentAtomAttachmentsAsync(
            this BoomiClient client,
            Func<EnvironmentAtomAttachmentExpressionBuilder, IExpression> expressionBuilder)
        {
            return client.GetBoomiObjectsAsync<EnvironmentAtomAttachment, EnvironmentAtomAttachmentExpressionBuilder>(expressionBuilder);
        }
    }
}
