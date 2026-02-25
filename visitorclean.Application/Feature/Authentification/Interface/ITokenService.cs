
using System;
using visitorclean.Domain.Entities;

namespace visitorclean.Application.Feature.Authentification.Interface;
public interface ITokenService
{
    string GenerateToken(Users user, List<string> permissions);
}