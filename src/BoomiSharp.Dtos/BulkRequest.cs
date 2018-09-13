using System;
using System.Collections.Generic;
using System.Linq;

namespace BoomiSharp.Dtos
{
    public class BulkRequest
    {
        public BulkRequest(IEnumerable<string> ids) : this(ids.Select(Guid.Parse))
        {
        }

        public BulkRequest(IEnumerable<Guid> ids)
        {
            this.Request = ids.Select(x => new BulkRequestRequest() { Id = x }).ToArray();
        }

        public string Type => "GET";
        public BulkRequestRequest[] Request { get; set; }
    }
}
