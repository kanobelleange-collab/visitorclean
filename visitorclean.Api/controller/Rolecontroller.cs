using System;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using visitorclean.Application.Feature.visit.Dto;
using visitorclean.Domain.Entities;
using System.Threading .Tasks;
using System.Runtime.Versioning;
using visitorclean.Application.Feature.visit.Interface;
using Microsoft.AspNetCore.Authorization;
using visitorclean.Application.Feature.role.Commands.createRole;
using visitorclean.Application.Feature.role.Queries.GetRoleByName;
using visitorclean.Application.Feature.role.Queries.GetAllRole;
using MediatR;


namespace visitorclean.Api.controller;

[Authorize]
[ApiController]

[Route("Api/Roles")]
public class RoleController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public RoleController(IMediator mediator, IMapper mapper)
    {
        _mediator=mediator;
        _mapper=mapper;

    }
    public async Task<IActionResult> GetByNameAsync(string nom)
    {
        var role=_mediator.Send( new GetByNameQuery(nom) );
        return Ok(role);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateRoleCommand command)
    {
        var id = await _mediator.Send(command);
        return Ok(id);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var roles = await _mediator.Send(new GetAllRolesQuery());
        return Ok(roles);
    }
}