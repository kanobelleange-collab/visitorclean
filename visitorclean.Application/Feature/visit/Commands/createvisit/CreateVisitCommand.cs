using MediatR;
using visitorclean.Domain.Enum.VisitStatut;
using visitorclean.Domain.Enum.ServiceVisitor;
using visitorclean.Application.Feature.visit.Dto;
using visitorclean.Domain.Entities;
namespace visitorclean.Application.Feature.visit.Commands.createvisit;

public record CreateVisitCommand : IRequest<VisitDto>
{
    public string Motif{get;set;}=string.Empty;
    public DateTime Date{get;set;}
    public TimeSpan HeureDepart{get;set;}
    public TimeSpan HeureArriver{get; set;}
    public VisitStatut Statut{get;set;}
    public ServiceVisitor Service{get;set;}
    public int IdVisitor {get;set;}
    public int UserId{get;set;}
}