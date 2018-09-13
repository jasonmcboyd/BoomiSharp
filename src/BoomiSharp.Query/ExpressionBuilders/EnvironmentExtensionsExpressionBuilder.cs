using BoomiSharp.Dtos.BoomiObjects;

namespace BoomiSharp.Query.ExpressionBuilders
{
    public class EnvironmentExtensionsExpressionBuilder : BaseExpressionBuilder<EnvironmentExtensions>
    {
        public PredicateExpressionBuilder<string> EnvironmentId => new PredicateExpressionBuilder<string>();
        public PredicateExpressionBuilder<string> ExtensionGroupId => new PredicateExpressionBuilder<string>();
    }
}
