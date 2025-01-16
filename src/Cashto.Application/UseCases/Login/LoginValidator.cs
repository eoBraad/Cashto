using Cashto.Communication.Requests.Login;
using Cashto.Exception;
using FluentValidation;

namespace Cashto.Application.UseCases.Login;

public class LoginValidator : AbstractValidator<LoginUserRequestJson>
{
    public LoginValidator()
    {
        RuleFor(x => x.Email).NotEmpty().WithMessage(ResourceErrorMessages.EMAIL_EMPTY);
        RuleFor(x => x.Password).NotEmpty().WithMessage(ResourceErrorMessages.PASSWORD_EMPTY);
    }
}