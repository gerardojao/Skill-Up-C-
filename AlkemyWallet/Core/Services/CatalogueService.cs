using AlkemyWallet.Core.Interfaces;
using AlkemyWallet.Core.Models;
using AlkemyWallet.Core.Models.DTO;
using AlkemyWallet.Repositories.Interfaces;

namespace AlkemyWallet.Core.Services
{
    public class CatalogueService : ICatalogueService
    { 
        private readonly ICatalogueRepository _repo;

        public CatalogueService(ICatalogueRepository repo)
        {
            _repo = repo;

        }
        public async Task<Catalogue> GetCatalogueById(int id)
        {
            var catalogue = await _repo.GetById(id);            
            return catalogue;
        }

        public async Task<IEnumerable<Catalogue>> GetCatalogues()
        {
            var catalogues =   _repo.GetAllCatalogues();
            catalogues = catalogues.OrderBy(x => x.Points);
            return catalogues;
        }
    }
}
