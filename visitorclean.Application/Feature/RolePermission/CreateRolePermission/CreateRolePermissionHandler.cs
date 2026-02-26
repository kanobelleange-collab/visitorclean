using MediatR;
using AutoMapper;
using CleanVisitor.Core.Entities.RolesPermissions;
using CleanVisitor.Application.Features.RolePermission.Dtos;
using  CleanVisitor.Application.Features.RolePermission.Interfaces;
using CleanVisitor.Application.Features.Users.Commande.CreateUser;
using CleanVisitor.Application.Features.RolePermission.Command.CreateRolePermission;
namespace CleanVisitor.Application.Feautures.Users.Commande.CommandHandler;
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