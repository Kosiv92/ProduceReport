using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProduceReport.Contracts
{
    public record WorkshiftRequest
    {
        [Range(0, Int32.MaxValue, ErrorMessage = "Необходимо указать неотрицательное значение")]
        [DisplayName("Масса полученной продукции")]
        public double ProduceQuantity { get; init; } = 0;

        [Required(ErrorMessage = "Необходимо указать дату")]
        [DisplayName("Дата смены")]
        public DateTime Date { get; init; }                

        [Required(ErrorMessage = "Необходимо указать цех")]
        public int WorkshopId { get; init; }
    }
}
