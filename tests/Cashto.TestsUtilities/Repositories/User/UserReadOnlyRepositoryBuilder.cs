using Cashto.Domain.Repositories.User;
using Moq;

namespace Cashto.TestsUtilities.Repositories.User;

public class UserReadOnlyRepositoryBuilder
{
    private readonly Mock<IUserReadOnlyRepository> _mock;

    public UserReadOnlyRepositoryBuilder()
    {
        _mock = new Mock<IUserReadOnlyRepository>();
    }

    public void GetUserByEmailAsync(string email)
    {
        _mock.Setup(x => x.GetUserByEmailAsync(email)).ReturnsAsync(1);
    }

    public IUserReadOnlyRepository Build()
    {
        return _mock.Object;
    }
}