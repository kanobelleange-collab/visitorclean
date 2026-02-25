using visitorclean.Domain.Entities;
using System;
using System.Threading.Tasks;
using MediatR;

namespace visitorclean.Application.Feature.users.Interface;

public interface IUserRepository
{
    Task<List<Users>> GetAllAsync();
    Task<int>CreateAsync(Users user);
    Task<Users>Update(Users user);
    Task<bool> DeleteAsync(int Id);
    Task<User?> GetByEmailAsync(string email);
    Task<Users>GetByIdAsync(int Id);

    
        

}