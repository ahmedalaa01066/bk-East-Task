using AutoMapper;
using EasyTask.Features.Candidates.EditCandidateAttendanceActivation.Commands;
using EasyTask.Models.Enums;
using FluentValidation;

namespace EasyTask.Features.Candidates.EditCandidateAttendanceActivation
{
    public record EditCandidateAttendanceActivationRequestViewModel(string ID, AttendanceActivation AttendanceActivation);
    public class EditCandidateAttendanceActivationRequestValidator : AbstractValidator<EditCandidateAttendanceActivationRequestViewModel>
    {
        public EditCandidateAttendanceActivationRequestValidator()
        {
        }
    }
    public class EditCandidateAttendanceActivationRequestProfile : Profile
    {
        public EditCandidateAttendanceActivationRequestProfile()
        {
            CreateMap<EditCandidateAttendanceActivationRequestViewModel, EditCandidateAttendanceActivationCommand>();
        }
    }
}
