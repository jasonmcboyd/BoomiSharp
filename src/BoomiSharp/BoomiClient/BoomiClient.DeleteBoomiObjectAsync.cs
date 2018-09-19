using BoomiSharp.Dtos;
using BoomiSharp.Dtos.BoomiObjects;
using BoomiSharp.Http;
using System.Threading.Tasks;

namespace BoomiSharp
{
    public partial class BoomiClient
    {
        public Task<DeleteResult> DeleteBoomiObjectAsync<T>(T boomiObject)
            where T : IBoomiObject, ICanDelete
        {
            var result =
                this
                .DeleteBoomiObjectAsync<T>(boomiObject.GetId());

            return result;
        }

        public Task<DeleteResult> DeleteBoomiObjectAsync<T>(string id)
            where T : IBoomiObject, ICanDelete
        {
            return this.GetClient().DeleteWithResultAsync(BoomiObjectUrlMapper.GetDeleteUrl<T>(id));
        }
    }
}
