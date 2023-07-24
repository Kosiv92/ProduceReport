using ProduceReport.Contracts;

namespace ProduceReport.Application.Models
{
    public class WorkshiftListVM
    {
        public IEnumerable<WorkshiftResponse> WorkshiftResponses { get; set; }

        public bool IsWorkshopsExists { get; set; }
    }
}
