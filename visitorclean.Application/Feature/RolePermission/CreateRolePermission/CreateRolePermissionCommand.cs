using MediatR;
using visitorclean.Application.Feature.RolePermission.Dtos;

namespace visitorclean.Application.Feature.RolePermission.Commands.CreateRolePermission;
public record CreateRolePermissionCommand : IRequest<RolePermissionDto>
{
    public int RoleId{get;set;}
    public int PermissionId{get;set;}
    public CreateRolePermissionCommand(int roleId, int permissionId)
    {
        RoleId=roleId;
        PermissionId=permissionId;
    }
}