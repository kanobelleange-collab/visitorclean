using visitorclean.Application.Feature.RolePermission.Dtos;
using visitorclean.Domain.Entities.rolles_permissions;
namespace visitorclean.Application.Feature.RolePermission.Interfaces;
public interface IRolePermissionRepository
{
    Task<RolePermissionDto?>AddAsync(RolesPermission role_permission);
    Task<List<RolePermissionDto>> GetAllAsync();
    Task<RolePermissionDto?> GetByIdAsync(int RoleId, int PermissionId);
}