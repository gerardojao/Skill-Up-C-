using AlkemyWallet.DataAccess;
using AlkemyWallet.Entities;
using AlkemyWallet.Repositories.Interfaces;

namespace AlkemyWallet.Repositories;

public class FixedTermDepositRepository : RepositoryBase<FixedTermDeposit>, IFixedTermDepositRepository
{
    public FixedTermDepositRepository(WalletDbContext context)
        : base(context)
    {
    }
    public async Task<IEnumerable<FixedTermDeposit>> GetByUser(int userId)
    {
        return await Task.FromResult(_context.Set<FixedTermDeposit>().Where(t => t.User_id == userId).AsEnumerable());
    }
    public async Task<FixedTermDeposit> GetById(int id, int userId)
    {
        return await Task.FromResult(_context.Set<FixedTermDeposit>().Where(t => t.User_id == userId && t.Id == id).FirstOrDefault());
    }
}