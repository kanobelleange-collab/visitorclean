using MediatR;
using visitorclean.Application.Feature.role.Interface;
using visitorclean.Application.Feature.role.Dto;
using System;
using AutoMapper;

namespace visitorclean.Application.Feature.role.Queries.GetAllRole;


public class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQuery, IEnumerable<RoleDto>>
{
    private readonly IRoleRepository _repository;
    private readonly IMapper _mapper;

    public GetAllRolesQueryHandler(IRoleRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<RoleDto>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
    {
        var roles = await _repository.GetAllAsync();

        return _mapper.Map<IEnumerable<RoleDto>>(roles);
    }
}

