using Cashto.Domain.Entities;
using Moq;
using Cashto.Domain.Security.Tokens;

namespace Cashto.TestsUtilities.Security.Tokens;

public class JwtTokenGeneratorBuilder
{
    private readonly Mock<IAccessTokenGenerator> _mock;

    public JwtTokenGeneratorBuilder()
    {
        _mock = new Mock<IAccessTokenGenerator>();

        _mock.Setup(jwtGenerator => jwtGenerator.Generate(It.IsAny<User>())).Returns("dlaksmlaisjdal");
    }

    public IAccessTokenGenerator Build() => _mock.Object;
}