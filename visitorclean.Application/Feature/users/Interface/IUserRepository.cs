using visitorclean.Domain.Entities.user;
using System;
using System.Threading.Tasks;
using MediatR;

namespace visitorclean.Application.Feature.users.Interface;

public interface IUserRepository
{
    Task<List<Users>> GetAllAsync();
    Task<int>CreateAsync(Users user);
    Task<Users>UpdateAsync(Users user);
    Task<bool> DeleteAsync(int Id);
    Task<Users?> GetByEmailAsync(string email);
    Task<Users?>GetByIdAsync(int Id);

    
        

}