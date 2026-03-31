using EasyTask.Common.Interfaces;
using EasyTask.Models.Candidates;
using EasyTask.Models.Managements;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyTask.Models.Jobs
{
    [Table("Job", Schema = "Jobs")]
    public class Job : BaseModel, ISelectableListItem
    {
        public string Name { get; set; }
        public string JobCode { get; set; }
        public string Description { get; set; }

        [ForeignKey("Management")]
        public string ManagementId { get; set; }
        public Management Management { get; set; }

        public ICollection<Candidate>? Candidates { get; set; }
    }
}
