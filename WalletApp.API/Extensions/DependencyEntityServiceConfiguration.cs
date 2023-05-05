using WalletApp.Service;

namespace WalletApp.API.Extensions;
public static partial class DependencyСonfigurator
{
    public static void AddEntityServices(this IServiceCollection services)
    {
        services.AddScoped<ITransactionService, TransactionService>();
        services.AddScoped<IUserService, UserService>();
    }
}

