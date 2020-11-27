using AutoMapper;
using Flash.Services.Contract;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using Domain = Flash.DomainModels;
using RequestDto = Flash.Api1.DtoModels.Request;
using ResponseDto = Flash.Api1.DtoModels.Response;

namespace Flash.Api1.Controllers
{
    [Route("users"), Produces("application/json"), ApiController]
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
            var target = await _userService.GetAsync(id);
            return Ok(new ResponseDto.Response<ResponseDto.User>(_mapper.Map<ResponseDto.User>(target)));
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers([FromQuery] RequestDto.PaginationQuery pagination)
        {
            var paginationFilter = _mapper.Map<Domain.PaginationFilter>(pagination);
            var results = await _userService.GetAllAsync(paginationFilter);
            var resultsDto = _mapper.Map<IEnumerable<ResponseDto.User>>(results);

            return Ok(new ResponseDto.PagedResponse<ResponseDto.User>(resultsDto, paginationFilter.PageNumber, paginationFilter.PageSize));
        }

        [HttpPost, Consumes(MediaTypeNames.Application.Json), ProducesResponseType(201)]
        public async Task<IActionResult> AddUser(RequestDto.User userDto)
        {
            var user = _mapper.Map<Domain.User>(userDto);
            await _userService.AddAsync(user);

            return Ok();
        }

        [HttpPut, Consumes(MediaTypeNames.Application.Json), ProducesResponseType(200)]
        public async Task<IActionResult> UpdateUser([FromBody] RequestDto.User userDto)
        {
            var user = _mapper.Map<Domain.User>(userDto);
            await _userService.UpdateAsync(user);

            return Ok();
        }
    }
}