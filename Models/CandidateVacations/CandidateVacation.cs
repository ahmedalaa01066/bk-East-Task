using EasyTask.Models.Candidates;
using EasyTask.Models.Vacations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyTask.Models.CandidateVacations
{
    [Table("CandidateVacation", Schema = "CandidateVacations")]
    public class CandidateVacation : BaseModel
    {
        [ForeignKey("Candidate")]
        public string CandidateId { get; set; }
        public Candidate? Candidate { get; set; }
        [ForeignKey("Vacation")]
        public string VacationId { get; set; }
        public Vacation? Vacation { get; set; }
        public int Counter { get; set; }
        public int Year { get; set; }   
    }
}
