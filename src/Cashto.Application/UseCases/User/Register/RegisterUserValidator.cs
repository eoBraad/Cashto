using Cashto.Communication.Requests.User;
using Cashto.Exception;
using FluentValidation;

namespace Cashto.Application.UseCases.User.Register;

public class RegisterUserValidator : AbstractValidator<RegisterUserRequestJson>
{
    public RegisterUserValidator()
    {
        RuleFor(x => x.Email).NotEmpty().WithMessage(ResourceErrorMessages.EMAIL_EMPTY);
        RuleFor(x => x.Password).NotEmpty().WithMessage(ResourceErrorMessages.PASSWORD_EMPTY);
        RuleFor(x => x.Email).EmailAddress().WithMessage(ResourceErrorMessages.EMAIL_INVALID);
        RuleFor(x => x.Password).MinimumLength(8).WithMessage(ResourceErrorMessages.INVALID_PASSWORD);
        RuleFor(x => x.Name).NotEmpty().WithMessage(ResourceErrorMessages.NAME_EMPTY);
        RuleFor(x => x.LastName).NotEmpty().WithMessage(ResourceErrorMessages.LAST_NAME_EMPTY);
    }
}