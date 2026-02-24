using System;
using visitorclean.Application.DTOs;
using MediatR;
using visitorclean.Application.Interface;
using System.Threading.Tasks;
using System.Threading;
using visitorclean.Application.Feature.visit.Queries.Getallvisit;
using AutoMapper;

namespace visitorclean.Application.Feature.visit.Queries.Getallvisit;

public class GetAllVisitQueryHandler:IRequestHandler<GetAllVisitQuery, List<VisitDto>>
{
    private readonly IVisitRepository _repo;
    private readonly IMapper _mapper;

    public GetAllVisitQueryHandler(IVisitRepository repo ,IMapper mapper)
    {
        _repo=repo;
        _mapper=mapper;
    }

    public async Task <List<VisitDto>>Handle(GetAllVisitQuery request,CancellationToken cancellationToken)
    {
        var visits= await _repo.GetAllAsync();
        return _mapper.Map<List<VisitDto>>(visits);
    }

}