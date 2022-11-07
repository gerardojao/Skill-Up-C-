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

        public async Task<(bool Success, string Message)> Deposit(int id, int amount)
        {
            //el monto ingresado debe ser mayor a 0
            if (amount > 0)
            {
                var account = await _unitOfWork.AccountWithDetails.GetByIdWithDetail(id);

                if (account is null)
                    return (false, "El id de la cuenta que ingreso no fue encontrado.");
                if (account.IsBlocked)
                    return (false, "Su cuenta esta bloqueada, no puede realizar operaciones.");

                //se suman los puntos al usuario un 2% redondeado en el deposito
                account.Money += amount;
                decimal porcentaje = amount * 2m / 100m;
                porcentaje = Math.Round(porcentaje);
                account.User!.Points += Convert.ToInt32(porcentaje);

                var transaction = new Transaction()
                {
                    Amount = amount,
                    Concept = "Deposit",
                    Date = DateTime.Now,
                    Type = "Topup",
                    User_id = id,
                    Account_id = account.Id,
                };

                await _unitOfWork.TransactionRepository.Insert(transaction);


                await _unitOfWork.AccountRepository.Update(account);
                return (true, "Transferencia exitosa.");
            }
            else
            {
                return (false, "El importe ingresado debe ser mayor a 0");
            }

        }

        public async Task <(bool Success, string Message)> Transfer(int id, int amount, int toAccountId)
        {
            if (amount > 0)
            {
                
                //traigo el usuario que transfiere el dinero
                var account = await _unitOfWork.AccountWithDetails.GetByIdWithDetail(id);

                if (account is null)
                    return (false, "El id de la cuenta que ingreso no fue encontrado.");
            if (account.IsBlocked)
                    return (false, "Su cuenta esta bloqueada, no puede realizar operaciones.");
               if(account.Money < amount)
                     return (false, "El dinero disponible en la cuenta es menor que el importe a transferir.");
                account.Money -= amount;
                decimal porcentaje = amount * 3m / 100m;
                porcentaje = Math.Round(porcentaje);
                account.User!.Points += Convert.ToInt32(porcentaje);
           

            //traigo el usuario que recibe el dinero
            var toAccount = await _unitOfWork.AccountWithDetails.GetByIdWithDetail(toAccountId);
            if (toAccount is null)
                return (false, "La cuenta a la que desea transferir no fue encontrada.");
            if (toAccount.IsBlocked)
                return (false, "La cuenta a la que desea transferir esta bloqueada, no puede realizar operaciones.");
            toAccount.Money += amount;

            var transaction = new Transaction()
                {
                    Amount = amount,
                    Concept = "transfer",
                    Date = DateTime.Now,
                    Type = "Payment",
                    User_id = id,
                    Account_id = account.Id,
                    To_Account = toAccountId,
            };

                await _unitOfWork.TransactionRepository.Insert(transaction);


                await _unitOfWork.AccountRepository.Update(account);
                await _unitOfWork.AccountRepository.Update(toAccount);

            return (true, "Transferencia exitosa.");

        }
            else
            {
                return (false, "El importe ingresado debe ser mayor a 0");
            }

}

    }
}