using WalletApp.Core.Enums;

namespace WalletApp.Core.Entities;

public class Transaction
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid OwnerId { get; set; }
    public TypeTransaction TypeTransaction { get; set; }
    public DateTime DateTransaction { get; set; }
    public bool IsPending { get; set; }
    public string SenderName { get; set; }
    public int? IconId { get; set; }
    public double Sum { set; get; }
    public virtual Icon? Icon { get; set; }
    public virtual User Owner { get; set; }
}
