using System;

namespace BoomiSharp.Dtos.BoomiObjects
{
    public class ExecutionSummaryRecord : IBoomiObject, ICanQuery
    {
        public string GetId()
        {
            throw new NotImplementedException();
        }

        public float ElapsedVarSum { get; set; }
        public int MaxElapsedTime { get; set; }
        public int ExecutionCount { get; set; }
        public long ReturnDocSize { get; set; }
        public int ReturnedDocCount { get; set; }
        public long OutboundDocSize { get; set; }
        public int OutboundDocCount { get; set; }
        public long InboundDocSize { get; set; }
        public int InboundDocCount { get; set; }
        public long LaunchElapsedTime { get; set; }
        public Guid LaungerId { get; set; }
        public long ElapsedTime { get; set; }
        public string ProcessName { get; set; }
        public Guid ProcessId { get; set; }
        public string AtomName { get; set; }
        public Guid AtomId { get; set; }
        public string Status { get; set; }
        public DateTime TimeBlock { get; set; }
        public string AccountId { get; set; }
        public string ReportKey { get; set; }

    }
}
