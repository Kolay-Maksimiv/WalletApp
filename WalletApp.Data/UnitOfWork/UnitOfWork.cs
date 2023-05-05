using WalletApp.Data.IRepositories;
using WalletApp.Data.Repositories;

namespace WalletApp.Data.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    private IUsersRepository _users;

    private ITransactionRepository _transaction;


    public IUsersRepository User
    {
        get
        {
            _users ??= new UsersRepository(_context);

            return _users;
        }
    }

    public ITransactionRepository Transaction
    {
        get
        {
            _transaction ??= new TransactionRepository(_context);

            return _transaction;
        }
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            _context.Dispose();
        }
    }
}
