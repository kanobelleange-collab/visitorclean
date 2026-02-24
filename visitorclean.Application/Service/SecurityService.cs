
using System.Security.Cryptography;
using System.Text;
using visitorclean.Application.Interface;


namespace visitorclean.Application.Service;

public class SecurityService : ISecurityService
{
    public byte[] HashPassword(string password)
    {
        using var sha256 = SHA256.Create();
        return sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
    }

    public bool VerifyPassword(string password, byte[] hash)
    {
        var computedHash = HashPassword(password);
        return computedHash.SequenceEqual(hash);
    }
}
