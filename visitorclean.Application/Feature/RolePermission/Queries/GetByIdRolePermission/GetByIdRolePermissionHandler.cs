using MediatR;
using visitorclean.Application.Feature.RolePermission.Dtos;
using visitorclean.Application.Feature.RolePermission.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace visitorclean.Application.Feature.RolePermission.Queries.GetByIdRolePermission
{
    public class GetByIdRolePermissionHandler : IRequestHandler<GetByIdRolePermissionQuery, RolePermissionDto?>
    {
        private readonly IRolePermissionRepository _repository;

        public GetByIdRolePermissionHandler(IRolePermissionRepository repository)
        {
            _repository = repository;
        }

        public async Task<RolePermissionDto?> Handle(GetByIdRolePermissionQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(request.RoleId);
        }
    }
}