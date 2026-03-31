using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Models.Courses;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Features.Courses.DeleteCourse.Commands
{
    public record DeleteCourseCommand(string ID):IRequestBase<bool>;
    public class DeleteCourseCommandHandler : RequestHandlerBase<Course, DeleteCourseCommand, bool>
    {
        public DeleteCourseCommandHandler(RequestHandlerBaseParameters<Course> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            var course = await _repository
                .Get()
                .Include(c => c.candidateCourses)
                .FirstOrDefaultAsync(c => c.ID == request.ID);

            if (course == null)
                return RequestResult<bool>.Failure(ErrorCode.NotFound);

            if (course.candidateCourses != null && course.candidateCourses.Any(cc => cc.Deleted == false))
                return RequestResult<bool>.Failure(ErrorCode.CannotDelete, "Course has enrolled candidates");

            _repository.Delete(request.ID);
            _repository.SaveChanges();
            return await Task.FromResult(RequestResult<bool>.Success(true));
        }
    }
}
