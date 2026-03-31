using AutoMapper;
using EasyTask.Features.Jobs.EditJob.Commands;
using FluentValidation;

namespace EasyTask.Features.Jobs.EditJob
{
    public record EditJobRequestViewModel(
       string ID,
        string? Name,
        string? Description,
        string? ManagementId
    );
    public class EditJobRequestValidator : AbstractValidator<EditJobRequestViewModel>
    {
        public EditJobRequestValidator()
        {

        }
    }
    public class EditJobRequestProfile : Profile
    {
        public EditJobRequestProfile()
        {
            CreateMap<EditJobRequestViewModel, EditJobCommand>();
        }
    }
}
