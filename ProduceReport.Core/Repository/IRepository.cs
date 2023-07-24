
namespace ProduceReport.Core
{
    public interface IRepository<T> where T : BaseEntity
    {
        public Task<T?> GetByIdAsync(int? id);

        public Task<IEnumerable<T>> GetAll();

        public Task<int> CreateAsync(T entity);                

        public Task DeleteAsync(int? id);

        public Task SaveChangesAsync();
    }
}
