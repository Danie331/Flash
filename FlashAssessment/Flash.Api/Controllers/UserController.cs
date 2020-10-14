using AutoMapper;
using Flash.Services.Contract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using Domain = Flash.DomainModels;
using Dto = Flash.Api.DtoModels;

namespace Flash.Api.Controllers
{
    [AllowAnonymous, Route("v1/users"), ApiController]
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
        public async Task<IActionResult> GetUser(int id)
        {
            var target = await _userService.GetUserAsync(id);
            return Ok(new Dto.Response<Dto.User>(_mapper.Map<Dto.User>(target)));
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers([FromQuery] Dto.PaginationQuery pagination)
        {
            var paginationFilter = _mapper.Map<Domain.PaginationFilter>(pagination);
            var results = await _userService.GetUsersAsync(paginationFilter);
            var resultsDto = _mapper.Map<IEnumerable<Dto.User>>(results);

            return Ok(new Dto.PagedResponse<Dto.User>(resultsDto, paginationFilter.PageNumber, paginationFilter.PageSize));
        }

        [HttpPost, Consumes(MediaTypeNames.Application.Json), ProducesResponseType(201)]
        public async Task<IActionResult> AddUser(Dto.User userDto)
        {
            var user = _mapper.Map<Domain.User>(userDto);
            var result = await _userService.AddUserAsync(user);

            return Ok(new Dto.Response<Dto.User>(_mapper.Map<Dto.User>(result)));
        }

        [HttpPut, Route("{id}"), Consumes(MediaTypeNames.Application.Json), ProducesResponseType(200)]
        public async Task<IActionResult> UpdateUser(int id, [FromBody]Dto.User userDto)
        {
            var user = _mapper.Map<Domain.User>(userDto);
            var result = await _userService.UpdateUserAsync(id, user);

            return Ok(new Dto.Response<Dto.User>(_mapper.Map<Dto.User>(result)));
        }
    }
}