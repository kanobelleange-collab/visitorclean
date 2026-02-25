using visitorclean.Domain.Entities;
using visitorclean.Application.Feature.visit.Dto;
using AutoMapper;
using MediatR;
using visitorclean.Application.Feature.visit.Interface;
using visitorclean.Domain.Enums;

namespace visitorclean.Application.Feature.visit.Commands.updatevisit;

public record UpdateVisitCommand:IRequest<VisitDto>
{
    public int Id { get; set; } 
    public string? motif{get;set;}
    public DateTime datevisit{get;set;}

    public Service_A_Visiter Service_A_Visiter{get;set;}

    public int idVisitor{get;set;}

    

}

