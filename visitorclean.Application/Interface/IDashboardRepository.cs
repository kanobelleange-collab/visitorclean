using System;
using visitorclean.Domain.Entities;
using System.Threading.Tasks;

public interface IDashboardRepository
{
    Task<DashboardDto> GetAdminDashboardAsync();
    Task<DashboardDto> GetAgentDashboardAsync(int userId);
}