using visitorclean.Domain.Entities;
using System;
using System.Threading.Tasks;
using MediatR;

namespace visitorclean.Application.Interface;

public interface IVisitRepository
{
    Task<List<Users>> GetAllAsync();
    Task<int>AddAsync(Users user);
    Task<Users>Update(Users user);
    Task<bool> DeleteAsync(int Id);
    Task<Users?>GetByIdAsync(int Id);

    
        

}