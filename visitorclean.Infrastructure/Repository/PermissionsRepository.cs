using Dapper;
using visitorclean.Application.Service.Interface;
using visitorclean.Domain.Entities;
using System.Data;
using visitorclean.Infrastructure.Dbcontext;


namespace visitorclean.Infrastructure.Repository;
public class PermissionRepository : IPermissionRepository
{
    private readonly DbContext _db;

    public PermissionRepository(DbContext db)
    {
        _db = db;
    }


    public async Task<List<Permissions>> GetAllAsync()
    {
          using  var Connection = _db.CreateConnection();
        var sql = "SELECT * FROM Permissions";

        var result = await _db.QueryAsync<Permissions>(sql);

        return result.ToList();
    }

    public async Task<List<string>> GetPermissionsByUserId(int userId)
    {
          using  var Connection = _db.CreateConnection();
        var sql = @"
            SELECT p.Name
            FROM Users u
            INNER JOIN RolePermissions rp ON u.RoleId = rp.RoleId
            INNER JOIN Permissions p ON rp.PermissionId = p.Id
            WHERE u.Id = @UserId
        ";

        var result = await _db.QueryAsync<string>(sql, new { UserId = userId });

        return result.ToList();
    }
}