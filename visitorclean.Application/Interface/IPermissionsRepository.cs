using System;
using visitorclean.Domain.Entities;



public interface IPermissionsRepository
{
    Task<IEnumerable<string>> GetPermissionsByUserIdAsync(int userId);
}