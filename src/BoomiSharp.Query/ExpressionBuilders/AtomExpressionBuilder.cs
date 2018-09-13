using BoomiSharp.Dtos.BoomiObjects;

namespace BoomiSharp.Query.ExpressionBuilders

{
    public class AtomExpressionBuilder : BaseExpressionBuilder<Atom>
    {
        public PredicateExpressionBuilder<string> Name => new PredicateExpressionBuilder<string>();

        public PredicateExpressionBuilder<string> Hostname => new PredicateExpressionBuilder<string>();

        public PredicateExpressionBuilder<string> Id => new PredicateExpressionBuilder<string>();

        public EqualityPredicateExpressionBuilder<AtomType> Type => new EqualityPredicateExpressionBuilder<AtomType>();

        public OrderPredicateExpressionBuilder<AtomStatus> Status => new OrderPredicateExpressionBuilder<AtomStatus>();
    }
}
