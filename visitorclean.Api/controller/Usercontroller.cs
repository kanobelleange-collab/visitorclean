using System;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using visitorclean.Application.Feature.users.Dto;
using visitorclean.Domain.Entities;
using System.Threading .Tasks;
using System.Runtime.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using visitorclean.Application.Feature.users.Commands.createuser;



[Authorize]
[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody]CreateUserCommand command)
    {
        var id = await _mediator.Send(command);
        return Ok(id);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var users = await _mediator.Send(new GetAllUserQuery());
        return Ok(users);
    }
}