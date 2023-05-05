using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using WalletApp.Core.Entities;
using WalletApp.Core.Models;
using WalletApp.Data.UnitOfWork;

namespace WalletApp.Service;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public UserService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task CreateUserAsync(CreateUserModel model)
    {
        var newUser = _mapper.Map<User>(model);

        await _unitOfWork.User.InsertAsync(newUser);

        await _unitOfWork.SaveAsync();
    }

    public async Task<List<UserBaseModels>> GetListOfUserAsync()
    {
        return await _unitOfWork.User.CustomQuery()
            .ProjectTo<UserBaseModels>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }
}

public interface IUserService
{
    public Task CreateUserAsync(CreateUserModel model);
    public Task<List<UserBaseModels>> GetListOfUserAsync();
}