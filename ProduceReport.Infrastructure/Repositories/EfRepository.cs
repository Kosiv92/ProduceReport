using Microsoft.EntityFrameworkCore;
using ProduceReport.Core;

namespace ProduceReport.Infrastructure.Repositories
{
    public class EfRepository<T> : IRepository<T> where T : BaseEntity
    {
        public DbContext _context;
        public DbSet<T> _dbSet;

        public EfRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<int> CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            return entity.Id;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
                throw new NotFoundException(nameof(entity), id);

            _dbSet.Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
            => await _dbSet.FirstOrDefaultAsync(x => x.Id == id);


        public async Task SaveChangesAsync()
            => await _context.SaveChangesAsync();
                
    }
}
