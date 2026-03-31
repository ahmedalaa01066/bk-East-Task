using AutoMapper;
using EasyTask.Features.Positions.CreatePosition.Commands;
using FluentValidation;

namespace EasyTask.Features.Positions.CreatePosition
{
    public record CreatePositionRequestViewModel(string Name);
    public class CreatePositionRequestValidator : AbstractValidator<CreatePositionRequestViewModel>
    {
        public CreatePositionRequestValidator() { }
    }
    public class CreatePositionRequestProfile:Profile
    {
        public CreatePositionRequestProfile()
        {
            CreateMap<CreatePositionRequestViewModel, CreatePositionCommand>();
        }
    }
}
