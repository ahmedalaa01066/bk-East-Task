using AutoMapper;
using EasyTask.Common.Views;

namespace EasyTask.Features.Courses.SelectCourseList
{
    public record SelectCourseListResponseViewModel(string ID, string Name);
    public class SelectCourseListResponseProfile : Profile
    {
        public SelectCourseListResponseProfile()
        {
            CreateMap<SelectListItemViewModel, SelectCourseListResponseViewModel>();
        }
    }
}
