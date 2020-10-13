using AutoMapper;
using Flash.Api.DtoModels;
using Flash.Services.Contract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Dto = Flash.Api.DtoModels;

namespace Flash.Api.Controllers
{
    [AllowAnonymous, Route("users"), ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UserController(IUserService userService,
                              IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet, Route("{id}")]
        public async Task<ActionResult<Dto.User>> GetUser(int id)
        {
            var target = await _userService.GetUserAsync(id);
            return Ok(new Response<Dto.User>(_mapper.Map<Dto.User>(target)));
        }
    }
}
