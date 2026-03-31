using System.ComponentModel.DataAnnotations.Schema;

namespace EasyTask.Models.SpecialDays
{
    [Table("SpecialDay", Schema = "SpecialDays")]
    public class SpecialDay : BaseModel
    {
        public string Name { get; set; }
        public DateOnly FromDate { get; set; }
        public DateOnly? ToDate { get; set; }
        public bool IsOneDay { get; set; }
    }
}
