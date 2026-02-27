using visitorclean.Domain.Entities.user;
using visitorclean.Application.Feature.users.Dto;
namespace visitorclean.Application.Features.Users.Interfaces.IJwtTokenGenerator;
public interface IJwtTokenGenerator
{
string GenerateToken(UserDto user );
}
