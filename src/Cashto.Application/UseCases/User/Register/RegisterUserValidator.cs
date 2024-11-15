using Cashto.Communication.Requests.User;
using Cashto.Exception;
using FluentValidation;

namespace Cashto.Application.UseCases.User.Register;

public class RegisterUserValidator : AbstractValidator<RegisterUserRequestJson>
{
    public RegisterUserValidator()
    {
        RuleFor(x => x.Email).NotEmpty().WithMessage(ResourceErrorMessage.EMAIL_EMPTY);
        RuleFor(x => x.Password).NotEmpty().WithMessage(ResourceErrorMessage.PASSWORD_EMPTY);
        RuleFor(x => x.Email).EmailAddress().WithMessage(ResourceErrorMessage.EMAIL_INVALID);
        RuleFor(x => x.Password).MinimumLength(8).WithMessage(ResourceErrorMessage.INVALID_PASSWORD);
        RuleFor(x => x.Name).NotEmpty().WithMessage(ResourceErrorMessage.NAME_EMPTY);
        RuleFor(x => x.LastName).NotEmpty().WithMessage(ResourceErrorMessage.LAST_NAME_EMPTY);
    }
}