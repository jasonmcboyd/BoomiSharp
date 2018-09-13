using BoomiSharp.Dtos.BoomiObjects;
using System;

namespace BoomiSharp
{
    public static class BoomiObjectUrlMapper
    {
        public static string GetBulkUrl<T>()
            where T : IBoomiObject
        {
            return $"{typeof(T).Name}/bulk";
        }

        public static string GetQueryUrl<T>()
            where T : IBoomiObject
        {
            if (typeof(T) == typeof(ListenerStatus))
            {
                return $"{typeof(T).Name}/query/async";
            }
            return $"{typeof(T).Name}/query";
        }

        public static string GetQueryMoreUrl<T>()
            where T : IBoomiObject
        {
            return $"{typeof(T).Name}/queryMore";

        }

        public static string GetObjectUrl<T>(string id)
            where T : IBoomiObject
        {
            return $"{typeof(T).Name}/{id}";
        }

        public static string GetObjectUrl<T>(Guid id)
            where T : IBoomiObject
        {
            return BoomiObjectUrlMapper.GetObjectUrl<T>(id.ToString());
        }

        public static string GetObjectUrl<T>()
            where T : IBoomiObject
        {
            return $"{typeof(T).Name}";
        }

        public static string GetUpdateUrl<T>(string id)
            where T : IBoomiObject
        {
            return $"{typeof(T).Name}/{id}/update";
        }

        public static string GetUpdateUrl<T>(Guid id)
            where T : IBoomiObject
        {
            return BoomiObjectUrlMapper.GetUpdateUrl<T>(id.ToString());
        }

        internal static string GetDeleteUrl<T>(string id) where T : IBoomiObject
        {
            return $"{typeof(T).Name}/{id}";
        }
    }
}
