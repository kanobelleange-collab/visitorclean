using MediatR;
using AutoMapper;
using visitorclean.Domain.Entities.user;
using visitorclean.Application.Feature.users.Dto;
using visitorclean.Application.Feature.users.Interface.IJwtTokenGenerator;
using visitorclean.Application.Feature.users.Interface;
using visitorclean.Application.Feature.users.Commands.RegistreUser;
namespace visitorclean.Application.Feature.users.Commands.RegistreUser.RegisterUserHandler;
public class RegisterUserHandler:IRequestHandler<RegisterUserCommand, AuthenticationResponse>
{
    private readonly IUserRepository _repository;
    private readonly IMapper _mapper;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    public RegisterUserHandler(IUserRepository repository, IMapper mapper, IJwtTokenGenerator jwtTokenGenerator){
        _repository=repository;
        _mapper=mapper;
        _jwtTokenGenerator= jwtTokenGenerator;

        }
        public async Task<AuthenticationResponse>Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<Users>(request);
         await _repository.CreateAsync(user);

        // 2. Génération du jeton via ton interface
        var userDto=_mapper.Map<UserDto>(user);
        var token =_jwtTokenGenerator.GenerateToken(user);
          
       

        return new AuthenticationResponse(userDto, token);
    }
}