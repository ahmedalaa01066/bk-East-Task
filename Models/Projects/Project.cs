using EasyTask.Models.Candidates;
using EasyTask.Models.Departments;
using EasyTask.Models.Managements;
using EasyTask.Models.ProjectTypes;
using EasyTask.Models.WorkPackages;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyTask.Models.Projects
{
    [Table("Project", Schema = "Projects")]
    public class Project : BaseModel
    {
        public string Name { get; set; } 
        public string ProjectCode { get; set; }

        public bool Strategic { get; set; }
        public bool Financial { get; set; }

        public DateTime? KickOffDate { get; set; }
        public bool IsKickOffmeeting { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public string? ProjectPurpose { get; set; }
        public string? Scope { get; set; }
        public string? Deliverables { get; set; }
        public string? HighLevelRequirements { get; set; }


        // ---------------- Relationships ----------------

        [ForeignKey("ProjectType")]
        public string ProjectTypeId { get; set; }
        public ProjectType? ProjectType { get; set; }

        [ForeignKey("ProjectManager")]
        public string ProjectManagerId { get; set; }
        public Candidate? ProjectManager { get; set; }

        [ForeignKey("ProjectOwner")]
        public string ProjectOwnerId { get; set; }
        public Candidate? ProjectOwner { get; set; }

        [ForeignKey("Management")]
        public string ManagementId { get; set; }
        public Management? Management { get; set; }

        [ForeignKey("Department")]
        public string DepartmentId { get; set; }
        public Department? Department { get; set; }

        public ICollection<Candidate>? ScrumMasters { get; set; }
        public ICollection<WorkPackage>? WorkPackages { get; set; }

        #region Navigation Properties

        // Initialize navigation collections to avoid null-reference issues when queried
        public ICollection<CandidateProject> Candidates { get; set; } = new List<CandidateProject>();

        #endregion

        //TODO :
        //list of stackholders (relation m-m with candidates)
        //list of work packages
        //list of milestones
    }
}
