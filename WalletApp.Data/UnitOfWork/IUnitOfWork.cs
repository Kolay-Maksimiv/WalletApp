using WalletApp.Data.IRepositories;

namespace WalletApp.Data.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    IUsersRepository User { get; }

    ITransactionRepository Transaction { get; }

    Task<int> SaveAsync();
}