using visitorclean.Domain.Entities;
using visitorclean.Application.DTOs;
using System;


namespace visitorclean.Application.Feature.visitor.Queries.Getvisitorwithvisitdto;

public  sealed class VisitorWithVisitDto
{
    public int Id{get;set;}
    public  string Nom{get;set;}=string .Empty;

    public List<VisitDto>Visit{get;set;}=new List<VisitDto>();

}