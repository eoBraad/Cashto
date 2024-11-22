using Cashto.Domain.Repositories;
using Moq;

namespace Cashto.TestsUtilities.Repositories;

public class WorkUnityBuilder
{
    public static IWorkUnity Build()
    {
        var mock = new Mock<IWorkUnity>();

        return mock.Object;
    }
}