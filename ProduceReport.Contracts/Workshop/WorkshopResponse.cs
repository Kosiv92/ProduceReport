
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProduceReport.Contracts
{
    public class WorkshopResponse
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Наименование цеха")]
        public string Name { get; set; }
    }
}
