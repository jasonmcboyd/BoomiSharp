using BoomiSharp.Dtos.BoomiObjects;
using BoomiSharp.Http;
using System.Threading.Tasks;

namespace BoomiSharp
{
    public partial class BoomiClient
    {
        public Task ExecuteProcessAsync(ProcessExecution request)
        {
            return
                this
                ._Client
                .PostAsync<ProcessExecution>(
                    "executeProcess",
                    request);
        }
    }
}
