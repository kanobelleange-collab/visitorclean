using MediatR;
using visitorclean.Domain.Entities.user;
namespace visitorclean.Application.Feature.users.Queries.LoginUser;
public record LoginUserQuery : IRequest<AuthenticationResponse>
{
    public string Email{get;set;}=string.Empty;
    public string Password{get;set;}=string.Empty;
}