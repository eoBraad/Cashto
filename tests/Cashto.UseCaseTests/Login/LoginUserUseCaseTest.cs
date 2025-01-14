using Cashto.Application.UseCases.Login;
using Cashto.TestsUtilities.Repositories.User;
using Cashto.TestsUtilities.Requests.Login;
using Cashto.TestsUtilities.Security.Cryptography;
using Cashto.TestsUtilities.Security.Tokens;
using FluentAssertions;

namespace Cashto.UseCaseTests.Login;

public class LoginUserUseCaseTest
{
    [Fact]
    public async void Success()
    {
        var request = LoginUserRequestJsonBuilder.Builder();
        var useCase = CreateUseCase(request.Password, request.Email);

        var act = async () => await useCase.Execute(request);

        await act.Should().NotThrowAsync();
    }

    private static LoginUserUseCase CreateUseCase(string? password, string? email)
    {
        var userReadOnlyRepository = new UserReadOnlyRepositoryBuilder();
        var passowrdEncrypter = new PasswordEncrypterBuilder();
        var jwtTokenGenerator = new JwtTokenGeneratorBuilder().Build();


        if (string.IsNullOrWhiteSpace(password) == false)
        {
            passowrdEncrypter.Verify(password);
        }

        if (string.IsNullOrWhiteSpace(email) == false)
        {
            userReadOnlyRepository.GetUserByEmail(email);
        }

        return new LoginUserUseCase(userReadOnlyRepository.Build(), passowrdEncrypter.Build(), jwtTokenGenerator);
    }
}