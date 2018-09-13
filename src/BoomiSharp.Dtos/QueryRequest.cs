using BoomiSharp.Dtos.Expressions;

namespace BoomiSharp.Dtos
{
    public class QueryRequest
    {
        public QueryRequest()
        {

        }

        public QueryRequest(QueryFilter queryFilter)
        {
            this.QueryFilter = queryFilter;
        }

        public QueryRequest(IExpression expression)
        {
            this.QueryFilter = new QueryFilter(expression);
        }

        public QueryFilter QueryFilter { get; set; }
    }
}
