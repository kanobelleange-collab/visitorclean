using MediatR;
using AutoMapper;
using visitorclean.Application.Feature.users.Interface.IJwtTokenGenerator;
using visitorclean.Application.Feature.users.Dto;
using visitorclean.Domain.Entities.user;
using visitorclean.Application.Feature.users.Interface;
using visitorclean.Application.Feature.users.Queries.LoginUser;
namespace visitorclean.Application.Feature.users.Queries.LoginUser.LoginUserHandler; 
public class LoginUserHandler:IRequestHandler<LoginUserQuery, AuthenticationResponse>
{
    private readonly IUserRepository _repository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IMapper _mapper;
    public LoginUserHandler(IUserRepository repository, IMapper mapper, IJwtTokenGenerator jwtTokenGenerator)
    {
        _repository=repository;
        _mapper=mapper;
        _jwtTokenGenerator=jwtTokenGenerator;
    }
    public async Task<AuthenticationResponse>Handle(LoginUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetByEmailAsync(request.Email);

    if (user == null)
        throw new Exception("Utilisateur introuvable");

    // 2️⃣ Mapper Entity → DTO
    var userDto = _mapper.Map<UserDto>(user);

    // 3️⃣ Générer token avec Entity
    var token = _jwtTokenGenerator.GenerateToken(user);

    // 4️⃣ Retour
    return new AuthenticationResponse(userDto, token);
}
    }
