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
                .GetClient()
                .PostAsync<ProcessExecution>(
                    "executeProcess",
                    request);
        }
    }
}
