using Cashto.Application.UseCases.Account.Create;
using Cashto.Exception;
using Cashto.TestsUtilities.Requests.Account;
using FluentAssertions;

namespace Cashto.ValidatorsTest.Account;

public class CreateAccountValidatorTest
{
    [Fact]
    public void Validate_Valid_Create_Account_Request()
    {
        // Arrange
        var validator = new CreateAccountValidator();
        var createAccountRequest = CreateAccountRequestJsonBuilder.Build();

        // Act
        var result = validator.Validate(createAccountRequest);

        // Assert
        result.IsValid.Should().BeTrue();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void Name_Cannot_Be_Empty(string name)
    {
        var validator = new CreateAccountValidator();
        var createAccountRequest = CreateAccountRequestJsonBuilder.Build();
        createAccountRequest.Name = name;

        var result = validator.Validate(createAccountRequest);

        result.IsValid.Should().BeFalse();
        result.Errors.Should()
            .Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.ACCOUNT_NAME_EMPTY));
    }

    [Theory]
    [InlineData("a")]
    [InlineData("ab")]
    public void Name_Must_Be_At_Least_4_Characters(string name)
    {
        var validator = new CreateAccountValidator();
        var createAccountRequest = CreateAccountRequestJsonBuilder.Build();
        createAccountRequest.Name = name;

        var result = validator.Validate(createAccountRequest);

        result.IsValid.Should().BeFalse();
        result.Errors.Should()
            .Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.ACCOUNT_NAME_MINIMUM));
    }
}