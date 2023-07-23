using Microsoft.AspNetCore.Mvc.Rendering;
using ProduceReport.Contracts;
using System.ComponentModel;

namespace ProduceReport.Application.Models
{
    public class WorkshiftEditVM
    {
        public WorkshiftResponse WorkshiftResponse { get; set; }

        [DisplayName("Наименование цеха")]
        public IEnumerable<SelectListItem>? WorkshopSelectList { get; set; }
    }
}
