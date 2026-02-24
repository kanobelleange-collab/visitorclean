using MediatR;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using visitorclean.Application.Feature.visit.Commands.createvisit;
using visitorclean.Application.Feature.visit.Commands.updatevisit;
using visitorclean.Application.Feature.visit.Queries.GetByidvisit;
using visitorclean.Application.Feature.visit.Queries.Getallvisit;
using visitorclean.Application.Feature.visit.Commands.CreateVisitDto;
using visitorclean.Application.DTOs;

namespace visitorclean.Api.controller;

[ApiController]
[Route("api/[controller]")]
public class VisitController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public VisitController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] CreateVisitDto dto)
    {
        var command = _mapper.Map<CreateVisitCommand>(dto);

        var response = await _mediator.Send(command);

        return Ok(response);
    }

    [HttpPut("{id}")]


public async Task<IActionResult> Update(int id, [FromBody] UpdateVisitDto dto)
{
    var command = _mapper.Map<UpdateVisitCommand>(dto);
    

    var response = await _mediator.Send(command);

    if (response == null)
        return NotFound($"Visit with id {id} not found");

    return Ok(response);
}
    

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var visit = await _mediator.Send(new GetByIdVisitquery(id));

        if (visit == null)
            return NotFound($"Visit avec l'id {id} introuvable");

        return Ok(visit);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var visits = await _mediator.Send(new GetAllVisitQuery());

        return Ok(visits);
    }
}