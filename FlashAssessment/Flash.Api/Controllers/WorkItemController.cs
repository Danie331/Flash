using AutoMapper;
using Flash.Api.DtoModels;
using Flash.DomainModels;
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
    [AllowAnonymous, Route("workitems"), ApiController]
    public class WorkItemController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IWorkItemService _workItemService;
        private readonly IUserService _userService;

        public WorkItemController(IWorkItemService workItemService,
                                  IUserService userService,
                                  IMapper mapper)
        {
            _workItemService = workItemService;
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetWorkItems([FromQuery] PaginationQuery pagination)
        {
            var paginationFilter = _mapper.Map<PaginationFilter>(pagination);
            var results = await _workItemService.GetWorkItemsAsync(paginationFilter);
            var resultsDto = _mapper.Map<IEnumerable<Dto.WorkItem>>(results);

            return Ok(new PagedResponse<Dto.WorkItem>(resultsDto, paginationFilter.PageNumber, paginationFilter.PageSize));
        }

        [HttpPost, Consumes(MediaTypeNames.Application.Json), ProducesResponseType(201)]
        public async Task<IActionResult> AddWorkItem(Dto.WorkItem workItemDto)
        {
            var workItem = _mapper.Map<Domain.WorkItem>(workItemDto);
            var result = await _workItemService.AddWorkItemAsync(workItem);

            return Ok(new Response<Dto.WorkItem>(_mapper.Map<Dto.WorkItem>(result)));
        }

        [HttpPut, Route("{id}"), Consumes(MediaTypeNames.Application.Json), ProducesResponseType(200)]
        public async Task<IActionResult> UpdateWorkItem(int id, [FromBody] Dto.WorkItem workItemDto)
        {
            var workItem = _mapper.Map<Domain.WorkItem>(workItemDto);
            var result = await _workItemService.UpdateWorkItemAsync(id, workItem);

            return Ok(new Response<Dto.WorkItem>(_mapper.Map<Dto.WorkItem>(result)));
        }
    }
}
