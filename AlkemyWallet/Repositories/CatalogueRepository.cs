using AlkemyWallet.Core.Models;
using AlkemyWallet.Repositories.Interfaces;

namespace AlkemyWallet.Repositories
{
    public class CatalogueRepository : RepositoryBase<Catalogue>, ICatalogueRepository
    {
        public CatalogueRepository(WalletDbContext context)
            : base(context)
        {

        }

        public IEnumerable<Catalogue> GetAllCatalogues() => _context.Catalogues.AsEnumerable();
    }
}

