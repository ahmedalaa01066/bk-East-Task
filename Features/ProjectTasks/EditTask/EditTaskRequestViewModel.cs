using AutoMapper;
using EasyTask.Features.Common.TaskDependencies.DTOs;
using EasyTask.Features.ProjectTasks.EditTast.Commands;
using EasyTask.Features.ProjectTasks.EditTast.Orchestrators;
using EasyTask.Models.Enums;
using FluentValidation;

namespace EasyTask.Features.ProjectTasks.EditTast
{
    public record EditTaskRequestViewModel(string ID, string Name, DateTime StartDate, DateTime EndDate, string ProjectId,
       string WorkPackageId, TaskPriority TaskPriority, List<CreateTaskDependencyDTO>? WorkPackageDependencyDTOs);
    public class EditTaskRequestValidator : AbstractValidator<EditTaskRequestViewModel>
    {
        public EditTaskRequestValidator()
        {
        }
    }
    public class EditTaskRequestProfile : Profile
    {
        public EditTaskRequestProfile()
        {
            CreateMap<EditTaskRequestViewModel, EditTaskOrchestrators>();
            CreateMap<EditTaskRequestViewModel, EditTaskCommand>();
        }
    }
}
