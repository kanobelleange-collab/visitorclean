using MediatR;
using visitorclean.Domain.Enum;
namespace visitorclean.Application.Feature.users.Commands.RegistreUser;
public record RegisterUserCommand:IRequest<AuthenticationResponse>{
    public string Nom { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty; 
    public int RoleId { get; set; } 
    public string ?NomRole{get;set;}
}