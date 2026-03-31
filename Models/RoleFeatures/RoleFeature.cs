using EasyTask.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using Role = EasyTask.Models.Enums.Role;

namespace EasyTask.Models.RoleFeatures
{
    [Table("RoleFeature", Schema = "RoleFeatures")]

    public class RoleFeature:BaseModel
    {
        //[ForeignKey("Role")]
        //public string RoleId { get; set; }

        public Role RoleId { get; set; }
        public Feature Features { get; set; }
    }
}
