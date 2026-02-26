using System;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using visitorclean.Domain.Entities;
using visitorclean.Application.Feature.visitor.Queries.Getvisitorwithvisitdto;
using visitorclean.Application.Feature.visitor.Dto;

namespace visitorclean.Application.Feature.visitor.Queries.Getvisitorbyperiod;

public record GetVisitorByPeriodQuery(
    DateTime StartDate,
    DateTime EndDate,
    CancellationToken cancellationToken

):IRequest<List<VisitorWithVisitDto>>
{
    
}