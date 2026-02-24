using System;
using visitorclean.Application.Feature.role.Commands.createRole;
using MediatR;
using visitorclean.Domain.Entities;
using System.Runtime.InteropServices;
using AutoMapper;

namespace visitorclean.Application.Feature.role.Commands.createRole;

public class CreateRoleCommandHandler: IRequesthandler<CreateRoleCommand, RoleDto>
{
    private readonly IRoleRepository _repo;
    private readonly IMapper mapper;

    public CreateRoleCommandHandler(IRoleRepository repo, IMapper mapper)
    {
        _repo=repo;
        _mapper=mapper;
    }
    public async Task<RoleDto>Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        
         // 1️⃣ Mapper DTO → Entity
        var role = _mapper.Map<Roles>(request);

    

        // 3️⃣ Sauvegarde en base
    

  
         var id = await _Repo.CreateAsync(role);
         role.Id = id;
        // 4️⃣ Mapper Entity → DTO
         return _mapper.Map<RoleDto>(role);
       
    }
}

