using AutoMapper;
using FluentValidation;
using EasyTask.Features.Levels.DeleteLevel.Command;
namespace EasyTask.Features.Levels.DeleteLevel;

public record DeleteLevelRequestViewModel(string ID);
public class DeleteLevelRequestValidator : AbstractValidator<DeleteLevelRequestViewModel>
{
    public DeleteLevelRequestValidator()
    {
        RuleFor(request => request.ID).NotEmpty().Length(1, 100);
    }
}
public class DeleteLevelEndPointRequestProfile : Profile
{
    public DeleteLevelEndPointRequestProfile()
    {
        CreateMap<DeleteLevelRequestViewModel, DeleteLevelCammand>();
    }
}

