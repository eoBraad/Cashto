using Cashto.Communication.Requests.Login;
using Cashto.Communication.Responses.Login;
using Cashto.Domain.Repositories.User;
using Cashto.Domain.Security.Cryptography;
using Cashto.Domain.Security.Tokens;
using Cashto.Exception;
using Cashto.Exception.ExceptionBase;

namespace Cashto.Application.UseCases.Login;

public class LoginUserUseCase : ILoginUserUseCase
{
    private readonly IUserReadOnlyRepository _userReadOnlyRepository;
    private readonly IPasswordEncripter _passwordEncripter;
    private readonly IAccessTokenGenerator _accessTokenGenerator;

    public LoginUserUseCase(IUserReadOnlyRepository userReadOnlyRepository, IPasswordEncripter passwordEncripter, IAccessTokenGenerator accessTokenGenerator)
    {
        _userReadOnlyRepository = userReadOnlyRepository;
        _passwordEncripter = passwordEncripter;
        _accessTokenGenerator = accessTokenGenerator;
    }

    public async Task<LoginUserResponseJson> Execute(LoginUserRequestJson request)
    {

        Validate(request);

        var user = await _userReadOnlyRepository.GetUserByEmailAsync(request.Email!);

        if (user == null)
        {
            throw new ErrorOnLoginException("User Email or Password incorrect");
        }

        var passwordCorrect = _passwordEncripter.Verify(request.Password, user.Password!);

        if (user == null || passwordCorrect == false)
        {
            throw new ErrorOnValidationException([ResourceErrorMessages.USER_OR_PASSWORD_INCORRECT]);
        }

        return new LoginUserResponseJson
        {
            AccessToken = _accessTokenGenerator.Generate(user),
            Name = user.Name
        };
    }

    private void Validate(LoginUserRequestJson request)
    {
        var validator = new LoginValidator();
        var result = validator.Validate(request);
        if (result.IsValid == false || result.Errors.Count > 0)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();
            throw new ErrorOnValidationException(errorMessages);
        }
    }
}