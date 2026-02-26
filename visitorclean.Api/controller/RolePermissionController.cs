using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using visitorclean.Application.Feature.RolePermission.Dtos;
using visitorclean.Application.Feature.RolePermission.Queries.GetAllRolePermission;

namespace visitorclean.Api.controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolePermissionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RolePermissionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<RolePermissionDto>>> GetAll()
        {
            var result = await _mediator.Send(new GetAllRolePermissionQuery());
            return Ok(result);
        }
    }
}