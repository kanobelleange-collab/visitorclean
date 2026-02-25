using visitorclean.Domain.Entities;
using visitorclean.Application.role.Interface;
using Dapper;
using System.Data;
using System.ComponentModel.Design;
using Microsoft.VisualBasic;
using visitorclean.Infrastructure.Dbcontext;
using visitorclean.Application.Service;
using visitorclean.Application.role.Dto;

namespace visitorclean.Infrastructure.Repository;
public class RoleRepository : IRoleRepository
{
    private readonly DbContext _db;

    public RoleRepository(DbContext db)
    {
        _db = db;
    }

    public async Task<RoleDto> CreateAsync(Roles role)
    {
         using  var Connection = _db.CreateConnection();
        var sql = @"INSERT INTO Roles (Nom)
                    VALUES (@Nom);
                    SELECT CAST(SCOPE_IDENTITY() as int);";

        return await Connection.ExecuteScalarAsync<int>(sql, role);
    }

    public async Task UpdateAsync(Roles role)
    {
         using  var Connection = _db.CreateConnection();
        var sql = @"UPDATE Roles
                    SET Nom = @Nom
                    WHERE Id = @Id";

        await Connection.ExecuteAsync(sql, role);
    }

    public async Task DeleteAsync(int id)
    {
         using  var Connection = _db.CreateConnection();
        var sql = "DELETE FROM Roles WHERE Id = @Id";
        await Connection.ExecuteAsync(sql, new { Id = id });
    }

    public async Task<Roles?> GetByIdAsync(int id)
    {
         using  var Connection = _db.CreateConnection();
        var sql = "SELECT * FROM Roles WHERE Id = @Id";
        return await Connection.QueryFirstOrDefaultAsync<Role>(sql, new { Id = id });
    }

    public async Task<IEnumerable<Roles>> GetAllAsync()
    {
         using  var Connection = _db.CreateConnection();
        return await Connection.QueryAsync<Role>("SELECT * FROM Roles");
    }
}