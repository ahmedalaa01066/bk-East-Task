using EasyTask.Common.Interfaces;
using EasyTask.Models.Candidates;
using EasyTask.Models.Departments;
using EasyTask.Models.Jobs;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyTask.Models.Managements
{
    [Table("Management", Schema = "Managements")]
    public class Management : BaseModel, ISelectableListItem
    {
        public string Name { get; set; }
        //remember to delete null from code 
        public string? Code { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey("Manager")]
        public string? ManagerId { get; set; }
        public Candidate? Manager { get; set; }

        public Collection<Department> Departments { get; set; }
        public ICollection<Candidate>? Candidates { get; set; }
        public ICollection<Job>? Jobs { get; set; }
    }
}
