using Microsoft.EntityFrameworkCore;
using SimpleStore.Api.Contracts;

namespace SimpleStore.Api.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly SimpleStoreDbContext _context;

        public GenericRepository(SimpleStoreDbContext context)
        {
            _context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Exists(int id)
        {
            var entity = await GetByIdAsync(id);
            return entity != null;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int? id)
        {
            if (id is null)
            {
                return null;
            }

            return await _context.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
           _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
