using AutoMapper;
using EasyTask.Features.ProjectTasks.DeleteTast.Orchestrators;
using EasyTask.Features.Tasks.DeleteTask.Commands;
using FluentValidation;

namespace EasyTask.Features.Tasks.DeleteTask
{
    public record DeleteTaskRequestViewModel(string ID);
    public class DeleteTaskRequestValidator : AbstractValidator<DeleteTaskRequestViewModel>
    {
        public DeleteTaskRequestValidator()
        {
        }
    }
    public class DeleteTaskRequestProfile : Profile
    {
        public DeleteTaskRequestProfile()
        {
            CreateMap<DeleteTaskRequestViewModel, DeleteTaskOrchestrators>();
            CreateMap<DeleteTaskOrchestrators, DeleteTaskCommand>();
        }
    }
}
