using EasyTask.Common.Requests;
using EasyTask.Models.Courses;
using EasyTask.Models.Enums;

namespace EasyTask.Features.Courses.CreateCourse.Commands
{
    public record CreateCourseCommand(

        string Name, int Hours, string InstructorName,
        CourseClassification CourseClassification, CourseStatus Status,
        bool HasExam, CourseType CourseType, string Link, string Content
        ) : IRequestBase<string>;
    public class CreateCourseCommandHandler : RequestHandlerBase<Course, CreateCourseCommand, string>
    {
        public CreateCourseCommandHandler(RequestHandlerBaseParameters<Course> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<string>> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            Course course = new Course
            {
                Name = request.Name,
                Hours = request.Hours,
                InstructorName = request.InstructorName,
                CourseClassification = request.CourseClassification,
                Status = request.Status,
                HasExam = request.HasExam,
                CourseType = request.CourseType,
                Link = request.Link,
                Content = request.Content
            };
            _repository.Add(course);
            _repository.SaveChanges();
            return RequestResult<string>.Success(course.ID);
        }
    }
}
