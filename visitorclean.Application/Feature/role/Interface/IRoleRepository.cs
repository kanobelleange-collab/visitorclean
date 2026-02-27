using System;
using visitorclean.Application.Feature.role.Dto;
using visitorclean.Domain.Entities.role;


namespace visitorclean.Application.Feature.role.Interface;
public interface IRoleRepository
{
    Task<Roles?> GetByNameAsync(string nom);
    Task<IEnumerable<Roles>> GetAllAsync();
    Task<RoleDto> CreateAsync(Roles role);
    Task UpdateAsync(Roles role);
    Task DeleteAsync(int id);
    Task<Roles?> GetByIdAsync(int id);

}