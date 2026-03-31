using AutoMapper;
using EasyTask.Features.Common.SpecialDays.DTOs;

namespace EasyTask.Features.SpecialDays.GetSpecialDayById
{
    public record GetSpecialDayByIdResponseViewModel(string ID, string Name, DateOnly FromDate, DateOnly? ToDate,
        bool IsOneDay);
    public class GetSpecialDayByIdResponseProfile : Profile
    {
        public GetSpecialDayByIdResponseProfile()
        {
            CreateMap<GetSpecialDayByIdDTO, GetSpecialDayByIdResponseViewModel>();
        }
    }
}
