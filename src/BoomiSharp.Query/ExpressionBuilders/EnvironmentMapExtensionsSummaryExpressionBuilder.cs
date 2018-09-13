using BoomiSharp.Dtos.BoomiObjects;

namespace BoomiSharp.Query.ExpressionBuilders
{
    public class EnvironmentMapExtensionsSummaryExpressionBuilder : BaseExpressionBuilder<EnvironmentMapExtensionsSummary>
    {
        public PredicateExpressionBuilder<string> EnvironmentId => new PredicateExpressionBuilder<string>();
        public PredicateExpressionBuilder<string> ExtensionGroupId => new PredicateExpressionBuilder<string>();
    }
}
