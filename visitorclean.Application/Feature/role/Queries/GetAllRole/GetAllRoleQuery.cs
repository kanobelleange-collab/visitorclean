
using System;
using MediatR;
using visitorclean.Application.Feature.role.Dto;

namespace visitorclean.Application.Feature.role.Queries.GetAllRole;



public class GetAllRolesQuery : IRequest<IEnumerable<RoleDto>>
{
}