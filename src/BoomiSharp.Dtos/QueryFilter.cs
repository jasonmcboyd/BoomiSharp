using BoomiSharp.Dtos.Expressions;

namespace BoomiSharp.Dtos
{
    public class QueryFilter
    {
        public QueryFilter(IExpression expression)
        {
            this.Expression = expression;
        }

        public IExpression Expression { get; set; }
    }
}
