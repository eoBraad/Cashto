using AutoMapper.Execution;
using Cashto.Application.UseCases.User.Register;
using Cashto.Exception;
using Cashto.Exception.ExceptionBase;
using Cashto.TestsUtilities.Mapper;
using Cashto.TestsUtilities.Repositories;
using Cashto.TestsUtilities.Repositories.User;
using Cashto.TestsUtilities.Requests.User;
using Cashto.TestsUtilities.Security.Cryptography;
using FluentAssertions;

namespace Cashto.UseCaseTests.User;

public class RegisterUserUseCaseTest
{
    [Fact]
    public async void Success()
    {
        var useCase = CreateUseCase();
        var request = RegisterUserRequestJsonBuilder.Builder();

        var act = async () => await useCase.Execute(request);

        await act.Should().NotThrowAsync();
    }

    [Fact]
    public async void UserAlreadyExists()
    {
        var request = RegisterUserRequestJsonBuilder.Builder();
        var useCase = CreateUseCase(request.Email);

        var act = async () => await useCase.Execute(request);

        var result = await act.Should().ThrowAsync<ErrorOnValidationException>();

        result.Where(ex => ex.GetErrors().Count == 1 && ex.GetErrors().Contains(ResourceErrorMessages.EMAIL_ALREADY_REGISTERED));
    }

    private static RegisterUserUseCase CreateUseCase(string? email = null)
    {
        var workUnity = WorkUnityBuilder.Build();
        var mapper = MapperBuilder.Build();
        var userWriteOnlyRepository = UserWriteOnlyRepositoryBuilder.Build();
        var userReadOnlyRepository = new UserReadOnlyRepositoryBuilder();
        var passowrdEncrypter = new PasswordEncrypterBuilder().Build();

        if (string.IsNullOrWhiteSpace(email) == false)
        {
            userReadOnlyRepository.GetUserByEmailAsync(email);
        }

        return new RegisterUserUseCase(userReadOnlyRepository.Build(), userWriteOnlyRepository, mapper, passowrdEncrypter, workUnity);
    }
}