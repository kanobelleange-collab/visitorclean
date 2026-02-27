using MediatR;
using visitorclean.Domain.Entities;
using visitorclean.Application.Feature.visit.Dto;
using visitorclean.Domain.Enum.VisitStatut;
using visitorclean.Domain.Enum.ServiceVisitor;
namespace visitorclean.Application.Feature.visit.Commands.updatevisit;
public record UpdateVisitCommand : IRequest<VisitDto>
{
    public int Id{get;set;}
    public string Motif{get;set;}=string.Empty;
    public DateTime Date{get; set;}
    public TimeSpan HeureArriver{get; set;}
    public TimeSpan HeureDepart{get; set;}
    public VisitStatut Statut{get;set;}
    public ServiceVisitor Service{get;set;}
    public int UserId{get;set;}
}