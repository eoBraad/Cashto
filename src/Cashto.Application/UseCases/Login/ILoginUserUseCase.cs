using Cashto.Communication.Requests.Login;
using Cashto.Communication.Responses.Login;

namespace Cashto.Application.UseCases.Login;

public interface ILoginUserUseCase
{
    public Task<LoginUserResponseJson> Execute(LoginUserRequestJson request);
}