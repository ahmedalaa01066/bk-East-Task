using EasyTask.Common.Requests;
using EasyTask.Features.Common.Courses.DTOs;
using EasyTask.Features.Courses.CreateCourse.Commands;
using EasyTask.Features.Documents.AddDocument.Commands;
using EasyTask.Helpers;
using EasyTask.Models.Courses;
using EasyTask.Models.Enums;

namespace EasyTask.Features.Courses.CreateCourse.Orchestrators
{
    public record CreateCourseOrchestrator(
        string Name, int Hours, string InstructorName,
        CourseClassification CourseClassification, CourseStatus Status,
        bool HasExam, CourseType CourseType, string Link, string Content
        ) : IRequestBase<CreateCourseDTO>;
    public class CreateCourseOrchestratorHandler : RequestHandlerBase<Course, CreateCourseOrchestrator, CreateCourseDTO>
    {
        public CreateCourseOrchestratorHandler(RequestHandlerBaseParameters<Course> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<CreateCourseDTO>> Handle(CreateCourseOrchestrator request, CancellationToken cancellationToken)
        {
            var courseResult = await _mediator.Send(request.MapOne<CreateCourseCommand>());
            if (!courseResult.IsSuccess)
            {
                return RequestResult<CreateCourseDTO>.Failure(courseResult.ErrorCode);
            }

            var createFolderCommand = new AddDocumentCommand(
                PhysicalName: request.Name,
                SourceId: courseResult.Data,
                SourceType: DocumentType.Course,
                Path: "Courses",
                ParentDocumentId: null
            );

            var documentResult = await _mediator.Send(createFolderCommand);

            if (!documentResult.IsSuccess)
                return RequestResult<CreateCourseDTO>.Failure(documentResult.ErrorCode);

            //if (request.Paths is { Count: > 0 })
            //{
            //    var saveMediaResult = await _mediator.Send(new SaveMediaCommand(
            //        SourceId: courseResult.Data,
            //        SourceType: SourceType.CourseData,
            //        Paths: request.Paths
            //    ), cancellationToken);

            //    if (!saveMediaResult.IsSuccess)
            //    {
            //        return RequestResult<string>.Failure(saveMediaResult.ErrorCode);
            //    }
            //}
            var result = new CreateCourseDTO(courseResult.Data, documentResult.Data.Path,documentResult.Data.ID);
            return RequestResult<CreateCourseDTO>.Success(result);
        }
    }


}
