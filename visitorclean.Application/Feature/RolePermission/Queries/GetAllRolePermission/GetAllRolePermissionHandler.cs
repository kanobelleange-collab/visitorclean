using MediatR;
using visitorclean.Application.Feature.RolePermission.Dtos;
using visitorclean.Application.Feature.RolePermission.Interfaces;

namespace visitorclean.Application.Feature.RolePermission.Queries.GetAllRolePermissions;

public class GetAllRolePermissionsQueryHandler 
    : IRequestHandler<GetAllRolePermissionsQuery, List<RolePermissionDto>>
{
    private readonly IRolePermissionRepository _repository;

    public GetAllRolePermissionsQueryHandler(IRolePermissionRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<RolePermissionDto>> Handle(GetAllRolePermissionsQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetAllAsync();
    }
}