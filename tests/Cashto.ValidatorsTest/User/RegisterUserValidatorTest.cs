using Cashto.Application.UseCases.User.Register;
using Cashto.Exception;
using Cashto.TestsUtilities.Requests.User;
using FluentAssertions;

namespace Cashto.ValidatorsTest.User;

public class RegisterUserValidatorTest
{
    [Fact]
    public void Success()
    {
        var validator = new RegisterUserValidator();
        var request = RegisterUserRequestJsonBuilder.Builder();

        var result = validator.Validate(request);

        result.IsValid.Should().BeTrue();
    }

    [Theory]
    [InlineData(null)]
    [InlineData(" ")]
    [InlineData("")]
    public void UserFirstNameCannotBeNullOrEmpty(string name)
    {
        var validator = new RegisterUserValidator();
        var request = RegisterUserRequestJsonBuilder.Builder();
        request.Name = name;

        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And
            .Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.NAME_EMPTY));
    }

    [Theory]
    [InlineData(null)]
    [InlineData(" ")]
    [InlineData("")]
    public void UserEmailCannotBeNullOrEmpty(string email)
    {
        var validator = new RegisterUserValidator();
        var request = RegisterUserRequestJsonBuilder.Builder();
        request.Email = email;

        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should()
            .Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.EMAIL_EMPTY));
    }

    [Fact]
    public void UserEmailCannotBeInvalid()
    {
        var validator = new RegisterUserValidator();
        var request = RegisterUserRequestJsonBuilder.Builder();
        request.Email = "invalid";

        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should()
            .Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.EMAIL_INVALID));
    }

    [Theory]
    [InlineData(null)]
    [InlineData(" ")]
    [InlineData("")]
    public void UserPasswordCannotBeNullOrEmpty(string password)
    {
        var validator = new RegisterUserValidator();
        var request = RegisterUserRequestJsonBuilder.Builder();
        request.Password = password;

        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should()
            .Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.PASSWORD_EMPTY));
    }

    [Fact]
    public void UserPasswordCannotBeInvalid()
    {
        var validator = new RegisterUserValidator();
        var request = RegisterUserRequestJsonBuilder.Builder();
        request.Password = "1234567";

        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should()
            .Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.INVALID_PASSWORD));
    }
}