using AutoMapper;
using EasyTask.Models.Courses;
using EasyTask.Models.Enums;

namespace EasyTask.Features.Common.Courses.DTOs
{
    public record GetCourseByIdDTO
    {
        public string Name { get; set; }
        public int Hours { get; set; }
        public string InstructorName { get; set; }
        public CourseClassification CourseClassification { get; set; }
        public CourseStatus Status { get; set; }
        public bool HasExam { get; set; }
        public CourseType CourseType { get; set; }
        public int CandidateNumber { get; set; } = 0;
        public List<string>? Paths { get; set; }
        public string Link { get; set; }
        public string Content { get; set; }
    }
    public class GetCourseByIdDTOProfile : Profile
    {
        public GetCourseByIdDTOProfile()
        {
            CreateMap<Course, GetCourseByIdDTO>();
        }
    }
}
