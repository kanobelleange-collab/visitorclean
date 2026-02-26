using System;
using System.Net;
using visitorclean.Domain.Entities;
using visitorclean.Application.Feature.visit.Dto;
using MediatR;


namespace visitorclean.Application.Feature.visit.Queries.Getallvisit;

public record GetAllVisitQuery (): IRequest<List<VisitDto>>
{
    
}