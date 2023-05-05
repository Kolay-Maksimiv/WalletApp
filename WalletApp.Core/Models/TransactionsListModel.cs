using System.Text.Json.Serialization;
using WalletApp.Core.Enums;

namespace WalletApp.Core.Models;

public class TransactionsListModel
{
    public List<TransactionViewModel> LatestTransactions { get; set; } = new List<TransactionViewModel>();
}

public class BloсsModel
{
    public double CardBalance { get; set; }
    public double Available { get; set; }
    public string NoPaymentDue { get; set; }
    public int DailyPoints { get; set; }
}

public class TransactionBaseModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string SenderName { get; set; }
}

public class TransactionViewModel: TransactionBaseModel
{  
    public string DateTransaction { get; set; }
    public string? Icon { get; set; }
    public string Sum { set; get; }

}

public class CreateTransactionModel : TransactionBaseModel
{
    [JsonIgnore]
    public int Id { get; set; }
    public string OwnerId { get; set; }
    public double Sum { set; get; }
    public bool IsPending { set; get; }
    public TypeTransaction TypeTransaction { get; set; }
    public int? IconId { get; set; }
}
