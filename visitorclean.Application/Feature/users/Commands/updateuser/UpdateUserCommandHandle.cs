using MediatR;
using visitorclean.Application.Interface;
using System.Threading.Tasks;
using visitorclean.Domain.Entities;
using System.Net;
using visitorclean.Application.Feature.user.Commands.updateuser;
using visitorclean.Application.DTOs;
using AutoMapper;

namespace visitorclean.Application.Feature.user.Commands.updateuser;
public class UpdateUserCommandHandler:IRequestHandler<UpdateUserCommand, UserDto>
{
    private readonly IVisitorRepository _repo;
    private readonly IMapper _mapper;

    public UpdateUserCommandHandler(IVisitorRepository repo,IMapper mapper)
    {
        _repo=repo;
        _mapper=mapper;
    }
  public async Task<UserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user= await _repo.GetByIdAsync(request.Id);

        if (user is null)
        throw new Exception($"Visitor avec l'id {request.Id} introuvable");

       
        

        // Mettre à jour le visiteur
        user.Update(request.Nom, request.Email, request.Password);

        await _repo.Update(user);
        var userDto=_mapper.Map<UserDto>(user);
        

        return userDto;
    }

    
}
