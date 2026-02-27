using MediatR;
using AutoMapper;
using MediatR;
using visitorclean.Application.Feature.RolePermission.Dtos;
using visitorclean.Application.Feature.RolePermission.Interfaces;
using visitorclean.Domain.Entities.RolesPermissions;
using visitorclean.Application.Feature.RolePermission.Command.CreateRolePermission;
namespace visitorclean.Application.Feature.RolePermission.Command.CreateRolePermission.CreateRolePermissionHandler;
public class CreateRolePermissionHandler:IRequestHandler<CreateRolePermissionCommand, RolePermissionDto>
{
    private readonly IRolePermissionRepository _repository;
    private readonly IMapper _mapper;
    public CreateRolePermissionHandler(IRolePermissionRepository repository, IMapper mapper)
    {
        _repository=repository;
        _mapper=mapper;
    }
    public async Task<RolePermissionDto>Handle(CreateRolePermissionCommand request, CancellationToken cancellationToken)
    {
        
        var role_permission=_mapper.Map<RolePermissions>(request);
         await _repository.AddAsync(role_permission);
         return _mapper.Map<RolePermissionDto>(role_permission);
    }
}