using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Dapper;
using visitorclean.Domain.Entities.RolesPermission;
using visitorclean.Domain.Entities.user;
using visitorclean.Application.Feature.RolePermission.Dtos;
using visitorclean.Application.Features.RolePermission.Interfaces;
namespace CleanVisitor.Infrastructure.Repositories.RolePermissionRepository;
public class RolePermissionRepository : IRolePermissionRepository
{
    private readonly string _connectionString;
    public RolePermissionRepository(IConfiguration configuration)
    {
        _connectionString=configuration.GetConnectionString("DefaultConnection")!;
    }
    public async Task<RolePermissionDto?>AddAsync(RolesPermissions role_permission)
    {
        var sql=@"INSERT INTO RolePermission (RoleId, PermissionId) 
        VALUES (@RoleId, @PermissionId)";
        using var connection= new SqlConnection(_connectionString);
        return await connection.QuerySingleAsync<RolePermissionDto>(sql, role_permission);
    }
    public async Task<List<RolePermissionDto>>GetAllAsync()
    {
        var sql=@"SELECT* FROM [RolesPermissions]
        WHERE Id=@RoleId AND Id=PermissionId";
        using var connection=new SqlConnection(_connectionString);
        var role_permission= await connection.QueryAsync<RolePermissionDto>(sql);
        return role_permission.ToList();
    }
    public async Task<RolePermissionDto?>GetByIdAsync(int RoleId)
    {
        var sql=@"SELECT* FROM [RolePermission]
        WHERE RoleId=@RoleId";
        using var connection=new SqlConnection(_connectionString);
        return await connection.QueryFirstOrDefaultAsync<RolePermissionDto>(sql, new{RoleId});
    }
}