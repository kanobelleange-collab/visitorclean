using visitorclean.Application.Feature.Visite.Dtos.ServiceDto;
using MediatR;
using AutoMapper;
using visitorclean.Application.Feature.Visite.Interfaces;
using visitorclean.Application.Feature.Visite.Querries.GetVisitCountByServiceStatut.GetVisitCountByServiceStatutQuery;
namespace visitorclean.Application.Feature.Visitors.Querries.GetVisitCountByServiceStatut.GetVisitorCountByServiceHandler;
public class GetVisitCountByServiceHandler:IRequestHandler<GetVisitCountByServiceStatutQuery, List<ServiceDto>>
{
    private readonly IVisitRepository _repository;
    private readonly IMapper _mapper;
    public GetVisitCountByServiceHandler(IVisitRepository repository, IMapper mapper)
    {
        _repository=repository;
        _mapper=mapper;
    }
    public async Task<List<ServiceDto>>Handle(GetVisitCountByServiceStatutQuery request, CancellationToken cancellationToken)
    {
        var visitor=await _repository.GetVisitCountByServiceStatutAsync();
        return _mapper.Map<List<ServiceDto>>(visitor);
        

    }
}