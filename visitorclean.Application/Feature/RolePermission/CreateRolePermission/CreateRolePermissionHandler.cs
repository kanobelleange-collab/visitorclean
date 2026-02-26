using MediatR;
using AutoMapper;
using visitorclean.Domain.Entities;
using visitorclean.Application.Feature.RolePermission.Dtos;
using visitorclean.Application.Feature.RolePermission.Interfaces;
using visitorclean.Application.Feature.RolePermission.Command.CreateRolePermission;
using System.Threading;
using System.Threading.Tasks;

namespace visitorclean.Application.Feature.RolePermission.Command.CreateRolePermissionHandler
{
    public class CreateRolePermissionHandler : IRequestHandler<CreateRolePermissionCommand, RolePermissionDto>
    {
        private readonly IRolePermissionRepository _repository;
        private readonly IMapper _mapper;

        public CreateRolePermissionHandler(IRolePermissionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<RolePermissionDto> Handle(CreateRolePermissionCommand request, CancellationToken cancellationToken)
        {
            // Mapper la commande en entity
            var rolePermission = _mapper.Map<RolesPermissions>(request);

            // Ajouter via repository
            await _repository.AddAsync(rolePermission);

            // Mapper l'entity en DTO pour retourner
            return _mapper.Map<RolePermissionDto>(rolePermission);
        }
    }
}