using visitorclean.Application.Service.Interface;
using visitorclean.Domain.Entities;
using System;
using MediatR;
using visitorclean.Application.Feature.Permission.Interface;


namespace visitorclean.Application.Service.PermissionService;

public class PermissionService : IPermissionService
{
    private readonly IDbConnection _connection;

    public async Task<bool> HasPermissionAsync(int userId, string permissionNom)
    {
        var sql = @"
            SELECT 1
            FROM Users u
            INNER JOIN RolePermissions rp ON rp.RoleId = u.RoleId
            INNER JOIN Permissions p ON p.Id = rp.PermissionId
            WHERE u.Id = @UserId
            AND p.Name = @PermissionNom
            LIMIT 1
        ";

        var result = await _connection.ExecuteScalarAsync<int?>(sql, new { userId, permissionNom });

        return result.HasValue;
    }
}