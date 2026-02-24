using System;
namespace visitorclean.Application.Interface;

public interface ISecurityService
{
    byte[] HashPassword(string password);
    bool VerifyPassword(string password, byte[] hash);
}
