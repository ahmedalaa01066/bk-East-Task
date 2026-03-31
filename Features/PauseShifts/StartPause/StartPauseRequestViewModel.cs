using AutoMapper;
using EasyTask.Features.PauseShifts.StartPause.Commands;
using EasyTask.Features.PauseShifts.StartPause.Orchestrators;
using FluentValidation;

namespace EasyTask.Features.PauseShifts.StartPause
{
    public record StartPauseRequestViewModel(string AttendanceId);
    public class StartPauseRequestValidator : AbstractValidator<StartPauseRequestViewModel>
    {
        public StartPauseRequestValidator()
        {
        }
    }
    public class StartPauseRequestProfile : Profile
    {
        public StartPauseRequestProfile()
        {
            CreateMap<StartPauseRequestViewModel, StartPauseOrchestrator>();
            CreateMap<StartPauseOrchestrator, StartPauseCommand>();
        }
    }
}
