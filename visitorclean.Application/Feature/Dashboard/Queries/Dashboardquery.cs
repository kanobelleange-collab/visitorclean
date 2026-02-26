using System;
using visitorclean.Domain.Entities;
using MediatR;
using visitorclean.Application.Feature.Dashboard.Dto;

namespace visitorclean.Application.Feature.Dashboard.Queries;

public record GetDashboardQuery(int UserId)
    : IRequest<DashboardDto>
{
    public int UserId{get;set;}
}