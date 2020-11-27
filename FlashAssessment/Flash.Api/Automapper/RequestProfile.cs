
using AutoMapper;
using Dto = Flash.Api1.DtoModels.Request;
using Domain = Flash.DomainModels;

namespace Flash.Api1.Automapper
{
    public class RequestProfile : Profile
    {
        public RequestProfile()
        {
            CreateMap<Dto.User, Domain.User>();
            CreateMap<Dto.PaginationQuery, Domain.PaginationFilter>();
        }
    }
}