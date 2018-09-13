using BoomiSharp.Dtos.BoomiObjects;

namespace BoomiSharp.Query.ExpressionBuilders
{
    public class EnvironmentAtomAttachmentExpressionBuilder : BaseExpressionBuilder<EnvironmentAtomAttachment>
    {
        public PredicateExpressionBuilder<string> AtomId => new PredicateExpressionBuilder<string>();
        public PredicateExpressionBuilder<string> EnvironmentId => new PredicateExpressionBuilder<string>();
    }
}
