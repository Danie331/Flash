
using AutoMapper;
using Domain = Flash.DomainModels;
using Data = Flash.DAL.Datacontext.Models;

namespace Flash.DAL.Automapper
{
    public class DataToDomainProfile : Profile
    {
        public DataToDomainProfile()
        {
            CreateMap<Data.User, Domain.User>();
        }
    }
}
