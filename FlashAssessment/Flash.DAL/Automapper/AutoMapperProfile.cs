
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

            CreateMap<Data.WorkItemStatus, Domain.WorkItemStatus>();

            CreateMap<Domain.WorkItemStatus, Data.WorkItemStatus>().ForMember(i => i.WorkItem, f => f.Ignore());

            CreateMap<Data.User, Domain.User>();

            CreateMap<Domain.User, Data.User>().ForMember(i => i.Team, f => f.Ignore()).ForMember(i => i.WorkItem, f => f.Ignore());                        

            CreateMap<Data.WorkItem, Domain.WorkItem>();

            CreateMap<Domain.WorkItem, Data.WorkItem>().ForMember(i => i.Status, f => f.Ignore()).ForMember(i => i.User, f => f.Ignore());
        }
    }
}
