using BoomiSharp.Dtos.Expressions;
using System.Runtime.CompilerServices;

namespace BoomiSharp.Query.ExpressionBuilders
{
    public class EqualityPredicateExpressionBuilder<T>
    {
        internal EqualityPredicateExpressionBuilder([CallerMemberName] string propertyName = "")
        {
            this._PropertyName = propertyName;
        }

        private readonly string _PropertyName;

        public SimpleExpression<T> Equals(T argument)
        {
            return new SimpleExpression<T>(this._PropertyName, QueryOperator.Equals, argument);
        }

        public SimpleExpression<T> NotEquals(T argument)
        {
            return new SimpleExpression<T>(this._PropertyName, QueryOperator.NotEquals, argument);
        }
    }
}
