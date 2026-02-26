using visitorclean.Application.Feature.Visite.Dtos.ServiceDto;
using MediatR;
namespace visitorclean.Application.Feature.Visite.Querries.GetVisitCountByServiceStatut.GetVisitCountByServiceStatutQuery;
public record GetVisitCountByServiceStatutQuery:IRequest<List<ServiceDto>>{}