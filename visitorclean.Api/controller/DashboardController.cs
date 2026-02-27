using System;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using visitorclean.Application.Feature.Dashboard.Dto;
using visitorclean.Domain.Entities;
using System.Threading .Tasks;
using System.Runtime.Versioning;
using Microsoft.AspNetCore.Authorization;
using MediatR;
using System.Security.Claims;
using visitorclean.Application.Feature.Dashboard.Queries;



namespace visitorclean.Api.controller;

[ApiController]

[Route("Api/Dashboard")]
public class DashboardController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public DashboardController(IMediator mediator, IMapper mapper)
    {
        _mediator=mediator;
        _mapper=mapper;

    }
    [Authorize(Roles ="Admin,Agent")]
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