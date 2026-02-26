using FluentValidation;
using visitorclean.Application.Feature.users.Commands.createuser;
namespace visitor.Application.Feautures.Users.Commande.Command.CreateUserValidator;
public class CreateUserValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserValidator(){
RuleFor(u=> u.Username)
.NotEmpty().WithMessage(" Le nom est obligatoire")
.MaximumLength(20).WithMessage(" Le nom ne dois pas depasser 20 caractere");

RuleFor(u=> u.PasswordHash)
.NotNull().WithMessage(" Le mot de passe ne doit pas etre Null");

RuleFor(u=>u.Email)
.EmailAddress().WithMessage(" Votre Email doit Contenir un @");


RuleFor(u=> u.RoleId)
.NotNull()
.IsInEnum().WithMessage("Le Role choisir n'exite pas");

// RuleFor(u=> u.CreatedAt)
// .LessThanOrEqualTo(DateTime.Now).WithMessage(" La date ne doit pas etre futur");
    }
}