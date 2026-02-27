using visitorclean.Domain.Entities;
using visitorclean.Application.Feature.Dashboard.Interface;
using Dapper;
using System.Data;
using System.ComponentModel.Design;
using Microsoft.VisualBasic;
using visitorclean.Infrastructure.Dbcontext;
using visitorclean.Application.Service;
using AutoMapper;
using visitorclean.Application.Feature.Dashboard.Dto;
using System.IO.Pipelines;


namespace visitorclean.Infrastructure.Repository;

public class DashboardRepository: IDashboardRepository{
    private readonly DbContext _db;

    public DashboardRepository( DbContext db)
    {
        _db=db;
        
    }
    public async Task<List<MonthlyStatsDto>> GetMonthlyStatsByUserAsync(int userId)
{
     using  var Connection = _db.CreateConnection();
    var sql = @"
    SELECT 
        MONTH(DateVisit) AS Month,
        COUNT(*) AS VisitCount
    FROM Visit
    WHERE UserId = @UserId
    GROUP BY MONTH(DateVisit)
    ORDER BY Month;
    ";

    var result =await Connection.QueryAsync<MonthlyStatsDto>(sql, new { UserId = userId });
        return result.ToList();
    }


    public async Task<DashboardDto> GetAdminDashboardAsync()
    {
         using  var Connection = _db.CreateConnection();
        var sql = @"
        SELECT 
            (SELECT COUNT(*) FROM Visitor) AS TotalVisitors,
            (SELECT COUNT(*) FROM Users) AS TotalUsers,
            (SELECT COUNT(*) FROM Visit) AS TotalVisits,
            (SELECT COUNT(*) FROM Visit 
             WHERE CAST(DateVisit AS DATE) = CAST(GETDATE() AS DATE)) 
             AS TodayVisits
        ";

        var dashboard = await Connection.QueryFirstAsync<DashboardDto>(sql);

        dashboard.MonthlyStats = 
        await GetMonthlyStatsAsync();

    return dashboard;


    }

    public async Task<DashboardDto> GetAgentDashboardAsync(int userId)
    {
         using  var Connection = _db.CreateConnection();
        var sql = @"
        SELECT 
            COUNT(*) AS TotalVisits,
            SUM(CASE 
                WHEN CAST(DateVisit AS DATE) = CAST(GETDATE() AS DATE) 
                THEN 1 ELSE 0 END) AS TodayVisits
        FROM Visit
        WHERE UserId = @UserId
        ";

        var dashboard = await Connection.QueryFirstAsync<DashboardDto>(sql, new { UserId = userId });

        dashboard.MonthlyStats =
        await GetMonthlyStatsByUserAsync(userId);
        

        return dashboard;
    }

    public async Task<List<MonthlyStatsDto>> GetMonthlyStatsAsync()
    {
         using  var Connection = _db.CreateConnection();
        var sql = @"
        SELECT 
            FORMAT(DateVisit, 'yyyy-MM') AS Month,
            COUNT(*) AS VisitCount
        FROM Visit
        GROUP BY FORMAT(DateVisit, 'yyyy-MM')
        ORDER BY Month
        ";

        var result=  await Connection.QueryAsync<MonthlyStatsDto>(sql);
        return result .ToList();
    }
}