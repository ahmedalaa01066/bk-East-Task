using EasyTask.Models.Projects;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyTask.Models.ProjectTypes
{
    [Table("ProjectType",Schema = "ProjectTypes")]
    public class ProjectType : BaseModel
    {
        public string Name { get; set; }
        public List<Project> Project { get; set; }
    }
}
