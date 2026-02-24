
using System;
using MediatR;
using visitorclean.Domain.Entities;
using visitorclean .Application.Feature.Permissions;
using System.Threading.Tasks;



public class PermissionRepository : IPermissionRepository
{
    private readonly DbContext _db;

    public PermissionRepository(DbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<string>> GetPermissionsByUserIdAsync(int userId)
    {
         using  var Connection = _db.CreateConnection();
        var sql = @"
            SELECT p.Nom
            FROM Users u
            INNER JOIN Roles r ON u.RoleId = r.Id
            INNER JOIN RolePermissions rp ON r.Id = rp.RoleId
            INNER JOIN Permissions p ON rp.PermissionId = p.Id
            WHERE u.Id = @UserId";

        return await Connection.QueryAsync<string>(sql, new { UserId = userId });
    }
}