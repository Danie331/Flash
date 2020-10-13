
using AutoMapper;
using Domain = Flash.DomainModels;
using Dto = Flash.Api.DtoModels;

namespace Flash.Api.Automapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Domain.User, Dto.User>().ForMember(r => r.TeamId, t => t.MapFrom(s => s.Team.Id))
                                              .ForMember(r => r.TeamDescription, t => t.MapFrom(s => s.Team.Description));
        }
    }
}
