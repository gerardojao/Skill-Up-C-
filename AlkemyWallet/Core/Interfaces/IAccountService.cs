using AlkemyWallet.Core.Models;
using AlkemyWallet.Entities;

namespace AlkemyWallet.Core.Interfaces
{
    public interface IAccountService
    {
        Task<IEnumerable<Account>> GetAccounts();
        Task<Account> GetAccountById(int id);
        Task<bool> Deposit(int id, int amount);
    }
}