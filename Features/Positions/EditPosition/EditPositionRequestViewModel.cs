using AutoMapper;
using EasyTask.Features.Positions.EditPositions.Commands;
using FluentValidation;

namespace EasyTask.Features.Positions.EditPositions
{
    public record EditPositionRequestViewModel(string ID, string Name);
    public class EditPositionsRequestValidator : AbstractValidator<EditPositionRequestViewModel>
    {
        public EditPositionsRequestValidator()
        {
        }
    }
    public class EditPositionsRequestProfile : Profile
    {
        public EditPositionsRequestProfile()
        {
            CreateMap<EditPositionRequestViewModel, EditPositionCommand>();
        }
    }
}
