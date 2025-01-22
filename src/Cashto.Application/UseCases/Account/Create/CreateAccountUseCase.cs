using AutoMapper;
using Cashto.Communication.Requests.Account;
using Cashto.Domain.Repositories.Account;
using Cashto.Exception.ExceptionBase;

namespace Cashto.Application.UseCases.Account.Create;

public class CreateAccountUseCase(IAccountWriteOnlyRepository accountWriteOnlyRepository, IMapper mapper) : ICreateAccountUseCase
{

    public async Task Execute(CreateAccountRequestJson request, string userId)
    {
        Validate(request);

        var account = mapper.Map<Domain.Entities.Account>(request);
        account.UserId = Guid.Parse(userId);
        await accountWriteOnlyRepository.AddAsync(account);
    }

    private void Validate(CreateAccountRequestJson request)
    {
        var validator = new CreateAccountValidator();
        var result = validator.Validate(request);
        if (result.IsValid == false || result.Errors.Count > 0)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();
            throw new ErrorOnValidationException(errorMessages);
        }
    }
}