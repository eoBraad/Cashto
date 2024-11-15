using Cashto.Application.AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Cashto.Application;

public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddAutoMapper(services);
    }

    private static void AddAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(AutoMapping));
    }
}