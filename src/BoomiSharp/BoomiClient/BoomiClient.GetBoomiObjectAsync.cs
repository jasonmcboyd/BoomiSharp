using BoomiSharp.Dtos.BoomiObjects;
using BoomiSharp.Http;
using System;
using System.Threading.Tasks;

namespace BoomiSharp
{
    public partial class BoomiClient
    {
        public Task<T> GetBoomiObjectAsync<T>(Guid id)
            where T : IBoomiObject, ICanGet
        {
            return this.GetClient().GetAsync<T>(BoomiObjectUrlMapper.GetObjectUrl<T>(id));
        }

        public Task<T> GetBoomiObjectAsync<T>(string id)
            where T : IBoomiObject, ICanGet
        {
            return this.GetClient().GetAsync<T>(BoomiObjectUrlMapper.GetObjectUrl<T>(id));
        }
    }
}
