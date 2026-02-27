using visitorclean.Domain.Entities.user;
using System;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using visitorclean.Application.Feature.users.Dto;
using visitorclean.Application.Feature.users.Commands.createuser;
using visitorclean.Application.Feature.Permission.Interface;
using visitorclean.Application.Feature.users.Interface;
using System.Security;
using visitorclean.Application.Service.Interface;
using visitorclean.Application.Common;


namespace visitorclean.Application.Feature.users.Commands.createuser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand , UserDto>
{
    private readonly IUserRepository _Repo;
    private readonly IMapper _mapper;
    private readonly IPermissionService _permissionService;

    public CreateUserCommandHandler(IUserRepository repo ,IMapper mapper,IPermissionService permissionService)
    {
        _Repo=repo;
        _mapper=mapper;
        _permissionService=permissionService;
    }
    public async Task<UserDto> Handle(CreateUserCommand request,CancelllationToken cancelllationToken);
    public async Task<UserDto> Handle(CreateUserCommand request ,CancellationToken cancellationToken)

    {
        var hasPermission = await _permissionService
            .HasPermission(request.UserId, AppPermission.CreateUser);

        if (!hasPermission)
            throw new UnauthorizedAccessException();
    

   
         // 1️⃣ Mapper DTO → Entity
        var user = _mapper.Map<Users>(request);

    // 2️⃣ Vérification importante
        if (user.RoleId == 0)
        throw new Exception("RoleId obligatoire");

    // 3️⃣ Sauvegarde en base
    

  
         var id = await _Repo.CreateAsync(user);
         user.Id = id;
        // 4️⃣ Mapper Entity → DTO
         return _mapper.Map<UserDto>(user);
       

    }
}