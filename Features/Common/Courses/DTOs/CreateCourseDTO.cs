using AutoMapper;
using EasyTask.Models.Courses;

namespace EasyTask.Features.Common.Courses.DTOs
{
    public record CreateCourseDTO(string ID, string? Path, string? DocumentId);
    public class CreateCourseDTOProfile : Profile
    {
        public CreateCourseDTOProfile()
        {
            CreateMap<Course, CreateCourseDTO>();
        }
    }
}
