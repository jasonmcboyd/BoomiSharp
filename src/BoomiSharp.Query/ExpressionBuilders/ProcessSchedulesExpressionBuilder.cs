using BoomiSharp.Dtos.BoomiObjects;

namespace BoomiSharp.Query.ExpressionBuilders
{
    public class  ProcessSchedulesExpressionBuilder : BaseExpressionBuilder<ProcessSchedules>
    {
        public PredicateExpressionBuilder<string> AtomId => new PredicateExpressionBuilder<string>();
        public PredicateExpressionBuilder<string> ProcessId => new PredicateExpressionBuilder<string>();
    }
}
