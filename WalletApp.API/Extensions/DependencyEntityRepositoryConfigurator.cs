using WalletApp.Core.MappingConfigurator;
using WalletApp.Data.GenericRepository;
using WalletApp.Data.IRepositories;
using WalletApp.Data.Repositories;
using WalletApp.Data.UnitOfWork;

namespace WalletApp.API.Extensions;
public static partial class DependencyEntityRepositoryConfigurator
{
    public static void AddEntityRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUsersRepository, UsersRepository>();
        services.AddScoped<ITransactionRepository, TransactionRepository>();
        services.AddScoped<IIconRepository, IconRepository>();
    }

    public static void AddGenericRepository(this IServiceCollection services)
    {
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
    }

    public static void AddUnitOfWork(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }

    public static void AddAutoMapperConfig(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MappingConfigurator));
    }
}
