using visitorclean.Application.Feature.RolePermission.Dtos;
using visitorclean.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace visitorclean.Application.Feature.RolePermission.Interfaces
{
    public interface IRolePermissionRepository
    {
        Task<RolePermissionDto?> AddAsync(RolesPermissions rolePermission);
        Task<List<RolePermissionDto>> GetAllAsync();
        Task<RolePermissionDto?> GetByIdAsync(int RoleId);
    }
}