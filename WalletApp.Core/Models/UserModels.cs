using System.Text.Json.Serialization;

namespace WalletApp.Core.Models;

public class UserBaseModels
{
    public Guid Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}

public class CreateUserModel : UserBaseModels
{
    [JsonIgnore]
    public Guid Id { get; set; }
}
