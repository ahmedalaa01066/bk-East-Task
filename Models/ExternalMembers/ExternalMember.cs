using EasyTask.Common.Interfaces;
using EasyTask.Models.ExternalComapnies;
using EasyTask.Models.ExternalMemberTasks;
using EasyTask.Models.Positions;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyTask.Models.ExternalMembers
{
    [Table("ExternalMember", Schema = "ExternalMember")]
    public class ExternalMember : BaseModel, ISelectableListItem
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public string Notes { get; set; }
        public string Description { get; set; }

        [ForeignKey("Position")]
        public string PositionId { get; set; }
        public Position Position { get; set; }

        [ForeignKey("ExternalCompany")]
        public string ExternalCompanyId { get; set; }
        public ExternalCompany ExternalCompany { get; set; }
        public ICollection<ExternalMemberTask>? ExternalMemberTasks { get; set; }
    }
}
