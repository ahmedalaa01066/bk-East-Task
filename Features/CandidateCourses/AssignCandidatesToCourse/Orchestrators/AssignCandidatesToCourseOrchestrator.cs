using EasyTask.Common.Requests;
using EasyTask.Features.CandidateCourses.CreateCandidateCourse.Commands;
using EasyTask.Features.CandidateCourses.UnassignCandidateCourse.Command;
using EasyTask.Features.Common.Courses.DTOs;
using EasyTask.Features.Courses.CreateCourse.Orchestrators;
using EasyTask.Helpers;
using EasyTask.Models.CandidateCourses;
using EasyTask.Models.Enums;

namespace EasyTask.Features.CandidateCourses.AssignCandidatesToCourse.Orchestrators
{
    public record AssignCandidatesToCourseOrchestrator(List<string> CandidateIds, string? CourseId, DateOnly StartDate, DateOnly EndDate,
        string? Name, int? Hours, string? InstructorName,
        CourseClassification? CourseClassification, CourseStatus? Status,
        bool? HasExam, CourseType? CourseType, string? Link, string? Content) : IRequestBase<CreateCourseDTO>;
    public class AssignCandidatesToCourseOrchestratorHandler : RequestHandlerBase<CandidateCourse, AssignCandidatesToCourseOrchestrator, CreateCourseDTO>
    {
        public AssignCandidatesToCourseOrchestratorHandler(RequestHandlerBaseParameters<CandidateCourse> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<CreateCourseDTO>> Handle(AssignCandidatesToCourseOrchestrator request, CancellationToken cancellationToken)
        {
            string courseId = request.CourseId;
            CreateCourseDTO createCourseDTO = null;
            if (request.CourseId == null)
            {
                var course = await _mediator.Send(request.MapOne<CreateCourseOrchestrator>());
                if (!course.IsSuccess)
                    return RequestResult<CreateCourseDTO>.Failure(course.ErrorCode);
                createCourseDTO = course.Data;
                courseId = course.Data.ID;
                var DirectAssign = await _mediator.Send(new AssignCandidatesToCourseCommand(request.CandidateIds, courseId, request.StartDate, request.EndDate));
                if (!DirectAssign.IsSuccess)
                    return RequestResult<CreateCourseDTO>.Failure(DirectAssign.ErrorCode);
            }
            else
            {
                var existingAssignments = _repository
                    .Get(cc => cc.CourseId == courseId)
                    .ToList();

                var existingIds = existingAssignments.Select(cc => cc.CandidateId).ToHashSet();
                var inputIds = request.CandidateIds.ToHashSet();
                var newCandidateIds = inputIds.Except(existingIds).ToList();

                var toRemove = existingAssignments
                    .Where(cc => !inputIds.Contains(cc.CandidateId))
                    .ToList();

                foreach (var candidate in toRemove)
                {
                    var unassignResult = await _mediator.Send(new UnassignCandidateCourseCommand(candidate.CourseId, candidate.CandidateId), cancellationToken);
                    if (!unassignResult.IsSuccess)
                        return RequestResult<CreateCourseDTO>.Failure(unassignResult.ErrorCode);
                }

                if (newCandidateIds.Any())
                {
                    var assignResult = await _mediator.Send(new AssignCandidatesToCourseCommand(
                        newCandidateIds, courseId, request.StartDate, request.EndDate));

                    if (!assignResult.IsSuccess)
                        return RequestResult<CreateCourseDTO>.Failure(assignResult.ErrorCode);
                }

            }
            return RequestResult<CreateCourseDTO>.Success(createCourseDTO);

        }
    }
}
