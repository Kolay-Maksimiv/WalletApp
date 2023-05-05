using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using WalletApp.Core.Entities;
using WalletApp.Core.HelperModels;
using WalletApp.Core.Models;
using WalletApp.Data.UnitOfWork;

namespace WalletApp.Service;

public class TransactionService : ITransactionService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public TransactionService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task CreateTransactionAsync(CreateTransactionModel model)
    {
        var newTransaction = _mapper.Map<Transaction>(model);

        await _unitOfWork.Transaction.InsertAsync(newTransaction);

        await _unitOfWork.SaveAsync();
    }

    public async Task DeleteTransactionAsync(int id)
    {
        var transaction = await _unitOfWork.Transaction.GetFirstAsync(t => t.Id == id);

        if (transaction is null)
            throw new NotFoundException("Transaction not found.");

        _unitOfWork.Transaction.Delete(transaction);

        await _unitOfWork.SaveAsync();
    }

    public async Task<TransactionsListModel> GetTransactionsAsync(string userId)
    {
        var userTransactions = await _unitOfWork.Transaction.GetListAsync(x => x.OwnerId.ToString() == userId);

        return new TransactionsListModel
        {
            LatestTransactions = _mapper.Map<List<TransactionViewModel>>(userTransactions.Take(10))
        };
    }

    public BloсsModel GetBlock()
    {
        var (cardBalance, available) = GenerateRandBalence();

        return new BloсsModel
        {
            CardBalance = cardBalance,
            Available = available,
            NoPaymentDue = $"You’ve paid your {DateTime.Now:MMM} balance",
            DailyPoints = CalculateDailyPoints(),
        };
    }

    public async Task<TransactionViewModel> GetTransactionByIdAsync(int id)
    {
        return await _unitOfWork.Transaction.CustomQuery().Include(x => x.Icon).Where(x => x.Id == id)
            .ProjectTo<TransactionViewModel>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync()
            ?? throw new NotFoundException("Transaction not found.");
    }

    private static int CalculateDailyPoints()
    {
        // Отримуємо поточну дату
        DateTime today = DateTime.Today;

        // Визначаємо, до якої пори року належить поточна дата
        int season = (today.Month - 1) / 3;

        // Визначаємо дату початку пори року
        DateTime seasonStart = new DateTime(today.Year, season * 3 + 1, 1);

        // Обчислюємо кількість днів з початку пори року
        int daysInSeason = (today - seasonStart).Days;

        // Обчислюємо кількість поінтів на основі дати та кількості днів в порі року
        return CalculatePoints(daysInSeason);
    }

    private static int CalculatePoints(int daysInSeason)
    {
        int points = 0;

        if (daysInSeason == 0)
        {
            // Перший день пори року - 2 поінти
            points = 2;
        }
        else if (daysInSeason == 1)
        {
            // Другий день пори року - 3 поінти
            points = 3;
        }
        else
        {
            // Обчислюємо поінти за попередні дні
            int prevDayPoints = CalculatePoints(daysInSeason - 1);
            int prevPrevDayPoints = CalculatePoints(daysInSeason - 2);

            // Обчислюємо поточну кількість поінтів
            points = (int)(prevDayPoints * 1.0 + prevPrevDayPoints * 0.6 + 0.5);

            // Округлюємо кількість поінтів
            if (points >= 1000)
            {
                points = (points + 500) / 1000 * 1000;
            }
        }

        return points;
    }

    private (double, double) GenerateRandBalence()
    {
        Random rnd = new Random();
        double cardBalance = rnd.NextDouble() * 1500.0;
        double cardLimit = 1500.0;
        double available = cardLimit - cardBalance;
        return (Math.Round(cardBalance, 2), Math.Round(available, 2));
    }

}

public interface ITransactionService
{
    public BloсsModel GetBlock();
    public Task CreateTransactionAsync(CreateTransactionModel model);
    public Task DeleteTransactionAsync(int id);
    public Task<TransactionsListModel> GetTransactionsAsync(string userId);
    public Task<TransactionViewModel> GetTransactionByIdAsync(int id);
}