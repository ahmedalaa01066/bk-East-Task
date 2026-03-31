using AutoMapper;
using EasyTask.Features.Common.Courses.Queries;
using FluentValidation;

namespace EasyTask.Features.Courses.GetAllCoursesByCandidateId
{
    public record GetAllCoursesByCandidateIdRequestViewModel(string CandidateId, int pageIndex = 1,
        int pageSize = 100);
    public class GetAllCoursesByCandidateIdRequestValidator : AbstractValidator<GetAllCoursesByCandidateIdRequestViewModel>
    {
        public GetAllCoursesByCandidateIdRequestValidator()
        {
        }
    }
    public class GetAllCoursesByCandidateIdRequestProfile : Profile
    {
        public GetAllCoursesByCandidateIdRequestProfile()
        {
            CreateMap<GetAllCoursesByCandidateIdRequestViewModel, GetAllCoursesByCandidateIdQuery>();
        }
    }
}
