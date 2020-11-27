using Domain = Flash.DomainModels;
using Data = Flash.DAL.Datacontext.Models;
using AutoMapper;
using Flash.DAL.Automapper.Converters;

namespace Flash.DAL.Automapper
{
    public class DomainToDataProfile : Profile
    {
        public DomainToDataProfile()
        {
            CreateMap<Domain.User, Data.User>();
            CreateMap<Data.User, byte[]>().ConvertUsing<UserToBytesConverter>();
        }
    }
}
