using visitorclean.Domain.Entities;
using visitorclean.Application.Interface;
using Dapper;
using System.Data;
using System.ComponentModel.Design;
using Microsoft.VisualBasic;
using visitorclean.Infrastructure.Dbcontext;
using visitorclean.Application.Service;



namespace visitorclean.Infrastructure.Repository;

public class VisitRepository:IVisitRepository{
    private readonly DbContext _db;

    public VisitRepository(DbContext db){
        _db=db;
    }
    public async Task<List<Visit>>GetAllAsync(){
    using var connection=_db.CreateConnection();
    const string sql= "SELECT*FROM  Visit";
    var result= await connection.QueryAsync<Visit>(sql);

    return result.ToList();
    }

    public async Task<int>AddAsync(Visit visit)
    {  
        using  var Connection = _db.CreateConnection();
      const string sql = @"
        INSERT INTO Visit (motif, datevisit, Service_A_Visiter,idVisitor)
        OUTPUT INSERTED.Id
        VALUES (@Motif, @Datevisit, @Service_A_Visiter,@idVisitor);
        ";
        var id= await Connection.ExecuteScalarAsync<int>(sql,visit);
        return id;

    }
    public async Task<bool> DeleteAsync(int id)
    {
        using  var Connection = _db.CreateConnection();
        const string sql= "DELETE FROM[Visit] WHERE [Id]=@Id";
        await Connection.ExecuteAsync(sql,new{Id=id});
        return true;
    }

    public async Task <Visit>Update(Visit visit)
    {
        using var connection=_db.CreateConnection();
        const string sql=@"UPDATE Visit
        SET
        Motif=@Motif,
        Datevisit=@Datevisit,
        idVisitor=@idVisitor,
        WHERE Id=@Id";
         await connection.ExecuteAsync(sql,visit);
        return visit;
    }
    public async Task<Visit?> GetByIdAsync(int id)
    {
        using var connection = _db.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<Visit>("SELECT * FROM Visit WHERE Id = @Id", new { Id = id });

    }
}







