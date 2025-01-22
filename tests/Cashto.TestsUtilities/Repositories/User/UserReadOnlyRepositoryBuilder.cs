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

    public void VerifyUserEmailExisits(string email)
    {
        _mock.Setup(x => x.VerifyUserEmailExists(email)).ReturnsAsync(1);
    }

    public void GetUserByEmail(string email)
    {
        _mock.Setup(x => x.GetUserByEmailAsync(email)).ReturnsAsync(new Domain.Entities.User()
        {
            Email = email,
            Password = "213esda"
        });
    }

    public IUserReadOnlyRepository Build()
    {
        return _mock.Object;
    }
}