
using System.Collections.Generic;

namespace Flash.DAL.Contract
{
    public interface ICacheConverter
    {
        byte[] ToByteArray<T>(T obj);
        T FromByteArray<T>(byte[] bytes);
        IEnumerable<T> FromByteArrayList<T>(byte[] bytes);
        string GetKeyValue<T>(T obj);
    }
}
