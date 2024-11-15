using AutoMapper;
using Cashto.Communication.Requests.User;
using Cashto.Domain.Repositories.User;
using Cashto.Exception.ExceptionBase;
using FluentValidation.Results;

namespace Cashto.Application.UseCases.User.Register;

public class RegisterUserUseCase : IRegisterUserUseCase
{
    
    private readonly IUserReadOnlyRepository _userReadOnlyRepository;
    private readonly IUserWriteOnlyRepository _userWriteOnlyRepository;
    private readonly IMapper _mapper;

    public RegisterUserUseCase(
        IUserReadOnlyRepository userReadOnlyRepository,
        IUserWriteOnlyRepository userWriteOnlyRepository,
        IMapper mapper)
    {
        _userReadOnlyRepository = userReadOnlyRepository;
        _userWriteOnlyRepository = userWriteOnlyRepository;
        _mapper = mapper;
    }
    public async Task Execute(RegisterUserRequestJson request)
    {
        await Validate(request);
        var user = _mapper.Map<Domain.Entities.User>(request);
        await _userWriteOnlyRepository.AddAsync(user);
        
    }

    private async Task Validate(RegisterUserRequestJson request)
    {
        var result = new RegisterUserValidator().Validate(request);

        var emailExists = await _userReadOnlyRepository.GetUserByEmailAsync(request.Email);

        if (emailExists != null)
        {
            result.Errors.Add(new ValidationFailure(string.Empty, "Email already exists"));
        }

        if (!result.IsValid == false || result.Errors.Count > 0)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}