using WalletApp.Core.Entities;
using WalletApp.Data.GenericRepository;
using WalletApp.Data.IRepositories;

namespace WalletApp.Data.Repositories;

public class TransactionRepository : GenericRepository<Transaction>, ITransactionRepository
{
	public TransactionRepository(ApplicationDbContext context) : base(context)
    {
    }
}