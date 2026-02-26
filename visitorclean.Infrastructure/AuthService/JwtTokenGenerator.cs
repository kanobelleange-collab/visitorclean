using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using CleanVisitor.Application.Features.Users.Interfaces.IJwtTokenGenerator;
using CleanVisitor.Application.Features.Users.Interfaces;
using CleanVisitor.Application.Features.Users.Dtos;
using CleanVisitor.Core.Enum.UserRole;
namespace CleanVisitor.Infrastructure.AuthService.JwtTokenGenerator;
public class JwtTokenGenerator : IJwtTokenGenerator
{
public string GenerateToken( UserDto user)

{
// 1. On prépare les informations à mettre dans le badge
var claims = new List<Claim>
{
            new Claim(JwtRegisteredClaimNames.FamilyName, user.Nom),
            new Claim(JwtRegisteredClaimNames.GivenName, user.Prenom),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(ClaimTypes.Role, user.RoleNom),
            new Claim("IsActive", user.IsActive.ToString().ToLower()),
            new Claim("CreatedAt", user.CreatedAt.ToString("O")),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
};
foreach (var permission in user.Permissions) 
{ 
    claims.Add(new Claim("Permission", permission.Nom));
}

     var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes("MA_CLE_SUPER_SECRETE_DE_32_CHARS!!"));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: "CleanVisitor",
            audience: "CleanVisitor",
            claims: claims,
            expires: DateTime.Now.AddHours(2),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
}
}