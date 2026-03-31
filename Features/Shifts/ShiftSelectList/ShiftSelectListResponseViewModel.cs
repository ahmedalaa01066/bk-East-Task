using AutoMapper;
using EasyTask.Features.Common.Shifts.DTOs;

namespace EasyTask.Features.Shifts.ShiftSelectList
{
    public record ShiftSelectListResponseViewModel(string ID, string Name, TimeSpan FromTime, TimeSpan ToTime);
    public class ShiftSelectListResponseProfile:Profile
    {
        public ShiftSelectListResponseProfile()
        {
            CreateMap<ShiftSelectListDTO, ShiftSelectListResponseViewModel>();
        }
    }
}
