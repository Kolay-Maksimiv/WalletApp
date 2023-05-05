namespace WalletApp.Core.Entities;

public class User
{
    public Guid Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public virtual List<Transaction> Transactions { get; set; }
}
