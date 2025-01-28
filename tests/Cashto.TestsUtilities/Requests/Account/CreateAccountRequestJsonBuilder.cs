using Bogus;
using Cashto.Communication.Requests.Account;

namespace Cashto.TestsUtilities.Requests.Account;

public class CreateAccountRequestJsonBuilder
{
    public static CreateAccountRequestJson Build()
    {
        return new Faker<CreateAccountRequestJson>()
            .RuleFor(a => a.Balance, f => f.Random.Decimal())
            .RuleFor(a => a.Name, f => f.Company.CompanyName());
    }
}