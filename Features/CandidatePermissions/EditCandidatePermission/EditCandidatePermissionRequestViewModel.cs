using AutoMapper;
using EasyTask.Features.CandidatePermissions.CreateCandidatePermission.Commands;
using FluentValidation;

namespace EasyTask.Features.CandidatePermissions.EditCandidatePermission
{
    public record EditCandidatePermissionRequestViewModel(
        string ID,
        TimeSpan HoursLeftInMonth,
        TimeSpan? NumOfHoursOfPermission = null
    );
    public class EditCandidatePermissionRequestValidator : AbstractValidator<EditCandidatePermissionRequestViewModel>
    {
        public EditCandidatePermissionRequestValidator()
        {
        }
    }
    public class EditCandidatePermissionRequestProfile : Profile
    {
        public EditCandidatePermissionRequestProfile()
        {
            CreateMap<EditCandidatePermissionRequestViewModel, EditEditCandidatePermissionCommand>();
        }
    }
}
