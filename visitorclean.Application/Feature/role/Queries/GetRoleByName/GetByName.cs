
using System;
using MediatR;
using visitorclean.Application.Feature.role.Dto;

namespace visitorclean.Application.Feature.role.Queries.GetRoleByName;

public record GetByNameQuery(string Nom) 
    : IRequest<RoleDto?>;