using AutoMapper;
using EasyTask.Features.Common.Courses.DTOs;
using EasyTask.Features.Courses.GetCourseById;
using EasyTask.Models.Enums;

namespace EasyTask.Features.Courses.GetCourseById
{
    public record GetCourseByIdResponseViewModel
    (
        string Name,
        int Hours,
        string InstructorName,
        CourseClassification CourseClassification,
        CourseStatus Status,
        bool HasExam,
        CourseType CourseType,
        int CandidateNumber,
        List<string>? Paths,
        string Link,
        string Content
        );
}
public class GetCourseByIdResponseProfile : Profile
{
    public GetCourseByIdResponseProfile()
    {
        CreateMap<GetCourseByIdDTO, GetCourseByIdResponseViewModel>();
    }
}
