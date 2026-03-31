using AutoMapper;
using EasyTask.Features.Common.WorkPackageDependencies.DTO;
using EasyTask.Features.WorkPackages.CreateWorkPackage.Command;
using EasyTask.Features.WorkPackages.CreateWorkPackage.Orchestartor;
using FluentValidation;

namespace EasyTask.Features.WorkPackages.CreateWorkPackage
{
    public record CreateWorkPackageRequestViewModel(string Name, DateTime StartDate, DateTime EndDate, string ProjectId,
        List<CreateWorkPackageDependencyDTO>? WorkPackageDependencyDTOs);
    public class CreateWorkPackageRequestValidator : AbstractValidator<CreateWorkPackageRequestViewModel>
    {
        public CreateWorkPackageRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Work Package name is required.");
            RuleFor(x => x.ProjectId).NotEmpty().WithMessage("ProjectId is required.");
            RuleFor(x => x.StartDate)
                .LessThanOrEqualTo(x => x.EndDate)
                .WithMessage("Start Date must be before or equal to End Date.");

        }
    }
    public class CreateWorkPackageRequestProfile : Profile
    {
        public CreateWorkPackageRequestProfile()
        {
            CreateMap<CreateWorkPackageRequestViewModel, CreateWorkPackageOrchestartor>();
            CreateMap<CreateWorkPackageOrchestartor, CreateWorkPackageCommand>();
        }
    }
}
