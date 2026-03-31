using EasyTask.Models.Candidates;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyTask.Models.Penalities
{
    [Table("Penality", Schema = "Penalities")]
    public class Penality : BaseModel
    {
        public string Description { get; set; }

        [ForeignKey("Candidate")]
        public string CandidateId { get; set; }
        public Candidate Candidate { get; set; }
    }
}
