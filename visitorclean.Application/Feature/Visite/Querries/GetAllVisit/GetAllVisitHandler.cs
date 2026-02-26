using MediatR;
using AutoMapper;
using visitorclean.Application.Feature.Visite.Interfaces;
using visitorclean.Domain.Entities;
using visitorclean.Application.Feature.Visite.Dtos;
using visitorclean.Application.Feature.Visite.Querries.GetAllVisit;
namespace visitorclean.Application.Features.Visite.Querries.GetAllVisit.GetAllVisitHandler;
public class GetAllVisitHandler:IRequestHandler<GetAllVisitQuery, List<VisitDto>>
{
    private readonly IVisitRepository _repository;
    private readonly IMapper _mapper;
    public GetAllVisitHandler(IVisitRepository repository, IMapper mapper)
    {
        _repository=repository;
        _mapper=mapper;
    }
    public async Task<List<VisitDto>>Handle(GetAllVisitQuery request, CancellationToken cancellationToken)
    {
       var visit=await _repository.GetAllAsync();
       var dto=_mapper.Map<List<VisitDto>>(visit);
       return dto;
    }
    }
