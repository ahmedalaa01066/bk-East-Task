using AutoMapper;
using EasyTask.Features.Managements.ActiveManagement.Commands;
using EasyTask.Features.Managements.ActiveManagement.Orchestrator;
using FluentValidation;

namespace EasyTask.Features.Managements.ActiveManagement
{
    public record ActiveManagementRequestViewModel(string ID);
    public class ActiveManagementRequestValidator : AbstractValidator<ActiveManagementRequestViewModel>
    {
        public ActiveManagementRequestValidator() { }
    }
    public class ActiveManagementRequestProfile : Profile
    {
        public ActiveManagementRequestProfile()
        {
            CreateMap<ActiveManagementRequestViewModel, ActiveManagementOrchestrator>();
            CreateMap<ActiveManagementOrchestrator, ActiveManagementCommand>();
        }
    }
}
