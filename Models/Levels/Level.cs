using EasyTask.Common.Interfaces;
using EasyTask.Models.Candidates;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyTask.Models.Levels
{
    [Table("Level", Schema = "Levels")]
    public class Level : BaseModel, ISelectableListItem
    {
        public string Name { get; set; }
        public int Sequence { get; set; }
        public ICollection<Candidate> Candidates { get; set; }
    }
}
