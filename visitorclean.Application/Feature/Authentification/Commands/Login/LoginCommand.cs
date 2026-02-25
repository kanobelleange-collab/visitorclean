using System;
using visitorclean.Domain.Entities;
using MediatR;
using visitorclean.Application.Feature.Authentification.DTOs;


namespace visitorclean.Application.Feature.Authentification.Commands.Login;

public record LoginCommand(
    string Email,
    string Password) : IRequest<AuthResponseDto>;