using System;
using visitorclean.Application.Feature.visit.Dto;
using visitorclean.Application.Feature.visit.Queries;
using MediatR; 
using visitorclean.Domain.Entities;

namespace visitorclean.Application.Feature.visit.Queries.GetByidvisit;

public record GetByIdVisitquery:IRequest<VisitDto>
{
    public int  Id{get;set;}
    public GetByIdVisitquery(int id)
    {
        Id=id;
    }
}
