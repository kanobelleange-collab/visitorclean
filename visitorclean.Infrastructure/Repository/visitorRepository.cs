using visitorclean.Domain.Entities;
using visitorclean.Domain.Entities.user;
using visitorclean.Application.Feature.visitor.Interface;
using Dapper;
using System.Data;
using System.ComponentModel.Design;
using visitorclean.Application.Feature.visitor.Commands.deletevisitor;
using Microsoft.VisualBasic;
using visitorclean.Infrastructure.Dbcontext;
using visitorclean.Application.Service;



namespace visitorclean.Infrastructure.Repository;

public class VisitorRepository:IVisitorRepository{
    private readonly DbContext _db;

    public VisitorRepository(DbContext db){
        _db=db;
    }
    public async Task<IEnumerable<Visitor>>GetAllAsync(){
    using var connection=_db.CreateConnection();
    const string sql= "SELECT*FROM  Visitor";
    return await connection.QueryAsync<Visitor>(sql);
    }

    public async Task<int>AddAsync(Visitor visitor)
    {  
        using  var Connection = _db.CreateConnection();
      const string sql = @"
        INSERT INTO Visitor (Nom, Email, Passwordhash, CreatedAT)
        OUTPUT INSERTED.Id
        VALUES (@Nom, @Email, @Passwordhash, @CreatedAT);
    ";
        var id= await Connection.ExecuteScalarAsync<int>(sql,visitor);
        return id;

    }
    public async Task<bool> DeleteAsync(int id, int userId)
    {
        using  var Connection = _db.CreateConnection();
        const string sql= "DELETE FROM[Visitor] WHERE [Id]=@Id";
        await Connection.ExecuteAsync(sql,new{Id=id, UserId=userId});
        return true;
    }

    public async Task <Visitor>Update(Visitor visitor)
    {
        using var connection=_db.CreateConnection();
        const string sql=@"UPDATE Visitor
        SET
        Nom=@Nom,
        Email=@Email,
        Passwordhash= HASHBYTES('SHA2_256' ,@passwordhash)
        WHERE Id=@Id";
         await connection.ExecuteAsync(sql,visitor);
        return visitor;
    }
    public async Task<Visitor?> GetByIdAsync(int id)
    {
        using var connection = _db.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<Visitor>("SELECT * FROM Visitor WHERE Id = @Id", new { Id = id });

    }
}






