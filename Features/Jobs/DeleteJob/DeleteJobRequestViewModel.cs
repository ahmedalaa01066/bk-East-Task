using AutoMapper;
using EasyTask.Features.Jobs.DeleteJob.Commands;
using FluentValidation;

namespace EasyTask.Features.Jobs.DeleteJob
{
    public record DeleteJobRequestViewModel(string ID);
    public class DeleteJobRequestValidator : AbstractValidator<DeleteJobRequestViewModel>
    {
        public DeleteJobRequestValidator()
        {
        }
    }
    public class DeleteJobRequestProfile : Profile
    {
        public DeleteJobRequestProfile()
        {
            CreateMap<DeleteJobRequestViewModel, DeleteJobCommand>();
        }
    }
}
