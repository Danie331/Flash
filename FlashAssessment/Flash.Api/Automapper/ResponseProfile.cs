using Dto = Flash.Api1.DtoModels.Response;
using Domain = Flash.DomainModels;
using AutoMapper;

namespace Flash.Api1.Automapper
{
    public class ResponseProfile : Profile
    {
        public ResponseProfile()
        {
            CreateMap<Domain.User, Dto.User>();
        }
    }
}