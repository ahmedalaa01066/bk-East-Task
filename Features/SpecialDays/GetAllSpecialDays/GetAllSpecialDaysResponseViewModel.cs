using AutoMapper;
using EasyTask.Features.Common.SpecialDays.DTOs;

namespace EasyTask.Features.SpecialDays.GetAllSpecialDays
{
    public record GetAllSpecialDaysResponseViewModel(string ID, string Name, DateOnly FromDate,
        DateOnly? ToDate,
        bool IsOneDay);
    public class GetAllSpecialDaysResponseProfile : Profile
    {
        public GetAllSpecialDaysResponseProfile()
        {
            CreateMap<GetSpecialDayByIdDTO, GetAllSpecialDaysResponseViewModel>();
        }
    }
}
