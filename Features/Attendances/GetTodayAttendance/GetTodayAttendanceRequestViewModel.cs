using AutoMapper;
using EasyTask.Features.Common.Attendances.Queries;
using FluentValidation;

namespace EasyTask.Features.Attendances.GetTodayAttendance
{
    public record GetTodayAttendanceRequestViewModel();
    public class GetTodayAttendanceRequestValidator : AbstractValidator<GetTodayAttendanceRequestViewModel>
    {
        public GetTodayAttendanceRequestValidator()
        {
        }
    }
    public class GetTodayAttendanceRequestProfile : Profile
    {
        public GetTodayAttendanceRequestProfile()
        {
            CreateMap<GetTodayAttendanceRequestViewModel, GetTodayAttendanceQuery>();
        }
    }
}
