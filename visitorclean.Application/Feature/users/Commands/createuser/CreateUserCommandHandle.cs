using visitorclean.Domain.Entities;
using visitorclean.Application.Interface;
using System;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using visitorclean.Application.DTOs;
using visitorclean.Application.Feature.users.Commands.createuser;


namespace visitorclean.Application.Feature.users.Commands.createuser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand , UserDto>
{
    private readonly IVisitRepository _Repo;
    private readonly IMapper _mapper;

    public CreateUserCommandHandler(IVisitRepository repo ,IMapper mapper)
    {
        _Repo=repo;
        _mapper=mapper;
    }
    public async Task <UserDto>Handle(CreateUserCommand request ,CancellationToken cancellationToken)
    {
         // 1️⃣ Mapper DTO → Entity
        var user = _mapper.Map<Users>(request);

    // 2️⃣ Vérification importante
        if (user.RoleId == 0)
        throw new Exception("RoleId obligatoire");

    // 3️⃣ Sauvegarde en base
    

  
         var id = await _Repo.AddAsync(user);
         user.Id = id;
        // 4️⃣ Mapper Entity → DTO
         return _mapper.Map<userDto>(user);
       

    }
}