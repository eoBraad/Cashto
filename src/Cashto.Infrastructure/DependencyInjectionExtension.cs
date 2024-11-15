using Cashto.Domain.Repositories;
using Cashto.Domain.Repositories.User;
using Cashto.Infrastructure.Database;
using Cashto.Infrastructure.Repositories;
using Cashto.Infrastructure.Repositories.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cashto.Infrastructure;

public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Cashtodb");

        services.AddDbContext<CashtoDbContext>(opt =>
        {
            opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), x => x.MigrationsAssembly("Cashto.Infrastructure"));
        });

        AddRepositories(services);
    }

    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserReadOnlyRepository, UserReadOnlyRepository>()
            .AddScoped<IUserWriteOnlyRepository, UserWriteOnlyRepository>()
            .AddScoped<IWorkUnity, WorkUnity>();
    }
}