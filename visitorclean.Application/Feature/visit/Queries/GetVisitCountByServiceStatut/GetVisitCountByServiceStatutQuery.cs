using visitorclean.Application.Feature.visit.Dto.ServiceDto;
using MediatR;
namespace visitorclean.Application.Feature.visit.Queries.GetVisitCountByServiceStatut;
public record GetVisitCountByServiceStatutQuery:IRequest<List<ServiceDto>>{}