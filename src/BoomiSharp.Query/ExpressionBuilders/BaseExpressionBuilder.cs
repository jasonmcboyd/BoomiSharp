using BoomiSharp.Dtos.BoomiObjects;
using BoomiSharp.Dtos.Expressions;

namespace BoomiSharp.Query.ExpressionBuilders
{
    public abstract class BaseExpressionBuilder<T> : IExpressionBuilder<T>
        where T : IBoomiObject
    {
        public CompoundExpression And(params IExpression[] expressions)
        {
            return new CompoundExpression(LogicalOperator.And, expressions);
        }

        public CompoundExpression Or(params IExpression[] expressions)
        {
            return new CompoundExpression(LogicalOperator.Or, expressions);
        }
    }
}
