using Cashto.Domain.Repositories;
using Cashto.Domain.Repositories.Transaction;
using Cashto.Domain.Repositories.User;
using Cashto.Domain.Security.Cryptography;
using Cashto.Domain.Security.Tokens;
using Cashto.Infrastructure.Database;
using Cashto.Infrastructure.Repositories;
using Cashto.Infrastructure.Repositories.Transaction;
using Cashto.Infrastructure.Repositories.User;
using Cashto.Infrastructure.Security.Tokens;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cashto.Infrastructure;

public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Cashtodb");
        var signKey = configuration.GetSection("Jwt:SigningKey").Value;
        var expirationInMinutes = uint.Parse(configuration.GetSection("Jwt:ExpirationInMinutes").Value!);

        services.AddDbContext<CashtoDbContext>(opt =>
        {
            opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), x => x.MigrationsAssembly("Cashto.Infrastructure"));
        });

        services.AddScoped<IAccessTokenGenerator>(config => new JwtTokenGenerator(expirationInMinutes, signKey!));

        AddRepositories(services);
        AddServices(services);
    }

    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserReadOnlyRepository, UserReadOnlyRepository>()
            .AddScoped<IUserWriteOnlyRepository, UserWriteOnlyRepository>()
            .AddScoped<IWorkUnity, WorkUnity>()
            .AddScoped<ITransactionReadOnlyRepository, TransactionRepository>()
            .AddScoped<ITransactionWriteOnlyRepository, TransactionRepository>();
    }

    private static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IPasswordEncripter, Security.Cryptography.BCrypt>();
    }
}