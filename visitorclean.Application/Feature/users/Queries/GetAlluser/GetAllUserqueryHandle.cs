using System;
using visitorclean.Application.Feature.users.Dto;
using MediatR;
using visitorclean.Application.Feature.users.Interface;
using System.Threading.Tasks;
using System.Threading;
using visitorclean.Application.Feature.users.Queries.Getalluser;
using AutoMapper;
using visitorclean.Application.Feature.visit.Interface;

namespace visitorclean.Application.Feature.users.Queries.Getalluser;

public class GetAllUserQueryHandler:IRequestHandler<GetAllUserQuery, List<UserDto>>
{
    private readonly IVisitRepository _repo;
    private readonly IMapper _mapper;

    public GetAllUserQueryHandler(IVisitRepository repo ,IMapper mapper)
    {
        _repo=repo;
        _mapper=mapper;
    }

    public async Task <List<UserDto>>Handle(GetAllUserQuery request,CancellationToken cancellationToken)
    {
        var user= await _repo.GetAllAsync();
        return _mapper.Map<List<UserDto>>(user);
    }

}