using visitorclean.Domain.Entities;
using System;
using visitorclean.Application.Service;
namespace visitorclean.Application.Permission.Interface;

public interface IPermissionRepository
{
    

    Task<List<Permissions>> GetAllAsync();

    Task<List<string>> GetPermissionsByUserId(int userId);
}