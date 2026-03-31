using AutoMapper;
using EasyTask.Features.Managements.EditManagement.Commands;
using EasyTask.Features.Managements.EditManagement.Orchestrator;
using FluentValidation;

namespace EasyTask.Features.Managements.EditManagement
{
    public record EditManagementRequestViewModel(string ID, string Name, string? ManagerId);

    public class EditManagementRequestValidator : AbstractValidator<EditManagementRequestViewModel>
    {
        public EditManagementRequestValidator()
        {
            RuleFor(request => request.Name).NotEmpty().Length(2, 200);
            RuleFor(request => request.ID).NotEmpty().Length(1, 100);
        }

    }
    public class EditManagementEndPointRequestProfile : Profile
    {
        public EditManagementEndPointRequestProfile()
        {
            CreateMap<EditManagementRequestViewModel, EditManagementOrchestrator>();
            CreateMap<EditManagementOrchestrator, EditManagementCommand>();
        }
    }

}
