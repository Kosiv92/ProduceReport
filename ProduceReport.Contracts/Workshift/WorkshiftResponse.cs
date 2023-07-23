
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ProduceReport.Contracts
{
    public record WorkshiftResponse
    {
        public int Id { get; init; }

        [Range(0, Int32.MaxValue, ErrorMessage = "Необходимо указать неотрицательное значение")]
        [DisplayName("Масса полученной продукции")]
        public double ProduceQuantity { get; init; }

        [Required(ErrorMessage = "Необходимо указать дату")]
        [DisplayName("Дата смены")]
        public DateTime Date { get; init; }

        [Required(ErrorMessage = "Необходимо указать цех")]
        public int WorkshopId { get; init; }

        public string? WorkshopName { get; init; }


    }
}
