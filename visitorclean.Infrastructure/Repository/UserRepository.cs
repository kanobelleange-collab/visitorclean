using visitorclean.Domain.Entities;
using visitorclean.Application.Interface;
using Dapper;
using System.Data;
using System.ComponentModel.Design;
using Microsoft.VisualBasic;
using visitorclean.Infrastructure.Dbcontext;
using visitorclean.Application.Service;




public class UserRepository : IUserRepository
{
    private readonly DbContext _db;

    public UserRepository(DbContext db)
    {
        _db = db;
    }

    public async Task<int> CreateAsync(User user)
    { 
         using  var Connection = _db.CreateConnection();
        var sql = @"
            INSERT INTO Users (Username,Email,PasswordHash,RoleId,IsDeleted)
            VALUES (@Username,@Email,@PasswordHash,@RoleId,@IsDeleted);
            SELECT CAST(SCOPE_IDENTITY() as int);";

        return await Connection.ExecuteScalarAsync<int>(sql, user);
    }

    public async Task UpdateAsync(User user)
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

    public async Task<User?> GetByIdAsync(int id)
    {
         using  var Connection = _db.CreateConnection();
        var sql = "SELECT * FROM Users WHERE Id = @Id";
        return await Connection.QueryFirstOrDefaultAsync<User>(sql, new { Id = id });
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
         using  var Connection = _db.CreateConnection();
        var sql = "SELECT * FROM Users WHERE IsDeleted = 0";
        return await Connection.QueryAsync<User>(sql);
    }
}