using EasyTask.Common.Interfaces;
using EasyTask.Models.CandidateVacations;
using EasyTask.Models.VacationRequests;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyTask.Models.Vacations
{
    [Table("Vacation", Schema = "Vacations")]
    public class Vacation : BaseModel, ISelectableListItem
    {
        public string Name { get; set; }
        public int MaxRequestNum { get; set; }
        public int ConfirmationLayerNum { get; set; }
        public bool? IsSpecial { get; set; }
        public ICollection<VacationRequest> VacationRequests { get; set; }
        public ICollection<CandidateVacation> CandidateVacations { get; set; }
    }
}
