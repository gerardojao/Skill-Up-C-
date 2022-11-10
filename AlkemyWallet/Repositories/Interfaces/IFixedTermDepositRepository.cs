using AlkemyWallet.Entities;

namespace AlkemyWallet.Repositories.Interfaces;

public interface IFixedTermDepositRepository : IRepositoryBase<FixedTermDeposit>
{
    Task<IEnumerable<FixedTermDeposit>> GetByUser(int userId);
    Task<FixedTermDeposit> GetById(int id, int userId);
}