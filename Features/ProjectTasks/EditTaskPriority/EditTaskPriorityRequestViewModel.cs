using AutoMapper;
using EasyTask.Features.ProjectTasks.EditTaskPriority.Commands;
using EasyTask.Models.Enums;
using FluentValidation;

namespace EasyTask.Features.ProjectTasks.EditTaskPriority
{
    public record EditTaskPriorityRequestViewModel(string ID, TaskPriority TaskPriority);
    public class EditTaskPriorityRequestValidator : AbstractValidator<EditTaskPriorityRequestViewModel>
    {
        public EditTaskPriorityRequestValidator()
        {
        }
    }
    public class EditTaskPriorityRequestProfile : Profile
    {
        public EditTaskPriorityRequestProfile()
        {
            CreateMap<EditTaskPriorityRequestViewModel, EditTaskPriorityCommand>();
        }
    }
}
