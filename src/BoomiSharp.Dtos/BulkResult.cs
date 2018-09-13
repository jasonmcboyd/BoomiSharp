namespace BoomiSharp.Dtos
{
    public class BulkResult<TResult>
    {
        public BulkResponse<TResult>[] Response { get; set; }
    }
}
