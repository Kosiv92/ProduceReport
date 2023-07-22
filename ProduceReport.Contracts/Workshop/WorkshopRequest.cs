
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ProduceReport.Contracts
{
    public class WorkshopRequest
    {
        [DisplayName("Наименование цеха")]
        [Required]
        public string Name { get; set; }
    }
}
