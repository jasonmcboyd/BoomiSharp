using BoomiSharp.Dtos.Expressions;
using System.Runtime.CompilerServices;

namespace BoomiSharp.Query.ExpressionBuilders
{
    public class OrderPredicateExpressionBuilder<T>
    {
        internal OrderPredicateExpressionBuilder([CallerMemberName] string propertyName = "")
        {
            this._PropertyName = propertyName;
        }

        private readonly string _PropertyName;

        public SimpleExpression<T> Between(T argument1, T argument2)
        {
            return new SimpleExpression<T>(this._PropertyName, QueryOperator.Between, argument1, argument2);
        }
        
        public SimpleExpression<T> Equals(T argument)
        {
            return new SimpleExpression<T>(this._PropertyName, QueryOperator.Equals, argument);
        }

        public SimpleExpression<T> GreaterThan(T argument)
        {
            return new SimpleExpression<T>(this._PropertyName, QueryOperator.GreaterThan, argument);
        }

        public SimpleExpression<T> GreaterThanOrEqual(T argument)
        {
            return new SimpleExpression<T>(this._PropertyName, QueryOperator.GreaterThanOrEqual, argument);
        }

        public SimpleExpression<T> LessThan(T argument)
        {
            return new SimpleExpression<T>(this._PropertyName, QueryOperator.LessThan, argument);
        }

        public SimpleExpression<T> LessThanOrEqual(T argument)
        {
            return new SimpleExpression<T>(this._PropertyName, QueryOperator.LessThanOrEqual, argument);
        }
    }
}
