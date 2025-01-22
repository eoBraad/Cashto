using Cashto.Communication.Requests.Account;
using Cashto.Exception;
using FluentValidation;

namespace Cashto.Application.UseCases.Account.Create;

public class CreateAccountValidator : AbstractValidator<CreateAccountRequestJson>
{
    public CreateAccountValidator()
    {
        RuleFor(a => a.Balance).NotNull().WithMessage(ResourceErrorMessages.ACCOUNT_BALANCE_EMPTY);
        RuleFor(a => a.Name).NotEmpty().WithMessage(ResourceErrorMessages.ACCOUNT_NAME_EMPTY);
        RuleFor(a => a.Name).MinimumLength(3).WithMessage(ResourceErrorMessages.ACCOUNT_NAME_MINIMUM);
    }
}