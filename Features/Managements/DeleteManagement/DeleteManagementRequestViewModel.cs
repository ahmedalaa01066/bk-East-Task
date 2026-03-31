using AutoMapper;
using FluentValidation;
using EasyTask.Features.Managements.DeleteManagement.Commands;
using EasyTask.Features.Managements.DeleteManagement.Orchestrator;

namespace EasyTask.Features.Managements.DeleteManagement
{
    public record DeleteManagementRequestViewModel(string ID);

    public class DeleteManagementRequestValidator : AbstractValidator<DeleteManagementRequestViewModel>
    {
        public DeleteManagementRequestValidator()
        {
            RuleFor(request => request.ID).NotEmpty().Length(1, 100);
        }
    }
    public class DeleteManagementEndPointRequestProfile : Profile
    {
        public DeleteManagementEndPointRequestProfile()
        {
            CreateMap<DeleteManagementRequestViewModel, DeleteManagementOrchestrator>();
            CreateMap<DeleteManagementOrchestrator, DeleteManagementCommand>();
        }
    }

}
