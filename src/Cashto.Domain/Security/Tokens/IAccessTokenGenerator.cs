using Cashto.Domain.Entities;

namespace Cashto.Domain.Security.Tokens;

public interface  IAccessTokenGenerator
{
    public string Generate(User user);
}