using MediatR;
using visitorclean.Application.Feature.role.Interface;
using visitorclean.Application.Feature.role.Dto;
using System;

namespace visitorclean.Application.Feature.role.Queries.GetRoleByName;

public class GetByNameHandler 
    : IRequestHandler<GetByNameQuery, RoleDto?>
{
    private readonly IRoleRepository _roleRepository;

    public GetByNameHandler(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async Task<RoleDto?> Handle(GetByNameQuery request,CancellationToken cancellationToken)
    {
        var role = await _roleRepository.GetByNameAsync(request.Nom);

        if (role == null)
            return null;

        return new RoleDto
        {
            Nom = role.Nom
        };
    }
}