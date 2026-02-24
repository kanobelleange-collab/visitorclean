using visitorclean.Domain.Entities;
using visitorclean.Application;
using MediatR;
using System;
using System.Net;
using visitorclean.Application.Feature.visitor.Queries.Getvisitorwithvisitdto;

namespace visitorclean.Application.Feature.visitor.Queries.Getvisitorwithvisitdto;

public sealed class GetVisitorWithVisitDtoquery : IRequest<List<VisitorWithVisitDto>>
{
    
}