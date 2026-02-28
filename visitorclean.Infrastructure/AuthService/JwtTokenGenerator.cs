using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using visitorclean.Application.Feature.users.Interface.IJwtTokenGenerator;
using visitorclean.Domain.Entities.user;

namespace visitorclean.Infrastructure.AuthService;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly IConfiguration _configuration;

    public JwtTokenGenerator(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateToken(Users user)
    {
        // 1. Préparation des Claims (les infos dans le token)
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Username),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim("id", user.Id.ToString()),
            new Claim(ClaimTypes.Role, user.RoleNom ?? "User"), 
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        // 2. Récupération de la clé "MaCleSuperSecreteTresLongue123456789" depuis ton JSON
        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        // 3. SYNCHRONISATION : On pioche directement dans le JSON pour éviter les fautes de frappe
        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],   // Sera "visitorclean"
            audience: _configuration["Jwt:Audience"], // Sera "visitorcleanUsers"
            claims: claims,
            expires: DateTime.Now.AddHours(2),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}