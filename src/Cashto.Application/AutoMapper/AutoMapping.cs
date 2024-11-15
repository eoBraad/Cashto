using AutoMapper;
using Cashto.Communication.Requests.User;
using Cashto.Domain.Entities;

namespace Cashto.Application.AutoMapper;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        ResponseToEntityMapping();
    }

    private void ResponseToEntityMapping()
    {
        CreateMap<CreateUserRequestJson, User>()
            .ForMember(dest => dest.Password, conf => conf.Ignore());
    }
}