using AlkemyWallet.Repositories.Interfaces;
using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using LinqKit.Core;

namespace AlkemyWallet.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {

        protected readonly WalletDbContext _context;

        public RepositoryBase(WalletDbContext context)
        {
            _context = context;
        }


        /// <summary>
        /// Esta clase implementa un CRUD básico para cualquier entidad de Entity Framework

        public async Task<bool> Delete(int id)
        {
            var entity = await GetById(id);

            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                int rowsAffected = await _context.SaveChangesAsync();
                return rowsAffected > 0;
            }
            return false;

        }

      public async Task<IEnumerable<T>> GetAll() => await _context.Set<T>().ToListAsync();
   
      

        public async Task<T?> GetById(int id) => await _context.Set<T>().FindAsync(id);      

        public async Task Insert(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();          
        }


        public async Task<bool> Update(T entity)
        {

            _context.Update(entity);
            var rowsAffected = await _context.SaveChangesAsync();
            return rowsAffected > 0;                  

        }
    }
}

