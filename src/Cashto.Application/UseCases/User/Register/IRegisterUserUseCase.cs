using Cashto.Communication.Requests.User;

namespace Cashto.Application.UseCases.User.Register;

public interface IRegisterUserUseCase
{
    public Task Execute(RegisterUserRequestJson request);
}