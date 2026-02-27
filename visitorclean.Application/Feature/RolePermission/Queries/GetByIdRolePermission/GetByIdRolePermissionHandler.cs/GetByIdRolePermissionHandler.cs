using MediatR;
using visitorclean.Application.Feature.RolePermission.Dtos;
using visitorclean.Application.Feature.RolePermission.Interfaces;

namespace visitorclean.Application.Feature.RolePermission.Queries.GetRolePermissionById;

public class GetRolePermissionByIdQueryHandler 
    : IRequestHandler<GetRolePermissionByIdQuery, RolePermissionDto?>
{
    private readonly IRolePermissionRepository _repository;

    public GetRolePermissionByIdQueryHandler(IRolePermissionRepository repository)
    {
        _repository = repository;
    }

    public async Task<RolePermissionDto?> Handle(GetRolePermissionByIdQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetByIdAsync(request.RoleId, request.PermissionId);
    }
}