using Bogus;
using Cashto.Communication.Requests.Login;

namespace Cashto.TestsUtilities.Requests.Login;

public class LoginUserRequestJsonBuilder
{
    public static LoginUserRequestJson Builder()
    {
        return new Faker<LoginUserRequestJson>()
            .RuleFor(x => x.Email, f => f.Internet.Email())
            .RuleFor(x => x.Password, f => f.Internet.Password());
    }
}