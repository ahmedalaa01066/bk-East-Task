using AutoMapper;
using EasyTask.Features.Projects.Edit_Project.Commands;
using FluentValidation;

namespace EasyTask.Features.Projects.Edit_Project
{
    public record EditProjectRequestViewModel(
        string ID,
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
    public class EditProjectRequestValidator : AbstractValidator<EditProjectRequestViewModel>
    {
        public EditProjectRequestValidator()
        {
        }
    }
    public class EditProjectRequestProfile : Profile
    {
        public EditProjectRequestProfile()
        {
            CreateMap<EditProjectRequestViewModel, EditProjectCommand>();
        }
    }
}
