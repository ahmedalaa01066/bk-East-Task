using EasyTask.Models.Candidates;
using EasyTask.Models.KPIs;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyTask.Models.CandidateKPIs
{
    [Table("CandidateKPI", Schema = "CandidateKPIs")]
    public class CandidateKPI : BaseModel
    {
        [ForeignKey("Candidate")]
        public string CandidateId { get; set; }
        public Candidate? Candidate { get; set; }
        [ForeignKey("KPI")]
        public string KPIId { get; set; }
        public KPI? KPI { get; set; }
        public double Percentage { get; set; }
    }
}
