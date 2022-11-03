using AlkemyWallet.Core.Models;

namespace AlkemyWallet.Repositories.Interfaces
{

    public interface ICatalogueRepository : IRepositoryBase<Catalogue>
    {
        public IEnumerable<Catalogue> GetAllCatalogues();
    }
}
