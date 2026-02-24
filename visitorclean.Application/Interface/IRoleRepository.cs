using System;
using visitorclean.Application.DTOs;

namespace visitorclean.Application.Interface;
public interface IRoleRepository
{
    Task<Role?> GetByNameAsync(string nom);
    Task<IEnumerable<Role>> GetAllAsync();
    Task<RoleDto> CreateAsync(Role role);
    Task UpdateAsync(Role role);
    Task DeleteAsync(int id);
    Task<Role?> GetByIdAsync(int id);

}