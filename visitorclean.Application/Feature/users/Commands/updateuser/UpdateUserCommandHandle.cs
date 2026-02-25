using MediatR;
using visitorclean.Application.Feature.users.Interface;
using System.Threading.Tasks;
using visitorclean.Domain.Entities;
using System.Net;
using visitorclean.Application.Feature.users.Commands.updateuser;
using visitorclean.Application.Feature.users.Dto;
using AutoMapper;

namespace visitorclean.Application.Feature.users.Commands.updateuser;
public class UpdateUserCommandHandler:IRequestHandler<UpdateUserCommand, UserDto>
{
    private readonly IVisitorRepository _repo;
    private readonly IMapper _mapper;
    private readonly IPermissionService _permissionService;

    public UpdateUserCommandHandler(IVisitorRepository repo,IMapper mapper,IPermissionService permissionService)
    {
        _repo=repo;
        _mapper=mapper;
        _permissionService=permissionService;
    }

    public async Task<UserDto> Handle(UpdateUserCommand request ,CancellationToken cancellationToken)
    {
        var hasPermission = await _permissionService
            .HasPermission(request.UserId, Permissions.UpdateUser);

        if (!hasPermission)
            throw new UnauthorizedAccessException();
    

 
        var user= await _repo.GetByIdAsync(request.Id);

        if (user is null)
        throw new Exception($"user  introuvable");

       
        

        // Mettre à jour le visiteur
        user.Update(request.Username, request.Email, request.PasswordHash);

        await _repo.Update(user);
        var userDto=_mapper.Map<UserDto>(user);
        

        return userDto;
    }

    
}
