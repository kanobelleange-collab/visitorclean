using visitorclean.Domain.Entities.Permission;
using System;
using visitorclean.Application.Service;
namespace visitorclean.Application.Feature.Permission.Interface;

public interface IPermissionRepository
{
    

    Task<List<Permissions>> GetAllAsync();

    Task<List<string>> GetPermissionsByUserId(int userId);
}