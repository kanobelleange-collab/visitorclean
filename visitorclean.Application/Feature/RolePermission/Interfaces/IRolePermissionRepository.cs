using CleanVisitor.Application.Features.RolePermission.Dtos;
using CleanVisitor.Core.Entities.RolesPermissions;
namespace CleanVisitor.Application.Features.RolePermission.Interfaces;
public interface IRolePermissionRepository
{
    Task<RolePermissionDto?>AddAsync(RolePermissions role_permission);
}