using visitorclean.Domain.Enum.VisitStatut;
using visitorclean.Domain.Enum.ServiceVisitor;
namespace visitorclean.Application.Feature.visit.Dto;
public class VisitDto
{
    public string Motif{get;set;}=string.Empty;
    public DateTime Date{get;set;}
    public TimeSpan HeureDepart{get;set;}
     public TimeSpan HeureArriver{get;set;}
    public VisitStatut Statut{get;set;}
     public ServiceVisitor Service{get;set;}

   
}