using AlkemyWallet.DataAccess;
using AlkemyWallet.Entities;
using AlkemyWallet.Repositories.Interfaces;

namespace AlkemyWallet.Repositories;

public class UnitOfWork : IUnitOfWork
{

    private WalletDbContext _dbContext;
    private IRepositoryBase<Account>? _accountRepository;
    private IAccountRepository? _accountWithDetails;
    private IRepositoryBase<Catalogue>? _catalogueRepository;
    private ICatalogueRepository? _catalogueByPoints;
    private IRepositoryBase<FixedTermDeposit>? _fixedTermDepositRepository;
    private IFixedTermDepositRepository? _fixedTermDepositDetailsRepository;
    private IRepositoryBase<Role>? _roleRepository;
    private ITransactionRepository? _transactionRepository;
    private IUserRepository? _userDetailsRepository;
    private IRepositoryBase<User>? _userRepository;

    public IRepositoryBase<FixedTermDeposit> FixedTermDepositRepository => _fixedTermDepositRepository ?? new FixedTermDepositRepository(_dbContext);
    public IFixedTermDepositRepository FixedTermDepositDetailsRepository => _fixedTermDepositDetailsRepository ?? new FixedTermDepositRepository(_dbContext);
    public IRepositoryBase<User> UserRepository => _userRepository ?? new RepositoryBase<User>(_dbContext);
    public IUserRepository UserDetailsRepository => _userDetailsRepository ?? new UserRepository(_dbContext);
    public IRepositoryBase<Account> AccountRepository => _accountRepository ?? new RepositoryBase<Account>(_dbContext);
    public IAccountRepository AccountWithDetails => _accountWithDetails ?? new AccountRepository(_dbContext);
    public ITransactionRepository TransactionRepository => _transactionRepository ?? new TransactionRepository(_dbContext);
    public IRepositoryBase<Role> RoleRepository => _roleRepository ?? new RepositoryBase<Role>(_dbContext);
    public IRepositoryBase<Catalogue> CatalogueRepository => _catalogueRepository ?? new RepositoryBase<Catalogue>(_dbContext);
    public ICatalogueRepository CatalogueByPoints => _catalogueByPoints ?? new CatalogueRepository(_dbContext);

    public UnitOfWork(WalletDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public void Dispose()
    {
        _dbContext?.Dispose();
        GC.SuppressFinalize(this);
    }

    public int SaveChanges()
    {
        return _dbContext.SaveChanges();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _dbContext.SaveChangesAsync();
    }
}