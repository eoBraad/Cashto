using Cashto.Communication.Requests.Account;

namespace Cashto.Application.UseCases.Account.Create;

public interface ICreateAccountUseCase
{
    Task Execute(CreateAccountRequestJson request, string userId);
}