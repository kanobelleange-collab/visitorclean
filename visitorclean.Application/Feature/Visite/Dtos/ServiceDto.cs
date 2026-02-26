using visitorclean.Domain.Enum.ServiceVisitor;
using visitorclean.Domain.Enum.VisitStatut;
namespace visitorclean.Application.Feature.Visite.Dtos.ServiceDto;
public class ServiceDto
{
    public ServiceVisitor Service{get;set;}
    public VisitStatut Statut{get;set;}
    public int Total_visit{get;set;}
}