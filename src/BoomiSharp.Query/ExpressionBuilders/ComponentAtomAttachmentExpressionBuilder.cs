using BoomiSharp.Dtos.BoomiObjects;

namespace BoomiSharp.Query.ExpressionBuilders
{
    public class ComponentAtomAttachmentExpressionBuilder : BaseExpressionBuilder<ComponentAtomAttachment>
    {
        public PredicateExpressionBuilder<string> AtomId => new PredicateExpressionBuilder<string>();
        public PredicateExpressionBuilder<string> ComponentId => new PredicateExpressionBuilder<string>();
        public PredicateExpressionBuilder<ComponentType> ComponentType => new PredicateExpressionBuilder<ComponentType>();
    }
}
