using MediatR;
using AutoMapper;
using visitorclean.Application.Feature.Visite.Interfaces;
using visitorclean.Domain.Entities;
using visitorclean.Application.Feature.Visite.Dtos;
using visitorclean.Application.Feature.Visite.Querries.GetByDateVisit;
namespace visitorclean.Application.Feature.Visite.Querries.GetByDateVisit.GetByDateVisitHandler;
public class GetByDateVisitHandler:IRequestHandler<GetByDateVisitQuery, VisitDto>
{
    private IVisitRepository _repository;
    private readonly IMapper _mapper;
    public GetByDateVisitHandler(IVisitRepository repository, IMapper mapper)
    {
        _repository=repository;
        _mapper=mapper;
    }
    public async Task<VisitDto>Handle(GetByDateVisitQuery request, CancellationToken cancellationToken)
    {
        var visit= await _repository.GetByDateAsync(request.Date);
        return _mapper.Map<VisitDto>(visit);
    }
}
