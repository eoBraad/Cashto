using AutoMapper;
using Cashto.Application.AutoMapper;

namespace Cashto.TestsUtilities.Mapper;

public class MapperBuilder
{
    public static IMapper Build()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new AutoMapping());
        });
        return config.CreateMapper();
    }
}