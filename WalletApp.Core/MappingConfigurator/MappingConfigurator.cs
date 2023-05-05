using AutoMapper;
using WalletApp.Core.Entities;
using WalletApp.Core.Enums;
using WalletApp.Core.Models;

namespace WalletApp.Core.MappingConfigurator;

public class MappingConfigurator : Profile
{
    public MappingConfigurator()
    {
        CreateMap<Transaction, TransactionViewModel>()
            .ForMember(x => x.DateTransaction,
                opt => opt.MapFrom(x => x.DateTransaction >= DateTime.Now.AddDays(-7)
                        ? DateTime.Now.ToString("dddd")
                        : x.DateTransaction.ToString("dd/MM/yy")))
            .ForMember(x => x.Sum,
                opt => opt.MapFrom(x => x.TypeTransaction == TypeTransaction.Payment
                        ? $"+{x.Sum}"
                        : $"-{x.Sum}"))
            .ForMember(x => x.Description,
                opt => opt.MapFrom(x => x.IsPending == true
                        ? $"Pending - {x.Description}"
                        : x.Description))
            .ForMember(x => x.Icon,
                opt => opt.MapFrom(x => x.Icon.IconUrl ?? null))
                .ReverseMap();

        CreateMap<CreateTransactionModel, Transaction>()
            .ForMember(x => x.DateTransaction,
                opt => opt.MapFrom(x => DateTime.Now));

        CreateMap<CreateUserModel, User>();

        CreateMap<User, UserBaseModels>();

    }
}
