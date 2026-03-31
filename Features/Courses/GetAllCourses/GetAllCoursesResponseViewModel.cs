using AutoMapper;
using EasyTask.Features.Common.Courses.DTOs;
using EasyTask.Features.Common.Managements.DTOs;
using EasyTask.Models.Enums;

namespace EasyTask.Features.Courses.GetAllCourses
{
    public class GetAllCoursesResponseViewModel
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
    public class GetAllCoursesResponseProfile : Profile
    {
        public GetAllCoursesResponseProfile()
        {
            CreateMap<GetAllCoursesDTO, GetAllCoursesResponseViewModel>();
        }
    }
}
