using WalletApp.Core.Entities;
using WalletApp.Data.GenericRepository;
using WalletApp.Data.IRepositories;

namespace WalletApp.Data.Repositories;

public class UsersRepository : GenericRepository<User>, IUsersRepository
{
    public UsersRepository(ApplicationDbContext context) : base(context)
    {
    }
}
