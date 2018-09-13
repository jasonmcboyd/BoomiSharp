namespace BoomiSharp.Dtos.Expressions
{
    public class CompoundExpression : IExpression
    {
        public CompoundExpression()
        {
        }

        public CompoundExpression(LogicalOperator logicalOperator, params IExpression[] expressions)
        {
            this.Operator = logicalOperator;
            this.NestedExpression = expressions;
        }

        public LogicalOperator Operator { get; set; }
        public IExpression[] NestedExpression { get; set; }

        public static CompoundExpression And(params IExpression[] expressions)
        {
            return new CompoundExpression(LogicalOperator.And, expressions);
        }

        public static CompoundExpression Or(params IExpression[] expressions)
        {
            return new CompoundExpression(LogicalOperator.Or, expressions);
        }
    }
}
