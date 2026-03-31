using EasyTask.Models.CandidateKPIs;
using EasyTask.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyTask.Models.KPIs
{
    [Table("KPI", Schema = "KPIs")]
    public class KPI : BaseModel
    {
        public string Name { get; set; }
        public KPIType Type { get; set; }
        public ICollection<CandidateKPI> CandidateKPIs { get; set; }
    }
}
