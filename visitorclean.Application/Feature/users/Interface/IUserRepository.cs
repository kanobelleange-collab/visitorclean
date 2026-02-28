using visitorclean.Domain.Entities.user;
using System;
using System.Threading.Tasks;
using visitorclean.Application.Feature.users.Dto;

namespace visitorclean.Application.Feature.users.Interface;

public interface IUserRepository
{
    Task<List<UserDto>> GetAllAsync();
    Task<int>CreateAsync(Users user);
    Task<UserDto>UpdateAsync(Users user);
    Task<bool> DeleteAsync(int Id);
    Task<Users?> GetByEmailAsync(string email);
    Task<UserDto?>GetByIdAsync(int Id);

}