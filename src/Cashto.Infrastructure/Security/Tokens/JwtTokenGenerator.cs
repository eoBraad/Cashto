using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Cashto.Domain.Entities;
using Cashto.Domain.Security.Tokens;
using Microsoft.IdentityModel.Tokens;

namespace Cashto.Infrastructure.Security.Tokens;

public class JwtTokenGenerator : IAccessTokenGenerator
{
    private readonly uint _tokenExpirationInMinutes;
    private readonly string _secretKey;

    public JwtTokenGenerator(uint tokenExpirationInMinutes, string secretKey)
    {
        _tokenExpirationInMinutes = tokenExpirationInMinutes;
        _secretKey = secretKey;
    }

    public string Generate(User user)
    {
        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name, user.Name!),
            new Claim(ClaimTypes.Sid, user.Id.ToString()),
        };

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(_tokenExpirationInMinutes),
            SigningCredentials = new SigningCredentials(SecurityKey(), SecurityAlgorithms.HmacSha256Signature)
        };

        var tokenHandler = new JwtSecurityTokenHandler();

        var securityToken = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(securityToken);
    }

    private SymmetricSecurityKey SecurityKey()
    {
        var key = Encoding.ASCII.GetBytes(_secretKey);

        return new SymmetricSecurityKey(key);
    }
}