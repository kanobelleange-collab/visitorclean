using MediatR;
using AutoMapper;
using visitorclean.Application.Feature.Visite.Interfaces;
using visitorclean.Application.Feature.RolePermission.Dtos;
using visitorclean.Application.Features.RolePermission.Interfaces;
using visitorclean.Application.Feature.RolePermission.Queries.GetByIdRolePermission.GetByIdRolePermissionQuery;

namespace visitorclean.Application.Feature.Visite.Querries.GetRolePermission.GetByIdRolePermissionHandler;
public class GetByIdRolePermissionHandler:IRequestHandler<GetByIdRolePermissionQuery, RolePermissionDto>
{
    private readonly IRolePermissionRepository _repository;
    private readonly IMapper _mapper;
    public GetByIdRolePermissionHandler(IRolePermissionRepository repository, IMapper mapper)
    {
        _repository=repository;
        _mapper=mapper;
    }
    public async Task<RolePermissionDto>Handle(GetByIdRolePermissionQuery request, CancellationToken cancellationToken)
    {
       var role_permission=await _repository.GetByIdAsync(request.RoleId);
       return _mapper.Map<RolePermissionDto>(role_permission);
    }
    }
