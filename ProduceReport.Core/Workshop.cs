
namespace ProduceReport.Core
{
    public class Workshop : BaseEntity
    {
        public string Name { get; set; }

        public List<Workshift> Workshifts { get; set; }
    }
}
