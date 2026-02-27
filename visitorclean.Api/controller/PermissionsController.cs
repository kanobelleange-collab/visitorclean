using System;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using  visitorclean.Application.Permission.Queries.GetAllPermission.GetAllPermissionsQuery;
using visitorclean.Domain.Entities;
using System.Threading .Tasks;
using System.Runtime.Versioning;
using visitorclean.Application.Service.Interface;
using visitorclean.Application.Service;
using visitorclean.Application.Feature.Permission.Interface;
using visitorclean.Application.Feature.Permission.Queries.GetAllPermission;
using Microsoft.AspNetCore.Authorization;
using MediatR;

namespace visitorclean.Api.controller;

[Authorize]
[ApiController]

[Route("Api/Permissions")]
public class PermissionsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public PermissionsController(IMediator mediator, IMapper mapper)
    {
        _mediator=mediator;
        _mapper=mapper;

    }

    [HttpGet("user/{userId}/permissions")]
public async Task<IActionResult> GetPermissionsByUserId(int userId)
{
    var result = await _mediator.Send(
        new GetPermissionsByUserIdQuery(userId)
    );

    return Ok(result);
}

[HttpGet]
public async Task<IActionResult> GetAllAsync()
{
    var result = await _mediator.Send(new GetAllPermissionsQuery());
    return Ok(result);
}
}