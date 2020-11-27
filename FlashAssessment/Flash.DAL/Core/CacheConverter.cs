
using Flash.DAL.Contract;
using ProtoBuf;
using System.Collections.Generic;
using System.IO;

namespace Flash.DAL.Core
{
    class CacheConverter : ICacheConverter
    {
        public CacheConverter() { }

        public T FromByteArray<T>(byte[] bytes)
        {
            using (var ms = new MemoryStream(bytes))
            {
                var obj = Serializer.Deserialize<T>(ms);
                return obj;
            }
        }

        public IEnumerable<T> FromByteArrayList<T>(byte[] bytes)
        {
            using (var ms = new MemoryStream(bytes))
            {
                var list = Serializer.Deserialize<IEnumerable<T>>(ms);
                return list;
            }
        }

        public string GetKeyValue<T>(T obj)
        {
            var id = typeof(T).GetProperty("Id").GetValue(obj);
            var typeInstanceIdentifier = $"{typeof(T).Name}::{id}";
            return typeInstanceIdentifier;
        }

        public byte[] ToByteArray<T>(T obj)
        {
            using (var ms = new MemoryStream())
            {
                Serializer.Serialize(ms, obj);
                var bytes = ms.ToArray();
                return bytes;
            }
        }
    }
}
