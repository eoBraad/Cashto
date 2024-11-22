using Cashto.Communication.Requests.User;
using Bogus;

namespace Cashto.TestsUtilities.Requests.User;

public class RegisterUserRequestJsonBuilder
{
    public static RegisterUserRequestJson Builder()
    {
        return new Faker<RegisterUserRequestJson>()
            .RuleFor(x => x.Email, f => f.Internet.Email())
            .RuleFor(x => x.Password, f => f.Internet.Password())
            .RuleFor(x => x.Name, f => f.Name.FirstName())
            .RuleFor(x => x.LastName, f => f.Name.LastName());
    }
}