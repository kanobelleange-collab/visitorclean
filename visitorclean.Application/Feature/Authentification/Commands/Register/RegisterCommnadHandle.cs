using MediatR;
using visitorclean.Application.Feature.Authentification.Interface;
using visitorclean.Domain.Entities.user;
using System.Security.Cryptography;
using System.Text;
using visitorclean.Application.Feature.users.Interface;

namespace visitorclean.Application.Feature.Authentification.Commands.Register;

public class RegisterCommandHandler 
    : IRequestHandler<RegisterCommand, int>
{
    private readonly IUserRepository _userRepository;

    public RegisterCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<int> Handle(
        RegisterCommand request,
        CancellationToken cancellationToken)
    {
        // 1️⃣ Vérifier si email existe déjà
        var existingUser = await _userRepository.GetByEmailAsync(request.Email);

        if (existingUser != null)
            throw new Exception("Cet email est déjà utilisé");

        // 2️⃣ Hasher mot de passe
        var hashedPassword = HashPassword(request.Password);

        // 3️⃣ Créer l'entité User
        var user = new Users(
            request.Username,
            request.Email,
            hashedPassword,
            request.RoleId
        );

        // 4️⃣ Sauvegarder en base
        await _userRepository.CreateAsync(user);

        // 5️⃣ Retourner Id du nouvel utilisateur
        return user.Id;
    }

    private string HashPassword(string password)
    {
        using var sha256 = SHA256.Create();
        var bytes = Encoding.UTF8.GetBytes(password);
        var hash = sha256.ComputeHash(bytes);
        return Convert.ToBase64String(hash);
    }
}