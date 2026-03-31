using EasyTask.Common.Requests;
using EasyTask.Common.Views;
using EasyTask.Models.Courses;

namespace EasyTask.Features.Common.Courses.Queries
{
    public record SelectCourseListQuery() : IRequestBase<IEnumerable<SelectListItemViewModel>>;
    public class SelectCourseListQueryHandler : RequestHandlerBase<Course, SelectCourseListQuery, IEnumerable<SelectListItemViewModel>>
    {
        public SelectCourseListQueryHandler(RequestHandlerBaseParameters<Course> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<IEnumerable<SelectListItemViewModel>>> Handle(SelectCourseListQuery request, CancellationToken cancellationToken)
        {
            var selectListItems = _repository.Get().ToSelectListViewModel();
            return RequestResult<IEnumerable<SelectListItemViewModel>>.Success(selectListItems);
        }
    }
}
