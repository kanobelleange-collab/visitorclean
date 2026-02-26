using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Dapper;
using CleanVisitor.Core.Entities.RolesPermissions;
using CleanVisitor.Application.Features.Users.Dtos;
using CleanVisitor.Application.Features.RolePermission.Dtos;
using CleanVisitor.Application.Features.RolePermission.Interfaces;
namespace CleanVisitor.Infrastructure.Repositories.RolePermissionRepository;
public class RolePermissionRepository : IRolePermissionRepository
{
    private readonly string _connectionString;
    public RolePermissionRepository(IConfiguration configuration)
    {
        _connectionString=configuration.GetConnectionString("DefaultConnection")!;
    }
    public async Task<RolePermissionDto?>AddAsync(RolePermissions role_permission)
    {
        var sql=@"INSERT INTO RolePermission (RoleId, PermissionId) 
        VALUES (@RoleId, @PermissionId)";
        using var connection= new SqlConnection(_connectionString);
        return await connection.QuerySingleAsync<RolePermissionDto>(sql, role_permission);
    }
}