using AutoMapper;
using EasyTask.Features.Common.Courses.DTOs;

namespace EasyTask.Features.Courses.CreateCourse
{
    public record CreateCourseResponseViewModel(string ID, string? Path, string? DocumentId);
    public class CreateCourseResponseProfile : Profile
    {
        public CreateCourseResponseProfile()
        {
            CreateMap<CreateCourseDTO, CreateCourseResponseViewModel>();
        }
    }
}
