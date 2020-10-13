
using AutoMapper;
using Data = Flash.DAL.Datacontext.Models;
using Domain = Flash.DomainModels;

namespace Flash.DAL.Automapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Data.Team, Domain.Team>().ReverseMap();
            CreateMap<Data.WorkItemStatus, Domain.WorkItemStatus>().ReverseMap();
            CreateMap<Data.User, Domain.User>().ReverseMap();
            CreateMap<Data.WorkItem, Domain.WorkItem>().ReverseMap();
        }
    }
}
