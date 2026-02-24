using System;
using visitorclean.Application.Feature.Dashboard.Queries;
using MediatR;
using visitorclean.Domain.Entities;
using visitorclean.Application.DTOs;


namespace visitorclean. Application.Feature.Dashboard.Queries;

public class GetDashboardQueryHandler 
    : IRequestHandler<GetDashboardQuery, DashboardDto>
{
    private readonly IDashboardRepository _repo;
    private readonly IUserRepository _userRepo;

    public GetDashboardQueryHandler(
        IDashboardRepository repo,
        IUserRepository userRepo)
    {
        _repo = repo;
        _userRepo = userRepo;
    }

    public async Task<DashboardDto> Handle(
        GetDashboardQuery request,
        CancellationToken cancellationToken)
    {
        var user = await _userRepo.GetByIdAsync(request.UserId);

        if (user.Role.Name == "Admin")
        {
            return await _repo.GetAdminDashboardAsync();
        }
        else
        {
            return await _repo.GetAgentDashboardAsync(user.Id);
        }
    }
}

