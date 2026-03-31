using AutoMapper;
using EasyTask.Features.Projects.CreateProject.Commands;
using EasyTask.Models.Projects;
using FluentValidation;

namespace EasyTask.Features.Projects.CreateProject
{
    public record CreateProjectRequestViewModel(
        string Name,
        bool Strategic,
        bool Financial,
        DateTime? KickOffDate,
        bool IsKickOffmeeting,
        DateTime StartDate,
        DateTime? EndDate,
        string? ProjectPurpose,
        string? Scope,
        string? Deliverables,
        string? HighLevelRequirements,
        string ProjectTypeId,
        string ProjectManagerId,
        string ProjectOwnerId,
        string ManagementId,
        string DepartmentId,
        ICollection<string>? ScrumMastersIds
    );
    public class CreateProjectRequestValidator : AbstractValidator<CreateProjectRequestViewModel>
    {
        public CreateProjectRequestValidator() 
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
            RuleFor(x => x.StartDate).NotEmpty();
            RuleFor(x => x.ProjectTypeId).NotEmpty();
            RuleFor(x => x.ProjectManagerId).NotEmpty();
            RuleFor(x => x.ProjectOwnerId).NotEmpty();
            RuleFor(x => x.ManagementId).NotEmpty();
            RuleFor(x => x.DepartmentId).NotEmpty();
        }
    }
    public class CreateProjectRequestProfile:Profile
    {
        public CreateProjectRequestProfile()
        {
            CreateMap<CreateProjectRequestViewModel, CreateProjectCommand>();
            CreateMap<CreateProjectCommand , Project>().ForMember(dest => dest.ScrumMasters, opt => opt.Ignore());
        }
    }
}
