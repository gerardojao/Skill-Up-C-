using AlkemyWallet.Core.Interfaces;
using AlkemyWallet.Entities;
using AlkemyWallet.Repositories.Interfaces;
using AutoMapper;

namespace AlkemyWallet.Core.Services
{
    public class AccountService : IAccountService
    {
        
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;

        public AccountService(IUnitOfWork unitOfWork, IMapper mapper, IImageService imageService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _imageService = imageService;

        }

        public async Task<IEnumerable<Account>> GetAccounts()
        {
            var accounts = await _unitOfWork.AccountRepository.GetAll();
            return accounts;
        }
        
        public async Task<Account> GetAccountById(int id)
        {
            var account = await _unitOfWork.AccountRepository.GetById(id);
            return account;
        }
        public async Task<bool> Deposit(int id, int amount)
        {
            if (amount > 0)
            { 
                var accountEntity = await _unitOfWork.AccountRepository.GetById(id);
                if (accountEntity is null)
                    return false;
                accountEntity.Money += amount;
                var transactionsEntity = new Transaction
                {
                    Amount = amount,
                    Date = DateTime.Now,
                    Concept = "deposit",
                    Type = "topup",
                    Account_id = id,
                    User_id = 
                };
                // var transactionsEntity = await _unitOfWork.TransactionRepository.Insert(id);
                return await _unitOfWork.AccountRepository.Update(accountEntity);                
            }
            return false;

        }
    }
}