using System;

namespace BoomiSharp.Dtos
{
    public class BulkResponse<TResult>
    {
        public TResult Result { get; set; }
        public Guid? Id { get; set; }
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }
        public bool HasError => ErrorMessage != null;
    }
}
