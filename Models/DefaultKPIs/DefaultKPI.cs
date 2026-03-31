using EasyTask.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyTask.Models.DefaultKPIs
{
    [Table("DefaultKPI", Schema = "DefaultKPIs")]
    public class DefaultKPI : BaseModel
    {
        public string Name { get; set; }
        public KPIType Type { get; set; }
        public double Percentage { get; set; }
    }
}
