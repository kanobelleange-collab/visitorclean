using  visitorclean.Domain.Enum. ServiceVisitor;
using visitorclean.Domain.Enum. VisitStatut;
namespace visitorclean.Domain.Entities;
public class Visit
{
    public int Id{get;set;}
    public int IdVisitor{get;set;}
    public string Motif{get;set;}=string.Empty;
    public DateTime Date{get;set;}
    public TimeSpan HeureArriver{get;set;}
    public TimeSpan HeureDepart{get; set;}
    public VisitStatut Statut{get;set;}
    public ServiceVisitor Service{get;set;}

}