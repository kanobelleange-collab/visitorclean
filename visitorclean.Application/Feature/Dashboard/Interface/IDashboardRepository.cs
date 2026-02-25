using System;
using visitorclean.Domain.Entities;
using System.Threading.Tasks;
using visitorclean.Application.Dashboard.Interface;
using visitorclean.Application.Dashboard.Dto;


namespace visitorclean.Application.Dashboard.Interface;
public interface IDashboardRepository
{
    Task<DashboardDto> GetAdminDashboardAsync();
    Task<DashboardDto> GetAgentDashboardAsync(int userId);
}