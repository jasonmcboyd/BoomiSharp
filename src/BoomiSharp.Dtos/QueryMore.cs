namespace BoomiSharp.Dtos
{
    public class QueryMore
    {
        public QueryMore(string queryToken)
        {
            this.QueryToken = queryToken;
        }

        public string QueryToken { get; set; }
    }
}
