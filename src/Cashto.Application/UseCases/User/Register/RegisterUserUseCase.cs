using AutoMapper;
using Cashto.Communication.Requests.User;
using Cashto.Domain.Repositories;
using Cashto.Domain.Repositories.User;
using Cashto.Domain.Security.Cryptography;
using Cashto.Exception;
using Cashto.Exception.ExceptionBase;
using FluentValidation.Results;

namespace Cashto.Application.UseCases.User.Register;

public class RegisterUserUseCase(
    IUserReadOnlyRepository userReadOnlyRepository,
    IUserWriteOnlyRepository userWriteOnlyRepository,
    IMapper mapper,
    IPasswordEncripter passwordEncripter,
    IWorkUnity workUnity)
    : IRegisterUserUseCase
{
    public async Task Execute(RegisterUserRequestJson request)
    {
        await Validate(request);
        var user = mapper.Map<Domain.Entities.User>(request);
        user.Password = passwordEncripter.Encrypt(request.Password!);
        await userWriteOnlyRepository.AddAsync(user);
        await workUnity.Commit();
    }

    private async Task Validate(RegisterUserRequestJson request)
    {
        var result = new RegisterUserValidator().Validate(request);

        var emailExists = await userReadOnlyRepository.VerifyUserEmailExists(request.Email!);

        if (emailExists > 0)
        {
            result.Errors.Add(new ValidationFailure(string.Empty, ResourceErrorMessages.EMAIL_ALREADY_REGISTERED));
        }

        if (result.IsValid == false || result.Errors.Count > 0)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}