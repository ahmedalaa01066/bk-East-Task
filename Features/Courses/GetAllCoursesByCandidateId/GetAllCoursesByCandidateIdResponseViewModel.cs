
using AutoMapper;
using EasyTask.Features.Common.Courses.DTOs;
using EasyTask.Models.Enums;

namespace EasyTask.Features.Courses.GetAllCoursesByCandidateId
{
    public class GetAllCoursesByCandidateIdResponseViewModel
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public int Hours { get; set; }
        public string InstructorName { get; set; }
        public CourseClassification CourseClassification { get; set; }
        public CourseStatus Status { get; set; }
        public bool HasExam { get; set; }
        public CourseType CourseType { get; set; }
        public string Link { get; set; }
        public string Content { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public string? DocumentId { get; set; }
        public DateOnly? ActualStartDate { get; set; }
    }
    public class GetAllCoursesByCandidateIdResponseProfile : Profile
    {
        public GetAllCoursesByCandidateIdResponseProfile()
        {
            CreateMap<GetAllCoursesByCandidateIdDTO, GetAllCoursesByCandidateIdResponseViewModel>();
        }
    }
}
