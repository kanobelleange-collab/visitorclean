using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Dapper;
using visitorclean.Domain.Entities.rolles_permissions;
using visitorclean.Application.Feature.users.Dto;
using visitorclean.Application.Feature.RolePermission.Dtos;
using visitorclean.Application.Feature.RolePermission.Interfaces;
namespace visitorclean.Infrastructure.Repositories.RolePermissionRepository;
public class RolePermissionRepository : IRolePermissionRepository
{
    private readonly string _connectionString;
    public RolePermissionRepository(IConfiguration configuration)
    {
        _connectionString=configuration.GetConnectionString("DefaultConnection")!;
    }
    public async Task<RolePermissionDto?>AddAsync(RolesPermission role_permission)
    {
        var sql=@"INSERT INTO RolePermission (RoleId, PermissionId) 
        VALUES (@RoleId, @PermissionId)";
        using var connection= new SqlConnection(_connectionString);
        return await connection.QuerySingleAsync<RolePermissionDto>(sql, role_permission);
    }
    public async Task<List<RolePermissionDto>> GetAllAsync()
    {
        const string sql = "SELECT * FROM RolesPermissions";
        using var connection= new SqlConnection(_connectionString);
        var result = await connection.QueryAsync<RolePermissionDto>(sql);
        return result.ToList();
    }

    public async Task<RolePermissionDto?> GetByIdAsync(int RoleId, int PermissionId)
    {
        const string sql = "SELECT * FROM RolesPermissions WHERE RoleId = @RoleId AND PermissionId = @PermissionId";

        using var connection= new SqlConnection(_connectionString);
        return await connection.QueryFirstOrDefaultAsync<RolePermissionDto>(sql, new { RoleId, PermissionId });
    }
}