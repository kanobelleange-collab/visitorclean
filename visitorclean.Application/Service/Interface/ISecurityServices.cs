using System;
namespace visitorclean.Application.Service.Interface;

public interface ISecurityService
{
    byte[] HashPassword(string password);
    bool VerifyPassword(string password, byte[] hash);
}
