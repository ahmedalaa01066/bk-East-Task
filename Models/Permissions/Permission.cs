using EasyTask.Common.Interfaces;
using EasyTask.Models.CandidatePermissions;
using EasyTask.Models.PermissionRequests;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyTask.Models.Permissions
{
    [Table("Permission", Schema = "Permissions")]
    public class Permission : BaseModel, ISelectableListItem
    {
        public string Name { get; set; }
        public int MaxHours { get; set; }
        public int MinHours { get; set; }
        public int MaxRepeatTimes { get; set; }
        public int MaxHoursPerMonth { get; set; }
        public ICollection<PermissionRequest> PermissionRequests { get; set; }
        public ICollection<CandidatePermission> CandidatePermissions { get; set; }
    }
}
