using visitorclean.Application.Service.Interface;
using visitorclean.Domain.Entities;
using System;
using MediatR;
using visitorclean.Application.Feature.Permission.Interface;


namespace visitorclean.Infrastructure.Repository;

public class PermissionService : IPermissionService
{
    private readonly IPermissionRepository _permissionRepository;
    

    public PermissionService(IPermissionRepository permissionRepository)
    {
        _permissionRepository = permissionRepository;
    }

    public async Task<bool> HasPermission(int userId, string permissionNom)
    {
        if (string.IsNullOrWhiteSpace(permissionNom))
            return false;

        var permissions = await _permissionRepository
            .GetPermissionsByUserId(userId);

        return permissions
            .Any(p => p.Equals(permissionNom, 
                StringComparison.OrdinalIgnoreCase));
    }
}