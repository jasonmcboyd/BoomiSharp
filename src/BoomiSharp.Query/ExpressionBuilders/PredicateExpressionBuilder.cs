using BoomiSharp.Dtos.Expressions;
using System.Runtime.CompilerServices;

namespace BoomiSharp.Query.ExpressionBuilders
{
    public class PredicateExpressionBuilder<T>
    {
        internal PredicateExpressionBuilder([CallerMemberName] string propertyName = "")
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

        public SimpleExpression<T> IsNull()
        {
            return new SimpleExpression<T>(this._PropertyName, QueryOperator.IsNull);
        }

        public SimpleExpression<T> IsNotNull()
        {
            return new SimpleExpression<T>(this._PropertyName, QueryOperator.IsNotNull);
        }

        public SimpleExpression<T> LessThan(T argument)
        {
            return new SimpleExpression<T>(this._PropertyName, QueryOperator.LessThan, argument);
        }

        public SimpleExpression<T> LessThanOrEqual(T argument)
        {
            return new SimpleExpression<T>(this._PropertyName, QueryOperator.LessThanOrEqual, argument);
        }

        public SimpleExpression<T> Like(T argument)
        {
            return new SimpleExpression<T>(this._PropertyName, QueryOperator.Like, argument);
        }

        public SimpleExpression<T> NotEquals(T argument)
        {
            return new SimpleExpression<T>(this._PropertyName, QueryOperator.NotEquals, argument);
        }

        public SimpleExpression<T> StartsWith(T argument)
        {
            return new SimpleExpression<T>(this._PropertyName, QueryOperator.StartsWith, argument);
        }
    }
}
