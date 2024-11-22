using Cashto.Domain.Repositories.User;
using Moq;

namespace Cashto.TestsUtilities.Repositories.User;

public class UserWriteOnlyRepositoryBuilder
{
    public static IUserWriteOnlyRepository Build()
    {
        var mock = new Mock<IUserWriteOnlyRepository>();
        return mock.Object;
    }
}