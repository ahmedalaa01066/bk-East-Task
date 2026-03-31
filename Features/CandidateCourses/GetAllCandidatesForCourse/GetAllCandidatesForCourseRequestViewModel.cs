using AutoMapper;
using EasyTask.Features.Common.CandidateCourses.Queries;
using FluentValidation;

namespace EasyTask.Features.CandidateCourses.GetAllCandidatesForCourse
{
    public record GetAllCandidatesForCourseRequestViewModel(string CourseId,
        int pageIndex = 1,
        int pageSize = 100);
    public class GetAllCandidatesForCourseRequestValidator : AbstractValidator<GetAllCandidatesForCourseRequestViewModel>
    {
        public GetAllCandidatesForCourseRequestValidator()
        {
        }
    }
    public class GetAllCandidatesForCourseRequestProfile : Profile
    {
        public GetAllCandidatesForCourseRequestProfile()
        {
            CreateMap<GetAllCandidatesForCourseRequestViewModel, GetAllCandidatesForCourseQuery>();
        }
    }
}
