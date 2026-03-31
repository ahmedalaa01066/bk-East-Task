using AutoMapper;
using EasyTask.Features.Managements.DeactiveManagement.Commands;
using EasyTask.Features.Managements.DeactiveManagement.Orchestrator;
using FluentValidation;

namespace EasyTask.Features.Managements.DeactiveManagement
{
    public record DeactiveManagementRequestViewModel(string ID);
    public class DeactiveManagementRequestValidator : AbstractValidator<DeactiveManagementRequestViewModel>
    {
        public DeactiveManagementRequestValidator() { }
    }
    public class DeactiveManagementRequestProfile : Profile
    {
        public DeactiveManagementRequestProfile()
        {
            CreateMap<DeactiveManagementRequestViewModel, DeactiveManagementOrchestrator>();
            CreateMap<DeactiveManagementOrchestrator, DeactiveManagementCommand>();
        }
    }
}
