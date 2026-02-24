using visitorclean.Domain.Entities;
using visitorclean.Application;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using MediatR;


namespace visitorclean.Application.Interface;
public interface IVisitorRepository
{
    Task<int>AddAsync(Visitor visitor);
    Task<IEnumerable<Visitor>>GetAllAsync();
    Task<bool> DeleteAsync(int id );
    Task <Visitor>Update(Visitor visitor);
    Task <Visitor?>GetByIdAsync(int id);

}