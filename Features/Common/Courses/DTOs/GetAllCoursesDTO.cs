using AutoMapper;
using EasyTask.Features.Common.Managements.DTOs;
using EasyTask.Models.Courses;
using EasyTask.Models.Enums;

namespace EasyTask.Features.Common.Courses.DTOs
{
    public class GetAllCoursesDTO
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public int Hours { get; set; }
        public int NumOfCandidates { get; set; }
        public string InstructorName { get; set; }
        public CourseClassification CourseClassification { get; set; }
        public CourseStatus Status { get; set; }
        public bool HasExam { get; set; }
        public CourseType CourseType { get; set; }
        public List<ManagementIDAndNameDTO> AssignedManagements { get; set; }
    }
    public class GetAllCoursesDTOProfile : Profile
    {
        public GetAllCoursesDTOProfile()
        {
            CreateMap<Course, GetAllCoursesDTO>()
                .ForMember(dest => dest.NumOfCandidates,opt => opt.MapFrom(src => src.candidateCourses != null
                        ? src.candidateCourses.Count(cc => cc.Deleted == false) : 0 ));
        }
    }
}
