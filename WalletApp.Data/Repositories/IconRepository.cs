using WalletApp.Core.Entities;
using WalletApp.Data.GenericRepository;
using WalletApp.Data.IRepositories;

namespace WalletApp.Data.Repositories;

public class IconRepository : GenericRepository<Icon>, IIconRepository
{
	public IconRepository(ApplicationDbContext context) : base(context)
	{
	}
}
