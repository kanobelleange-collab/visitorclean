using visitorclean.Domain.Entities;
using visitorclean.Application.Feature.users.Interface;
using Dapper;
using System.Data;
using System.ComponentModel.Design;
using Microsoft.VisualBasic;
using visitorclean.Infrastructure.Dbcontext;
using visitorclean.Application.Service;

namespace visitorclean.Infrastructure.Repository;


public class UserRepository : IUserRepository
{
    private readonly DbContext _db;

    public UserRepository(DbContext db)
    {
        _db = db;
    }

    public async Task<int> CreateAsync(Users user)
    { 
         using  var Connection = _db.CreateConnection();
        var sql = @"
            INSERT INTO Users (Username,Email,PasswordHash,RoleId,IsDeleted)
            VALUES (@Username,@Email,@PasswordHash,@RoleId,@IsDeleted);
            SELECT CAST(SCOPE_IDENTITY() as int);";

        return await Connection.ExecuteScalarAsync<int>(sql, user);
    }
     public async Task<User?> GetByEmailAsync(string email)
    {
        var sql = "SELECT * FROM Users WHERE Email = @Email";

        return await _connection.QueryFirstOrDefaultAsync<User>(
            sql,
            new { Email = email });
    }

    public async Task UpdateAsync(Users user)
    {
         using  var Connection = _db.CreateConnection();
        var sql = @"
            UPDATE Users
            SET Username = @Username,
                Email = @Email,
                RoleId = @RoleId
            WHERE Id = @Id";

        await Connection.ExecuteAsync(sql, user);
    }

    public async Task DeleteAsync(int id)
    {
         using  var Connection = _db.CreateConnection();
        var sql = "UPDATE Users SET IsDeleted = 1 WHERE Id = @Id";
        await Connection.ExecuteAsync(sql, new { Id = id });
    }

    public async Task<Users?> GetByIdAsync(int id)
    {
         using  var Connection = _db.CreateConnection();
        var sql = "SELECT * FROM Users WHERE Id = @Id";
        return await Connection.QueryFirstOrDefaultAsync<User>(sql, new { Id = id });
    }

    public async Task<IEnumerable<Users>> GetAllAsync()
    {
         using  var Connection = _db.CreateConnection();
        var sql = "SELECT * FROM Users WHERE IsDeleted = 0";
        return await Connection.QueryAsync<User>(sql);
    }
}