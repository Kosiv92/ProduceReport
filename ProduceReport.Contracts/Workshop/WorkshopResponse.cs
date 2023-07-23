
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProduceReport.Contracts
{
    public record WorkshopResponse
    {        
        [Required(ErrorMessage = "Необходимо указать цех")]
        public int Id { get; set; }

        [Required]
        [MaxLength(40, ErrorMessage = "Наименование не должно превышать 40 символов")]
        [DisplayName("Наименование цеха")]        
        public string Name { get; init; }
    }
}
