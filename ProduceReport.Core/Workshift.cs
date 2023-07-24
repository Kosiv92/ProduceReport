
namespace ProduceReport.Core
{
    public class Workshift : BaseEntity
    {
        public double ProduceQuantity { get; set; }

        public DateTime Date { get; set; }

        public int WorkshopId { get; set; }

        public virtual Workshop Workshop { get; set; }
    }
}
