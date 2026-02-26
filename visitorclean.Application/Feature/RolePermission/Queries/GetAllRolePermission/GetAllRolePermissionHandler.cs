using MediatR;
using visitorclean.Application.Feature.RolePermission.Dtos;
using visitorclean.Application.Feature.RolePermission.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace visitorclean.Application.Feature.RolePermission.Queries.GetAllRolePermission
{
    public class GetAllRolePermissionHandler : IRequestHandler<GetAllRolePermissionQuery, List<RolePermissionDto>>
    {
        private readonly IRolePermissionRepository _repository;

        public GetAllRolePermissionHandler(IRolePermissionRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<RolePermissionDto>> Handle(GetAllRolePermissionQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}