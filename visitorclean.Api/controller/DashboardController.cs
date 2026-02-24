using System;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using visitorclean.Application.DTOs;
using visitorclean.Domain.Entities;
using System.Threading .Tasks;
using System.Runtime.Versioning;

namespace visitorclean.Api.controller;

[ApiController]

[Route("Api/Dashboard")]
public class DashboardController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public RoleController(IMediator mediator, IMapper mapper)
    {
        _mediator=mediator;
        _mapper=mapper;

    }
    [Authorize]
    [HttpGet("dashboard")]
    public async Task<IActionResult> GetDashboard()
    {
    var userId = int.Parse(
        User.FindFirst(ClaimTypes.NameIdentifier).Value);

    var result = await _mediator
        .Send(new GetDashboardQuery(userId));

    return Ok(result);
}
}