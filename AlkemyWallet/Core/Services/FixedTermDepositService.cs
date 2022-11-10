using AlkemyWallet.Core.Interfaces;
using AlkemyWallet.Entities;
using AlkemyWallet.Repositories.Interfaces;

namespace AlkemyWallet.Core.Services
{
    public class FixedTermDepositService : IFixedTermDepositService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FixedTermDepositService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<FixedTermDeposit>> GetFixedTermDepositsByUserId(int userId)
        {
            var fixedTermDepositsByUserId = await _unitOfWork.FixedTermDepositDetailsRepository!.GetByUser(userId);
            return fixedTermDepositsByUserId;
        }

        public async Task<IEnumerable<FixedTermDeposit>> GetFixedTermDeposits()
        {
            var fixedTermDeposits = await _unitOfWork.FixedTermDepositRepository!.GetAll();
            return fixedTermDeposits;
        }

        //Get FixedTermDeposit by id from authorized user
        public async Task<FixedTermDeposit> GetFixedTermDepositById(int id, int userId)
        {
            var fixedTermDeposit = await _unitOfWork.FixedTermDepositDetailsRepository!.GetById(id, userId);
            if (fixedTermDeposit == null) throw new Exception("FixedTermDeposit not found");  
            return fixedTermDeposit;
        }
        //POST FixedTermDeposit
        public async Task<bool> InsertFixedTermDeposit(FixedTermDeposit fixedTermDeposit)
        {
            return false;
        }
    }
}
