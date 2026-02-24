using visitorclean.Domain.Entities;
using System;
using System.Threading.Tasks;
using MediatR;
using visitorclean.Domain.Enums;
using visitorclean.Application.DTOs;

namespace visitorclean.Application.Feature.visit.Commands.createvisit;

public record CreateVisitCommand : IRequest<VisitDto>
{
   
    public string? motif {get;set;}
     public  DateTime datevisit{get;set;}

    public Service_A_Visiter Service_A_Visiter{get; set;}
    public int idVisitor{get;set;}



}
