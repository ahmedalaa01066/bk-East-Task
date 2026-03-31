using EasyTask.Common.Interfaces;
using EasyTask.Models.Candidates;
using EasyTask.Models.Managements;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyTask.Models.Departments
{
    [Table("Department", Schema = "Departments")]
    public class Department : BaseModel, ISelectableListItem
    {
        public string Name { get; set; }
        //remember to delete null from code 
        public string? Code { get; set; }
        [ForeignKey("Management")]
        public string ManagementId { get; set; }
        public Management Management { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Candidate>? Candidates { get; set; }
    }
}
