using BoomiSharp.Dtos.BoomiObjects;

namespace BoomiSharp.Query.ExpressionBuilders
{
    public class ListenerStatusExpressionBuilder : BaseExpressionBuilder<ListenerStatus>
    {
        public PredicateExpressionBuilder<string> ListenerID => new PredicateExpressionBuilder<string>();
        public PredicateExpressionBuilder<string> ContainerId => new PredicateExpressionBuilder<string>();
    }
}
