using MediatR;
using visitorclean.Domain.Entities;
using visitorclean.Application.Interface;
using Dapper;
using System.Data;
using System.ComponentModel.Design;
using Microsoft.VisualBasic;
using visitorclean.Infrastructure.Dbcontext;
using visitorclean.Application.Service;
using visitorclean.Application.Feature.visitor.Queries.Getvisitorwithvisitdto;
using visitorclean.Application.DTOs;



namespace visitorclean.Infrastructure.Repository;


public class VisitorWithVisitRepository:IVisitorReadRepository{
    private readonly DbContext _db;
    public VisitorWithVisitRepository(DbContext db)
    {
        _db=db;
    }


public async Task<List<VisitorWithVisitDto>> GetVisitorByPeriodAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken)
{
    using var connection = _db.CreateConnection();

    var sql = @"
        SELECT v.Id, v.Nom,
               vis.Id, vis.Date
        FROM Visitor v
        LEFT JOIN Visit vis ON v.Id = vis.idVisitor
        WHERE vis.Date BETWEEN @StartDate AND @EndDate
        ORDER BY vis.Date";

    var command = new CommandDefinition(
        sql,
        new { StartDate = startDate, EndDate = endDate },
        cancellationToken: cancellationToken
    );

    var result = await connection.QueryAsync<VisitorWithVisitDto>(command);

    return result.ToList();
}
 public async Task<List<VisitorWithVisitDto>> GetVisitorWithVisitAsync(CancellationToken cancellationToken)
    {
         using var connection = _db.CreateConnection();

    var sql = @"
        SELECT v.Id, v.Nom,
               vis.Id, vis.DateVisit, vis.Motif
        FROM Visitor v
        LEFT JOIN Visit vis ON v.Id = vis.idVisitor";
        var visitorDictionary = new Dictionary<int, VisitorWithVisitDto>();

        var result = await connection.QueryAsync<VisitorWithVisitDto, VisitDto, VisitorWithVisitDto>(
            sql,
            (visitor, visit) =>
            {
                if (!visitorDictionary.TryGetValue(visitor.Id, out var existingVisitor))
                {
                    existingVisitor = visitor;
                    existingVisitor.Visit = new List<VisitDto>();
                    visitorDictionary.Add(existingVisitor.Id, existingVisitor);
                }

                if (visit != null)
                {
                    existingVisitor.Visit.Add(visit);
                }

                return existingVisitor;
            },
            splitOn: "Id"
        );

        return visitorDictionary.Values.ToList();
    }
}
