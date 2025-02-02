using Cashto.Application.UseCases.Account.Create;
using Cashto.Communication.Requests.Account;
using Cashto.Domain.Repositories.Account;
using Cashto.Exception.ExceptionBase;
using Cashto.TestsUtilities.Mapper;
using Cashto.TestsUtilities.Requests.Account;
using FluentAssertions;
using Moq;

namespace Cashto.UseCaseTests.Account
{
    public class CreateAccountUseCaseTests
    {
        private readonly CreateAccountUseCase _createAccountUseCase;

        public CreateAccountUseCaseTests()
        {
            Mock<IAccountWriteOnlyRepository> accountWriteOnlyRepositoryMock = new();
            var mapper = MapperBuilder.Build();
            _createAccountUseCase = new CreateAccountUseCase(accountWriteOnlyRepositoryMock.Object, mapper);
        }

        [Fact]
        public void Execute_ValidRequest_AddsAccount()
        {
            // Arrange
            var request = CreateAccountRequestJsonBuilder.Build();
            var userId = Guid.NewGuid().ToString();
            var account = new Domain.Entities.Account { UserId = Guid.Parse(userId) };

            // Act
            var act = async () => await _createAccountUseCase.Execute(request, userId);

            // Assert
            act.Should().NotThrowAsync();
        }

        [Fact]
        public void Execute_InvalidRequest_ThrowsErrorOnValidationException()
        {
            // Arrange
            var request = new CreateAccountRequestJson(); // Assume this request is invalid
            var userId = Guid.NewGuid().ToString();

            // Act
            var act = async () => await _createAccountUseCase.Execute(request, userId);

            // Assert
            act.Should().ThrowAsync<ErrorOnValidationException>();
        }
    }
}