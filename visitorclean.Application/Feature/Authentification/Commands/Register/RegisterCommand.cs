
using System;
using MediatR;

namespace visitorclean.Application.Feature.Authentification.Commands.Register;

public record RegisterCommand(
    string Username,
    string Email,
    string Password,
    int RoleId
) : IRequest<int>;