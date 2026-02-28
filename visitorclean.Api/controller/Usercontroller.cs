using System;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using visitorclean.Application.Feature.users.Dto;
using visitorclean.Domain.Entities;
using System.Threading .Tasks;
using visitorclean.Application.Feature.users.Queries.Getalluser;
using visitorclean.Application.Feature.users.Queries.GetByiduser;
using visitorclean.Application.Feature.users.Queries.GetByEmailUser.GetByEmailUserQuery;
using visitorclean.Application.Feature.users.Commands.RegistreUser;
using visitorclean.Application.Feature.users.Queries.LoginUser;
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

 [AllowAnonymous]
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

  [HttpGet("{id:int}")]
    public async Task<IActionResult>GetByIdAsync(int id)
    {
        var user=await _mediator.Send(new GetByIdUserQuery(id));
        if (user==null) return NotFound();
        return Ok(user);
    }
    [HttpGet("{email}")]
    public async Task<IActionResult>GetByEmailAsync(string email)
    {
        var user=await _mediator.Send(new GetByEmailUserQuery(email));
        if (user==null) return NotFound();
        return Ok(user);
    }
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterUserCommand command)
    {
        // 1. Envoyer la commande au Handler via Mediator
        var userId = await _mediator.Send(command);

        // 2. Répondre avec le bon code HTTP
        return CreatedAtAction(nameof(Register), new { id = userId }, null);
    }

    [HttpGet("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserQuery query)
    {
        // 1. Envoyer la query pour vérification
        var authResponse = await _mediator.Send(query);

        // 2. Si le résultat est nul, les identifiants sont faux
        if (authResponse == null)
        {
            return Unauthorized(new { message = "Email ou mot de passe incorrect" });
        }

        // 3. Retourner le Token et les infos utilisateur
        return Ok(authResponse);
    }
}
