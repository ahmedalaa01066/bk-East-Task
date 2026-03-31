using AutoMapper;
using EasyTask.Features.PauseShifts.StopPause.Commands;
using EasyTask.Features.PauseShifts.StopPause.Orchestrators;
using FluentValidation;

namespace EasyTask.Features.PauseShifts.StopPause
{
    public record StopPauseRequestViewModel(string ID);
    public class StopPauseRequestValidator : AbstractValidator<StopPauseRequestViewModel>
    {
        public StopPauseRequestValidator()
        {
        }
    }
    public class StopPauseRequestProfile : Profile
    {
        public StopPauseRequestProfile()
        {
            CreateMap<StopPauseRequestViewModel, StopPauseOrchestrator>();
            CreateMap<StopPauseOrchestrator, StopPauseCommand>();
        }
    }
}
