using BoomiSharp.Dtos.BoomiObjects;

namespace BoomiSharp.Query.ExpressionBuilders
{
    public class EnvironmentExpressionBuilder : BaseExpressionBuilder<Environment>
    {
        public PredicateExpressionBuilder<string> Classification => new PredicateExpressionBuilder<string>();
        public PredicateExpressionBuilder<string> Name => new PredicateExpressionBuilder<string>();
        public PredicateExpressionBuilder<string> Id => new PredicateExpressionBuilder<string>();
    }
}
