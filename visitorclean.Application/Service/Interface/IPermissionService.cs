using System;
using visitorclean.Domain.Entities;


namespace visitorclean.Application.Service.Interface;

public interface IPermissionService
{
    Task<bool> HasPermission(int userId, string permissionNom);
}