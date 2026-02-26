using System;
using visitorclean.Domain.Entities;


namespace visitorclean.Application.Feature.Dashboard.Dto;

public class DashboardDto
{
    public int TotalVisitors { get; set; }
    public int TotalUsers { get; set; }
    public int TotalVisits { get; set; }
    public int TodayVisits { get; set; }

    public List<MonthlyStatDto> MonthlyStats { get; set; } 
        = new();
}

public class MonthlyStatDto
{
    public required string Month { get; set; }
    public int VisitCount { get; set; }
}