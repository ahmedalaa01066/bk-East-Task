using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Models.Courses;
using EasyTask.Models.Enums;

namespace EasyTask.Features.Courses.EditCourse.Command
{
    public record EditCourseCommand(
        string ID,
        string Name,
        int Hours,
        string InstructorName,
        CourseClassification CourseClassification,
        CourseStatus Status,
        bool HasExam,
        CourseType CourseType,
        string Link,
        string Content
    ) : IRequestBase<bool>;
    public class EditCourseCommandHandler : RequestHandlerBase<Course, EditCourseCommand, bool>
    {
        public EditCourseCommandHandler(RequestHandlerBaseParameters<Course> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(EditCourseCommand request, CancellationToken cancellationToken)
        {
            var Course = await _repository.GetByIDAsync(request.ID);

            if (Course == null)
                return RequestResult<bool>.Failure(ErrorCode.CourseNotFound);

            Course.Name = request.Name;
            Course.Status = request.Status;
            Course.HasExam = request.HasExam;
            Course.CourseClassification = request.CourseClassification;
            Course.InstructorName = request.InstructorName;
            Course.Hours = request.Hours;
            Course.CourseType = request.CourseType;
            Course.Link = request.Link;
            Course.Content = request.Content;
            _repository.SaveIncluded(Course, nameof(Course.Name), nameof(Course.Status), nameof(Course.HasExam)
                , nameof(Course.CourseClassification), nameof(Course.InstructorName), nameof(Course.Hours),
                nameof(Course.CourseType), nameof(Course.Link), nameof(Course.Content));

            _repository.SaveChanges();

            return RequestResult<bool>.Success(true);
        }
    }
}
