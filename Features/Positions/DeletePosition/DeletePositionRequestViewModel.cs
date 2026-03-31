using AutoMapper;
using FluentValidation;
using EasyTask.Features.Positions.DeletePosition.Command;
namespace EasyTask.Features.Positions.DeletePosition;

public record DeletePositionRequestViewModel(string ID);
public class DeletePositionRequestValidator : AbstractValidator<DeletePositionRequestViewModel>
{
    public DeletePositionRequestValidator()
    {
        RuleFor(request => request.ID).NotEmpty().Length(1, 100);
    }
}
public class DeletePositionEndPointRequestProfile : Profile
{
    public DeletePositionEndPointRequestProfile()
    {
        CreateMap<DeletePositionRequestViewModel, DeletePositionCammand>();
    }
}

