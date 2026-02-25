using System;
using visitorclean.Domain.Entities;
using MediatR;
using System.Net;
using visitorclean.Application.Feature.role.Dto;


namespace visitorclean.Application.Feature.role.Commands.createRole;

public record CreateRoleCommand: IRequest<RoleDto>
{
    public int id {get;set;}
    public required string Nom{get;set;}
}