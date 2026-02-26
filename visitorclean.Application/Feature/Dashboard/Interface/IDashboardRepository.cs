using System;
using visitorclean.Domain.Entities;
using System.Threading.Tasks;
using visitorclean.Application.Feature.Dashboard.Interface;
using visitorclean.Application.Feature.Dashboard.Dto;


namespace visitorclean.Application.Feature.Dashboard.Interface;
public interface IDashboardRepository
{
    Task<DashboardDto> GetAdminDashboardAsync();
    Task<DashboardDto> GetAgentDashboardAsync(int userId);
}