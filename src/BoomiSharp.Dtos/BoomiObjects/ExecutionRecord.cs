using System;

namespace BoomiSharp.Dtos.BoomiObjects
{
    public class ExecutionRecord : IBoomiObject, ICanQuery
    {
        public string GetId() => this.ExecutionId.ToString();

        public string ExecutionId { get; set; }
        public Guid OriginalExecutionId { get; set; }
        public string stringBuilder { get; set; }
        public DateTime ExecutionTime { get; set; }
        public ExecutionStatus Status { get; set; }
        public string ExecutionType { get; set; }
        public string ProcessName { get; set; }
        public Guid ProcessId { get; set; }
        public string AtomName { get; set; }
        public Guid AtomId { get; set; }
        public Guid LauncherId { get; set; }
        public int InboundDocumentCount { get; set; }
        public int OutboundDocumentCount { get; set; }
        public string ReportKey { get; set; }
    }
}
