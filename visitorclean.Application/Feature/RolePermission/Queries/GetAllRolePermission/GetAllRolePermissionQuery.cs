using MediatR;
using visitorclean.Application.Feature.RolePermission.Dtos;
using System.Collections.Generic;

namespace visitorclean.Application.Feature.RolePermission.Queries.GetAllRolePermission
{
    public class GetAllRolePermissionQuery : IRequest<List<RolePermissionDto>>
    {
    }
}