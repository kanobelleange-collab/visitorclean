using visitorclean.Domain.Entities;
using System;
using System.Threading.Tasks;
using MediatR;
using visitorclean.Application.Interface;
using visitorclean.Application.Feature.visit.Queries.GetByidvisit;
using AutoMapper;
using visitorclean .Application.DTOs;

namespace visitorclean.Application.Feature.visit.Queries.GetByidvisit;

public class GetByIdVisitqueryHandler:IRequestHandler<GetByIdVisitquery, VisitDto>
{
    private readonly IVisitRepository  _repo;
    private readonly IMapper _mapper;

    public GetByIdVisitqueryHandler(IVisitRepository repo ,IMapper mapper)
    {
        _repo=repo;
        _mapper=mapper;
    }
    public async Task<VisitDto>Handle(GetByIdVisitquery request,CancellationToken cancellationToken)
    {
       
        var visit= await _repo.GetByIdAsync (request.Id);

        return _mapper.Map<VisitDto>(visit);
    }
}

