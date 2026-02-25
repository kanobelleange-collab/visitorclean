using MediatR;
using visitorclean.Application.Feature.visitor.Commands.deletevisitor;
using visitorclean.Application.Feature.visitor.Queries;
using visitorclean.Application.Feature.visitor.Commands.createvisitor;
using visitorclean.Application.Feature.visitor.Commands.updatevisitor;
using Microsoft.AspNetCore.Mvc;
using visitorclean.Application.Feature.visitor.Queries.GetByidvisitor;

using System.Threading.Tasks;
using System.Runtime.Versioning;
using System.Runtime.ExceptionServices;
using visitorclean.Infrastructure.Repository;
using AutoMapper;
using visitorclean.Application.Feature.Visit.Dto;

namespace visitorclean.Api.controller;


[Autorize]
[ApiController]

[Route("Api/Visitor")]
public class VisitorController : ControllerBase
{
    private readonly IMediator _mediator;

    private readonly IMapper _mapper;
    public VisitorController(IMediator mediator, IMapper mapper)
    {
        _mediator=mediator;
        _mapper= mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var visitor= await _mediator.Send(new GetAllvisitorquery());
        return Ok(visitor);

    }

    [HttpPost]
    public async Task<IActionResult>AddAsync([FromBody]CreateVisitorDto dto)
    {
        //transforme les DTO en command
        var command=_mapper.Map<CreateVisitorCommand>(dto);

        var reponse= await _mediator.Send(command);
        return Ok(reponse);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult>DeleteAsync( int id)
    {
    await _mediator.Send(new DeleteVisitorCommand(id));
    return NoContent();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult>GetByIdAsync(int id)
    {
        var visitor = await _mediator.Send(new GetByIdVisitorquery(id));
            if (visitor == null)
        
            return NotFound($"visitor avec  l'id {id} introuvable") ;
        
        return Ok(visitor);
    }

   [HttpPut("{id}")]
    public async Task<IActionResult>Update(int id ,[FromBody]UpdateVisitorDto dto)
    {   
         if (id != dto.Id){ 
            return BadRequest();} 
           
         
         var command=_mapper.Map<UpdateVisitorCommand>(dto);

         await _mediator.Send(command);
         return NoContent();
    }
   
    
   
}