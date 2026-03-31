using AutoMapper;
using EasyTask.Features.Attendances.EndAttendance.Commands;
using FluentValidation;

namespace EasyTask.Features.Attendances.EndAttendance
{
    public record EndAttendanceRequestViewModel(string ID);
    public class EndAttendanceRequestValidator : AbstractValidator<EndAttendanceRequestViewModel>
    {
        public EndAttendanceRequestValidator()
        {
        }
    }
    public class EndAttendanceRequestProfile : Profile
    {
        public EndAttendanceRequestProfile()
        {
            CreateMap<EndAttendanceRequestViewModel, EndAttendanceCommand>();
        }
    }
}
