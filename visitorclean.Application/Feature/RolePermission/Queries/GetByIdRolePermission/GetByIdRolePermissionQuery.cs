using MediatR;
using visitorclean.Application.Feature.RolePermission.Dtos;

namespace visitorclean.Application.Feature.RolePermission.Queries.GetRolePermissionById;

public class GetRolePermissionByIdQuery : IRequest<RolePermissionDto?>
{
    public int RoleId { get; set; }
    public int PermissionId{get;set;}

    public GetRolePermissionByIdQuery(int roleId, int permissionId)
    {
        RoleId = roleId;
        RoleId=permissionId;
    }
}