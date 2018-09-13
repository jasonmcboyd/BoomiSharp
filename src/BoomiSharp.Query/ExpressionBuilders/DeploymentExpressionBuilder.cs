using BoomiSharp.Dtos.BoomiObjects;

namespace BoomiSharp.Query.ExpressionBuilders
{
    public class DeploymentExpressionBuilder : BaseExpressionBuilder<Deployment>
    {
        public PredicateExpressionBuilder<string> EnvironmentId => new PredicateExpressionBuilder<string>();
        public PredicateExpressionBuilder<string> ProcessId => new PredicateExpressionBuilder<string>();
        public PredicateExpressionBuilder<string> ComponentId => new PredicateExpressionBuilder<string>();
        public PredicateExpressionBuilder<ComponentType> ComponentType => new PredicateExpressionBuilder<ComponentType>();
        public PredicateExpressionBuilder<bool> Current => new PredicateExpressionBuilder<bool>();
    }
}
