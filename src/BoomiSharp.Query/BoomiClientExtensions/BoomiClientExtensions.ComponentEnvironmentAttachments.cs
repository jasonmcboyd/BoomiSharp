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
        public static Task<QueryResult<ComponentEnvironmentAttachment>> GetComponentEnvironmentAttachmentsAsync(this BoomiClient client)
        {
            return client.GetBoomiObjectsAsync<ComponentEnvironmentAttachment>();
        }

        public static Task<QueryResult<ComponentEnvironmentAttachment>> GetComponentEnvironmentAttachmentsAsync(
            this BoomiClient client,
            Func<ComponentEnvironmentAttachmentExpressionBuilder, IExpression> expressionBuilder)
        {
            return client.GetBoomiObjectsAsync<ComponentEnvironmentAttachment, ComponentEnvironmentAttachmentExpressionBuilder>(expressionBuilder);
        }
    }
}
