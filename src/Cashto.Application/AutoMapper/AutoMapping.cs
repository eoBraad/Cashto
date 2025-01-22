using AutoMapper;
using Cashto.Communication.Requests.Account;
using Cashto.Communication.Requests.User;
using Cashto.Domain.Entities;

namespace Cashto.Application.AutoMapper;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        RequestToEntityMapping();
    }

    private void RequestToEntityMapping()
    {
        CreateMap<RegisterUserRequestJson, User>()
            .ForMember(dest => dest.Password, conf => conf.Ignore());

        CreateMap<CreateAccountRequestJson, Account>();
    }
}