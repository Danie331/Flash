using AutoMapper;
using Flash.DAL.Contract;
using Data = Flash.DAL.Datacontext.Models;

namespace Flash.DAL.Automapper.Converters
{
    public class UserToBytesConverter : ITypeConverter<Data.User, byte[]>
    {
        private readonly ICacheConverter _cacheConverter;
        public UserToBytesConverter (ICacheConverter cacheConverter)
        {
            _cacheConverter = cacheConverter;
        }

        public byte[] Convert(Data.User source, byte[] destination, ResolutionContext context)
        {
            var convertedBytes = _cacheConverter.ToByteArray(source);
            return convertedBytes;
        }
    }
}
