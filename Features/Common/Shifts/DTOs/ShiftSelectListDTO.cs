using AutoMapper;
using EasyTask.Models.Shifts;

namespace EasyTask.Features.Common.Shifts.DTOs
{
    public class ShiftSelectListDTO 
    { 
        public string ID { get; set; }
        public string Name { get; set; }
        public TimeSpan FromTime { get; set; }
        public TimeSpan ToTime { get; set; }
    }
    public class ShiftSelectListDTOProfile : Profile
    {
        public ShiftSelectListDTOProfile()
        {
            CreateMap<Shift, ShiftSelectListDTO>();
        }
    }
}
