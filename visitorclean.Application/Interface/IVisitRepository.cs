using visitorclean.Domain.Entities;
using System;
using System.Threading.Tasks;
using MediatR;

namespace visitorclean.Application.Interface;

public interface IVisitRepository
{
    Task<List<Visit>> GetAllAsync();
    Task<int>AddAsync(Visit visit);
    Task<Visit>Update(Visit visit);
    Task<bool> DeleteAsync(int Id);
    Task<Visit?>GetByIdAsync(int Id);

    
        

}