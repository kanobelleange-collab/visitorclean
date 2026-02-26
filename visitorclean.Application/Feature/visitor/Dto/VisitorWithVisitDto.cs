using visitorclean.Domain.Entities;
using visitorclean.Application.Feature.visitor.Dto;
using System;
using visitorclean.Application.Feature.visit.Dto;


namespace visitorclean.Application.Feature.visitor.Dto;

public  sealed class VisitorWithVisitDto
{
    public int Id{get;set;}
    public  string Nom{get;set;}=string .Empty;

    public List<VisitDto>Visit{get;set;}=new List<VisitDto>();

}