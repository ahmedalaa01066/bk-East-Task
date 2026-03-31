using EasyTask.Models.ExternalMembers;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyTask.Models.ExternalComapnies
{
    [Table("ExternalCompany",Schema = "ExternalCompanies")]
    public class ExternalCompany : BaseModel
    {
        public string Name { get; set; }
        public string? Location { get; set; }
        public ICollection<ExternalMember>? ExternalMembers { get; set; }
    }
}
