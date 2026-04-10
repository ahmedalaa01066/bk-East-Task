using AutoMapper;
using EasyTask.Features.Projects.GetAllProjectWorkPackages.Queries;
using FluentValidation;

namespace EasyTask.Features.Projects.GetAllProjectWorkPackages;

public record GetAllProjectWorkPackagesRequestVm(string ProjectId);

public class GetAllProjectWorkPackagesRequestValidator : AbstractValidator<GetAllProjectWorkPackagesRequestVm>
{
    public GetAllProjectWorkPackagesRequestValidator()
    {
        RuleFor(x => x.ProjectId)
            .NotEmpty().WithMessage("Project is required.")
            .NotNull().WithMessage("Project is required.");
    }
}

public class GetAllProjectWorkPackagesRequestProfile : Profile
{
    public GetAllProjectWorkPackagesRequestProfile()
    {
        CreateMap<GetAllProjectWorkPackagesRequestVm, GetAllProjectWorkPackagesQuery>();
    }
}
