
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ProduceReport.Core
{
    public class Workshop : BaseEntity
    {        
        public string Name { get; set; }

        public virtual List<Workshift> Workshifts { get; set; }
    }
}
