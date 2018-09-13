using BoomiSharp.Dtos.BoomiObjects;

namespace BoomiSharp.Query.ExpressionBuilders
{
    public class ProcessExpressionBuilder : BaseExpressionBuilder<Process>
    {
        public PredicateExpressionBuilder<string> Id => new PredicateExpressionBuilder<string>();
        public PredicateExpressionBuilder<string> Name => new PredicateExpressionBuilder<string>();
        public PredicateExpressionBuilder<string> IntegrationPackId => new PredicateExpressionBuilder<string>();
        public PredicateExpressionBuilder<string> IntegrationPackInstanceId => new PredicateExpressionBuilder<string>();
    }
}
