using Cashto.Domain.Security.Cryptography;
using BC = BCrypt.Net.BCrypt;

namespace Cashto.Infrastructure.Security.Cryptography;

public class BCrypt : IPasswordEncripter
{
    public string Encrypt(string password)
    {
        return BC.HashPassword(password);
    }

    public bool Verify(string password, string encryptedPassword)
    {
        return BC.Verify(password, encryptedPassword);
    }
}