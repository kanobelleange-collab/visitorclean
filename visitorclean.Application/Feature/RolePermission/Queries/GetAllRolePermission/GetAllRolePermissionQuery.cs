using MediatR;
using visitorclean.Application.Feature.RolePermission.Dtos;

namespace visitorclean.Application.Feature.RolePermission.Queries.GetAllRolePermissions;

public class GetAllRolePermissionsQuery : IRequest<List<RolePermissionDto>>
{
}