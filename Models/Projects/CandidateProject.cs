using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EasyTask.Models.Candidates;
using Hangfire.Annotations;

namespace EasyTask.Models.Projects;

[Table("CandidateProject", Schema = "Projects")]
public class CandidateProject : BaseModel
{
    [NotNull, MaxLength(36)]
    public string CandidateId { get; set; } = null!;
    
    [NotNull, MaxLength(36)]
    public string ProjectId { get; set; } = null!;

    #region Navigation Properties

    public Candidate Candidate { get; set; } = null!;
    public Project Project { get; set; } = null!;

    #endregion
}