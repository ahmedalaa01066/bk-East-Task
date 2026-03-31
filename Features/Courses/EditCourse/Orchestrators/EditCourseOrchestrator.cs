using EasyTask.Common.Requests;
using EasyTask.Features.Courses.EditCourse.Command;
using EasyTask.Features.Documents.EditDocument.Commands;
using EasyTask.Features.Medias.SaveMedia.Commands;
using EasyTask.Helpers;
using EasyTask.Models.Courses;
using EasyTask.Models.Enums;

namespace EasyTask.Features.Courses.EditCourse.Orchestrators
{
    public record EditCourseOrchestrator(
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
         //List<string>? Paths
    ) : IRequestBase<bool>;
    public class EditCourseOrchestratorHandler : RequestHandlerBase<Course, EditCourseOrchestrator, bool>
    {
        public EditCourseOrchestratorHandler(RequestHandlerBaseParameters<Course> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(EditCourseOrchestrator request, CancellationToken cancellationToken)
        {
            var command = await _mediator.Send(request.MapOne<EditCourseCommand>());
            if (!command.IsSuccess)
            {
                return RequestResult<bool>.Failure(command.ErrorCode);
            }

            //if (request.Paths is { Count: > 0 } && request.Paths is not null )
            //{
            //    var saveMediaResult = await _mediator.Send(new SaveMediaCommand(
            //        SourceId: request.ID,
            //        SourceType: SourceType.CourseData,
            //        Paths: request.Paths
            //    ), cancellationToken);

            //    if (!saveMediaResult.IsSuccess)
            //    {
            //        return RequestResult<bool>.Failure(saveMediaResult.ErrorCode);
            //    }
            //}

            var EditDocument = await _mediator.Send(new EditDocumentCommand(request.Name, request.ID, DocumentType.Course));
            if (!EditDocument.IsSuccess)
                return RequestResult<bool>.Failure(EditDocument.ErrorCode);

            return RequestResult<bool>.Success(true);
        }
    }
}
