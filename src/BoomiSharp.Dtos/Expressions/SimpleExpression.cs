using System.Collections.Generic;
using System.Linq;

namespace BoomiSharp.Dtos.Expressions
{
    public class SimpleExpression<T> : IExpression
    {
        public SimpleExpression()
        {
        }
        
        public SimpleExpression(string property, QueryOperator queryOperator, IEnumerable<T> arguments)
            : this(property, queryOperator, arguments.ToArray())
        {
        }

        public SimpleExpression(string property, QueryOperator queryOperator, params T[] arguments)
        {
            this.Property = property;
            this.Operator = queryOperator;
            this.Argument = arguments;
        }

        public T[] Argument { get; set; }
        public QueryOperator Operator { get; set; }
        public string Property { get; set; }
    }
}
