using visitorclean.Domain.Entities;
using visitorclean.Application.DTOs;
using visitorclean.Domain.Enums;

namespace visitorclean.Application.Feature.visit.Commands.updatevisit;

public class UpdateVisitDto
{
    public string? motif{get;set;}
    public DateTime datevisit{get;set;}
    public Service_A_Visiter Service_A_Visiter{get;private set;}

    public int idVisitor{get;set;}
    
    
}