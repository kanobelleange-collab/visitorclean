using visitorclean.Domain.Entities.user;
using visitorclean.Domain.Enum;
using visitorclean.Application.Feature.users.Dto;
namespace visitorclean.Application.Feature.users.Interface.IJwtTokenGenerator;
public interface IJwtTokenGenerator
{
string GenerateToken(Users user );
}
