using System;
using System.Net;
using visitorclean.Domain.Entities;
using visitorclean.Application.DTOs;
using MediatR;


namespace visitorclean.Application.Feature.visit.Queries.Getallvisit;

public record GetAllVisitQuery (): IRequest<List<VisitDto>>
{
    
}