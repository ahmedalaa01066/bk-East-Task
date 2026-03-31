using AutoMapper;
using EasyTask.Features.Common.Candidates.Queries;
using FluentValidation;

namespace EasyTask.Features.Candidates.GetCandidateAttendanceActivation
{
    public record GetCandidateAttendanceActivationRequestViewModel(string? ID);
    public class GetCandidateAttendanceActivationRequestValidator : AbstractValidator<GetCandidateAttendanceActivationRequestViewModel>
    {
        public GetCandidateAttendanceActivationRequestValidator()
        {
        }
    }
    public class GetCandidateAttendanceActivationRequestProfile : Profile
    {
        public GetCandidateAttendanceActivationRequestProfile()
        {
            CreateMap<GetCandidateAttendanceActivationRequestViewModel, GetCandidateAttendanceActivationQuery>();
        }
    }
}
