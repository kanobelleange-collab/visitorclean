using System;
using visitorclean.Domain.Entities;
using MediatR;
using visitorclean.Application.DTOs;

namespace vivitorclean.Application.Feature.Dashboard.Queries;

public record GetDashboardQuery(int UserId)
    : IRequest<DashboardDto>
{
    
}