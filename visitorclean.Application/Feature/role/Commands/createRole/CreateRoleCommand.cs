using System;
using visitorclean.Domain.Entities;
using MediatR;
using System.Net;


namespace visitorclean.Application.Feature.role.Commands.createRole;

public record CreateRoleCommand: IRequest<RoleDto>
{
    public int id {get;set;}
    public string Nom{get;set;}
}