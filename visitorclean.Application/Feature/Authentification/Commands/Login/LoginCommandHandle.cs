using MediatR;
using visitorclean.Application.Feature.Authentification.DTOs;
using visitorclean.Application.Feature.Authentification.Interface;
using visitorclean.Application.Feature.Permission.Interface;
using visitorclean.Application.Feature.users.Interface;
using System.Security.Cryptography;
using System.Text;


namespace visitorclean.Application.Feature.Authentification.Commands.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, AuthResponseDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IPermissionRepository _permissionRepository;
    private readonly ITokenService _tokenService;

    public LoginCommandHandler(
        IUserRepository userRepository,
        IPermissionRepository permissionRepository,
        ITokenService tokenService)
    {
        _userRepository = userRepository;
        _permissionRepository = permissionRepository;
        _tokenService = tokenService;
    }

    public async Task<AuthResponseDto> Handle(
        LoginCommand request,
        CancellationToken cancellationToken)
    {
        // 🔎 1. Vérifier si l'utilisateur existe
        var user = await _userRepository.GetByEmailAsync(request.Email);

        if (user == null)
            throw new UnauthorizedAccessException("Email incorrect");

        // 🔐 2. Vérifier mot de passe
        var hashedPassword = HashPassword(request.Password);

        if (user.Password != hashedPassword)
            throw new UnauthorizedAccessException("Mot de passe incorrect");

        // 🔑 3. Récupérer permissions
        var permissions = await _permissionRepository
            .GetPermissionsByUserId(user.Id);

        // 🎟 4. Générer token
        var token = _tokenService.GenerateToken(user, permissions);

        // 📦 5. Retourner réponse
        return new AuthResponseDto
        {
            Token = token,
            Username = user.Username,
            Role = user.RoleName,
            Permissions = permissions
        };
    }

    // 🔒 Méthode simple de hash (à remplacer plus tard par BCrypt recommandé)
    private string HashPassword(string password)
    {
        using var sha256 = SHA256.Create();
        var bytes = Encoding.UTF8.GetBytes(password);
        var hash = sha256.ComputeHash(bytes);
        return Convert.ToBase64String(hash);
    }
}