
using Backend.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.Identity.Client;
namespace Backend.Persistence.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T>, IDisposable
    where T : class 
    {
        private readonly DataContext _context;
        private readonly DbSet<T> _dbSet;
        public BaseRepository(DataContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public IQueryable<T> GetQueryable()
        {
            return _dbSet.AsQueryable();
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var items = await _dbSet.ToListAsync();
            return items;
        }
        public async Task<T> GetByIdAsync( int id )
        {
            var item = await _dbSet.FindAsync(id);
            return item;
        }
        public async Task<T> AddAsync( T entity )
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<IEnumerable<T>> AddAll (IEnumerable<T> entities)
        {
            await _context.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
            return entities;
        }
        public async Task<bool> UpdateAsync(int id, T entity)
        {
            var item = await _dbSet.FindAsync(id);
            if (item is not null){
                _context.Update(item);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task <bool> DeleteAsync(int id)
        {
            var item = await _dbSet.FindAsync(id);
            if (item is not null){
                _context.Remove(item);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task <bool> DeleteAsync(T TEntity)
        {
            _context.Remove(TEntity);
            await _context.SaveChangesAsync();
            return true;
        }
        public void Dispose ()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
