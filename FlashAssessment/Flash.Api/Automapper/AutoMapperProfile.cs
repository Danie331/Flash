﻿
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

            CreateMap<Dto.User, Domain.User>().ForPath(r => r.Team, t => t.MapFrom(q => new Domain.Team { Id = q.TeamId, Description = q.TeamDescription }));

            CreateMap<Domain.WorkItem, Dto.WorkItem>().ForMember(r => r.UserId, t => t.MapFrom(s => s.User.Id))
                                                      .ForMember(r => r.StatusId, t => t.MapFrom(s => s.Status.Id));

            CreateMap<Dto.WorkItem, Domain.WorkItem>().ForPath(r => r.User, t => t.MapFrom(q => q.UserId.HasValue ? new Domain.User { Id = q.UserId.Value } : null))
                                                      .ForPath(r => r.Status, t => t.MapFrom(q => new Domain.WorkItemStatus { Id = q.StatusId, StatusDescription = q.ItemDescription }));

            CreateMap<Dto.PaginationQuery, Domain.PaginationFilter>();
        }
    }
}