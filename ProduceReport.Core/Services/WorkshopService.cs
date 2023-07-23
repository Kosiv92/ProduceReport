
namespace ProduceReport.Core
{
    public class WorkshopService : IEntityService<Workshop>
    {
        private readonly IRepository<Workshop> _repository;

        public WorkshopService(IRepository<Workshop> repository)
        {
            _repository = repository;
        }

        public async Task<int> Add(Workshop entity)
        {
            await _repository.CreateAsync(entity);
            await _repository.SaveChangesAsync();
            return entity.Id;
        }
        
        public async Task<IEnumerable<Workshop>> GetAll()
            => await _repository.GetAll();

        public async Task<Workshop> GetById(int? id)
            => await _repository.GetByIdAsync(id);
        
        public async Task Edit(Workshop entity)
        {
            var workshop = await _repository.GetByIdAsync(entity.Id);
            workshop.Name = entity.Name;
            await _repository.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {            
            await _repository.DeleteAsync(id);
            await _repository.SaveChangesAsync();
        }
    }
}
