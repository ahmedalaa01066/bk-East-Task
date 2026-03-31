using AutoMapper;
using FluentValidation;
using EasyTask.Features.Managements.CreateManagement.Commands;
using EasyTask.Features.Managements.CreateManagement.Orchestrator;

namespace EasyTask.Features.Managements.CreateManagement
{
    public record CreateManagementRequestViewModel(string Name, string ManagerId, List<string> DepartmentName);

    public class CreateManagementRequestValidator : AbstractValidator<CreateManagementRequestViewModel>
    {
        public CreateManagementRequestValidator()
        {
            RuleFor(request => request.Name).NotEmpty().Length(2, 200);
        }
    }
    public class CreateManagementEndPointRequestProfile : Profile
    {
        public CreateManagementEndPointRequestProfile()
        {
            CreateMap<CreateManagementRequestViewModel, CreateManagementOrchestrator>();
            CreateMap<CreateManagementOrchestrator, CreateManagementCommand>();
        }
    }

}
