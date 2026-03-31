using EasyTask.Common.Interfaces;
using EasyTask.Models.Candidates;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyTask.Models.Positions
{
    [Table("Position", Schema = "Positions")]
    public class Position: BaseModel,ISelectableListItem
    {
        public string Name { get; set; }
        public ICollection<Candidate> Candidates { get; set; }
    }
    
}
