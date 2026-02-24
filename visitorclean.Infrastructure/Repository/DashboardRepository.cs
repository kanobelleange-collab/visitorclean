using visitorclean.Domain.Entities;
using visitorclean.Application.Interface;
using Dapper;
using System.Data;
using System.ComponentModel.Design;
using Microsoft.VisualBasic;
using visitorclean.Infrastructure.Dbcontext;
using visitorclean.Application.Service;
using AutoMapper;


namespace visitorclean.Infrastructure.Repository;

public class DashboardRepository: IDashboardRepository{
    private readonly DbContext _db;

    public DashboardRepository( DbContext db)
    {
        _db=db;
        
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
        (await GetMonthlyStatsAsync()).ToList();

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
        (await GetMonthlyStatsByUserAsync(userId)).ToList();

        return dashboard;
    }

    public async Task<IEnumerable<MonthlyStatDto>> GetMonthlyStatsAsync()
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

        return await Connection.QueryAsync<MonthlyStatDto>(sql);
    }
}