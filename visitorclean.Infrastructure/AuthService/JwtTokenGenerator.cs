using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using visitorclean.Application.Features.Users.Interfaces.IJwtTokenGenerator;
using visitorclean.Application.Feature.users.Interface;
using visitorclean.Application.Feature.users.Dto;
using visitorclean.Domain.Enum;
namespace visitorclean.Infrastructure.AuthService.JwtTokenGenerator;
public class JwtTokenGenerator : IJwtTokenGenerator
{
public string GenerateToken( UserDto user)

{
// 1. On prépare les informations à mettre dans le badge
var claims = new List<Claim>
{
            new Claim(JwtRegisteredClaimNames.FamilyName, user.Username),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(ClaimTypes.Role, user.RoleNom),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
};
     var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes("MA_CLE_SUPER_SECRETE_DE_32_CHARS!!"));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: "Visitor",
            audience: "Clean",
            claims: claims,
            expires: DateTime.Now.AddHours(2),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
}
}