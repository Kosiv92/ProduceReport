namespace ProduceReport.Core
{
    public interface IEntityService<T> where T : BaseEntity
    {
        public Task<int> Add(T entity);

        public Task<IEnumerable<T>> GetAll();

        public Task<T> GetById(int? id);

        public Task Edit(T entity);

        public Task Delete(int id);

    }
}
