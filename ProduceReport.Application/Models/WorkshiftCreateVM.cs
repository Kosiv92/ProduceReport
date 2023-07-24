using Microsoft.AspNetCore.Mvc.Rendering;
using ProduceReport.Contracts;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProduceReport.Application.Models
{
    public class WorkshiftCreateVM
    {
        public WorkshiftRequest WorkshiftRequest { get; set; }

        [DisplayName("Наименование цеха")]
        public IEnumerable<SelectListItem>? WorkshopSelectList { get; set; }
    }
}
