﻿using WalletApp.Core.Entities;
using WalletApp.Data.GenericRepository;

namespace WalletApp.Data.IRepositories;

public interface ITransactionRepository : IGenericRepository<Transaction>
{
}
