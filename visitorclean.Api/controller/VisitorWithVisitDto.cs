using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Runtime.Versioning;
using System.Runtime.ExceptionServices;
using visitorclean.Infrastructure.Repository;
using AutoMapper;
using visitorclean.Application.Feature.visitor.Dto;
using visitorclean.Application.Feature.visitor.Queries.Getvisitorwithvisitdto;
using visitorclean.Application.Feature.visitor.Queries.Getvisitorbyperiod;
using MediatR;
using System.Net.Cache;
using Microsoft.AspNetCore.Authorization;

namespace visitorclean.Api.controller;


[Authorize]
[ApiController]


[Route("Api/VisitorWithVisitDto")]
public class VisitorWithVisitDto : ControllerBase
{
    private readonly IMediator _mediator;

    public VisitorWithVisitDto(IMediator mediator)
    {
        _mediator=mediator;
    }

    [HttpGet("by-period")]
public async Task<IActionResult> GetVisitorByPeriodAsync(
    DateTime startDate,
    DateTime endDate,
    CancellationToken cancellationToken)
{
    var result = await _mediator.Send(
        new GetVisitorByPeriodQuery(startDate, endDate,cancellationToken),
        cancellationToken);

    return Ok(result);
}

[HttpGet]
public async Task<IActionResult>GetVisitorWithVisitAsync(CancellationToken cancellationToken)
    {
        
        var result= await _mediator.Send(new GetVisitorWithVisitDtoquery());
        return Ok(result);
    }

}