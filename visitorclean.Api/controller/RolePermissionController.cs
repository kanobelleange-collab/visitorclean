using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using visitorclean.Application.Feature.RolePermission.Commands.CreateRolePermission;
using visitorclean.Application.Feature.RolePermission.Queries.GetAllRolePermissions;
using visitorclean.Application.Feature.RolePermission.Queries.GetRolePermissionById;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class RolePermissionController : ControllerBase
{
    private readonly IMediator _mediator;

    public RolePermissionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllRolePermissionsQuery());
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int roleId, int permissionId)
    {
        var result = await _mediator.Send(new GetRolePermissionByIdQuery(roleId, permissionId));
        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateRolePermissionCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}