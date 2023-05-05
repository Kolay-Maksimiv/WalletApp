using Microsoft.EntityFrameworkCore;
using WalletApp.Data;

namespace WalletApp.API.Extensions;

public static class DbContextExtensions
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("AppConnection");

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(connectionString, b => b.MigrationsAssembly("WalletApp.Data")));

        return services;
    }
}
