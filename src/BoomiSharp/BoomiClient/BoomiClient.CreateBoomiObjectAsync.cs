using BoomiSharp.Dtos.BoomiObjects;
using BoomiSharp.Http;
using System.Threading.Tasks;

namespace BoomiSharp
{
    public partial class BoomiClient
    {
        public Task<T> CreateBoomiObjectAsync<T>(T boomiObject)
            where T : IBoomiObject, ICanCreate
        {
            var result =
                this
                .GetClient()
                .PostAsync<T, T>(
                    BoomiObjectUrlMapper.GetObjectUrl<T>(),
                    boomiObject);

            return result;
        }
    }
}
