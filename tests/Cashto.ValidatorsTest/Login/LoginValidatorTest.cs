using Cashto.Application.UseCases.Login;
using Cashto.Communication.Requests.Login;
using Cashto.Exception;
using FluentAssertions;

namespace Cashto.ValidatorsTest.Login;

public class LoginValidatorTest
{
    [Fact]
    public void Validate_Valid_Email_And_Password()
    {
        // Arrange
        var validator = new LoginValidator();
        var loginRequest = new LoginUserRequestJson()
        {
            Email = "valid_email@example.com",
            Password = "valid_password"
        };

        // Act
        var result = validator.Validate(loginRequest);

        // Assert
        result.IsValid.Should().BeTrue();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void Email_Cannot_Be_Empty(string email)
    {
        // Arrange
        var validator = new LoginValidator();
        var loginRequest = new LoginUserRequestJson()
        {
            Email = email,
            Password = "valid_password"
        };

        // Act
        var result = validator.Validate(loginRequest);

        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And
            .Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.EMAIL_EMPTY));
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void Password_Cannot_Be_Empty(string password)
    {
        // Arrange
        var validator = new LoginValidator();
        var loginRequest = new LoginUserRequestJson()
        {
            Email = "valid_email@example.com",
            Password = password
        };

        // Act
        var result = validator.Validate(loginRequest);

        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And
            .Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.PASSWORD_EMPTY));
    }
}