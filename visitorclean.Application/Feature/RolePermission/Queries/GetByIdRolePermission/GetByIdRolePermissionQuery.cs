using MediatR;
using visitorclean.Application.Feature.RolePermission.Dtos;

namespace visitorclean.Application.Feature.RolePermission.Queries.GetByIdRolePermission
{
    public class GetByIdRolePermissionQuery : IRequest<RolePermissionDto?>
    {
        public int RoleId { get; set; }

        public GetByIdRolePermissionQuery(int roleId)
        {
            RoleId = roleId;
        }
    }
}