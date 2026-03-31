using AutoMapper;
using EasyTask.Features.Common.Attendances.Queries;
using FluentValidation;

namespace EasyTask.Features.Attendances.GetAttendanceCircle
{
    public record GetAttendanceCircleRequestViewModel( string CandidateId);
    public class GetAttendanceCircleRequestValidator : AbstractValidator<GetAttendanceCircleRequestViewModel>
    {
        public GetAttendanceCircleRequestValidator()
        {
        }
    }
    public class GetAttendanceCircleRequestProfile : Profile
    {
        public GetAttendanceCircleRequestProfile()
        {
            CreateMap<GetAttendanceCircleRequestViewModel, GetAttendanceCircleQuery>();
        }
    }
}
