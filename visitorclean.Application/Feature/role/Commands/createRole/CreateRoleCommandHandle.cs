using MediatR;
using AutoMapper;
using visitorclean.Application.Feature.role.Dto;
using visitorclean.Application.Feature.role.Interface;
using visitorclean.Domain.Entities.role;
using visitorclean.Application.Service.Interface;
using visitorclean.Application.Common;

namespace visitorclean.Application.Feature.role.Commands.createRole;

public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, RoleDto>
{
    private readonly IRoleRepository _repo;
    private readonly IMapper _mapper;
    private readonly IPermissionService _permissionService;

    public CreateRoleCommandHandler(IRoleRepository repo, IMapper mapper,IPermissionService permissionService)
    {
        _repo = repo;
        _mapper = mapper;
        _permissionService=permissionService;
    }
    public async Task <RoleDto>Handle(CreateRoleCommand request,CancellationToken cancellationToken)
    {
        var hasPermission = await _permissionService
            .HasPermission(request.UserId, AppPermission.CreateRole);

        if (!hasPermission)
            throw new UnauthorizedAccessException();
    


   
        // 1️⃣ Mapper Command → Entity
        var role = _mapper.Map<Roles>(request);

        // 2️⃣ Sauvegarde en base
        var result = await _repo.CreateAsync(role);

        
        

        // 4️⃣ Retourner DTO
        return _mapper.Map<RoleDto>(role);
    }
}