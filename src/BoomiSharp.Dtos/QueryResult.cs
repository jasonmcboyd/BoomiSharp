namespace BoomiSharp.Dtos
{
    public class QueryResult<T>
    {
        public int NumberOfResults { get; set; }
        public string QueryToken { get; set; }
        public bool HasMoreResults => this.QueryToken != null;
        public T[] Result { get; set; }
        public string Message { get; set; }
        public bool HasError => Message != null;
    }
}
