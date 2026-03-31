using AutoMapper;
using EasyTask.Features.Penalities.EditPenality.Commands;
using FluentValidation;

namespace EasyTask.Features.Penalities.EditPenality
{
    public record EditPenalityRequestViewModel(string ID, string Description);
    public class EditPenalityRequestValidator : AbstractValidator<EditPenalityRequestViewModel>
    {
        public EditPenalityRequestValidator() { }
    }
    public class EditPenalityRequestProfile : Profile
    {
        public EditPenalityRequestProfile()
        {
            CreateMap<EditPenalityRequestViewModel, EditPenalityCommand>();
        }
    }
}
