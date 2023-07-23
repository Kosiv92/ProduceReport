
namespace ProduceReport.Core.Services
{
    public class WorkshiftService : IEntityService<Workshift>
    {
        private readonly IRepository<Workshift> _repository;

        public WorkshiftService(IRepository<Workshift> repository)
        {
            _repository = repository;
        }

        public async Task<int> Add(Workshift entity)
        {
            await _repository.CreateAsync(entity);
            await _repository.SaveChangesAsync();
            return entity.Id;
        }

        public async Task Delete(int id)
        {
            await _repository.DeleteAsync(id);
            await _repository.SaveChangesAsync();
        }

        public async Task Edit(Workshift entity)
        {
            var workshift = await _repository.GetByIdAsync(entity.Id);

            workshift.ProduceQuantity = entity.ProduceQuantity;
            workshift.Date = entity.Date;
            workshift.WorkshopId = entity.WorkshopId;

            await _repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<Workshift>> GetAll()
         => await _repository.GetAll();

        public async Task<Workshift> GetById(int? id)
            => await _repository.GetByIdAsync(id);
    }
}
