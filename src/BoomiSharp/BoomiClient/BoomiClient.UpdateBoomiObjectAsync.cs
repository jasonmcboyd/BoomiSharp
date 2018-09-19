using BoomiSharp.Dtos.BoomiObjects;
using BoomiSharp.Http;
using System.Threading.Tasks;

namespace BoomiSharp
{
    public partial class BoomiClient
    {
        public Task<T> UpdateBoomiObjectAsync<T>(T boomiObject)
            where T : IBoomiObject, ICanUpdate
        {
            var result =
                this
                .GetClient()
                .PostAsync<T, T>(
                    BoomiObjectUrlMapper.GetUpdateUrl<T>(boomiObject.GetId()),
                    boomiObject);

            return result;
        }
    }
}
