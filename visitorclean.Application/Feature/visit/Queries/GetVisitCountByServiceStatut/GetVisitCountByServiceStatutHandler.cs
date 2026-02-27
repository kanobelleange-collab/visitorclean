using visitorclean.Application.Feature.visit.Dto.ServiceDto;
using MediatR;
using AutoMapper;
using visitorclean.Application.Feature.visit.Interface;
using visitorclean.Application.Feature.visit.Queries.GetVisitCountByServiceStatut;
namespace visitorclean.Application.Feature.visit.Queries.GetVisitCountByServiceStatut.GetVisitorCountByServiceHandler;
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