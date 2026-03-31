using AutoMapper;
using EasyTask.Features.Common.TaskDependencies.DTOs;
using EasyTask.Features.ProjectTasks.CreateTask.Commands;
using EasyTask.Features.ProjectTasks.CreateTask.Orchestrators;
using EasyTask.Models.Enums;
using FluentValidation;

namespace EasyTask.Features.ProjectTasks.CreateTask
{
    public record CreateTaskRequestViewModel(string Name, DateTime StartDate, DateTime EndDate, string ProjectId,
       string WorkPackageId, TaskPriority TaskPriority, List<CreateTaskDependencyDTO>? WorkPackageDependencyDTOs);
    public class CreateTaskRequestValidator : AbstractValidator<CreateTaskRequestViewModel>
    {
        public CreateTaskRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Work Package name is required.");
            RuleFor(x => x.ProjectId).NotEmpty().WithMessage("ProjectId is required.");
            RuleFor(x => x.WorkPackageId).NotEmpty().WithMessage("WorkPackageId is required.");
            RuleFor(x => x.StartDate)
                .LessThanOrEqualTo(x => x.EndDate)
                .WithMessage("Start Date must be before or equal to End Date.");
        }
    }
    public class CreateTaskRequestProfile : Profile
    {
        public CreateTaskRequestProfile()
        {
            CreateMap<CreateTaskRequestViewModel, CreateTaskOrchestrator>();
            CreateMap<CreateTaskOrchestrator, CreateTaskCommand>();
        }
    }
}
