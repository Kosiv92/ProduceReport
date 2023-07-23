
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ProduceReport.Contracts
{
    public record WorkshopRequest
    {
        [Required()]
        [MaxLength(40, ErrorMessage = "Наименование не должно превышать 40 символов")]
        [DisplayName("Наименование цеха")]        
        public string Name { get; init; }
    }
}
