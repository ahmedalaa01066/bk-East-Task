using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Models.CandidateCourses;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Features.CandidateCourses.SetActualStartDate.Commands
{
    public record SetActualStartDateCommand(string CandidateId, string CourseId, DateOnly ActualStartDate) : IRequestBase<bool>;
    public class SetActualStartDateCommandHandler : RequestHandlerBase<CandidateCourse, SetActualStartDateCommand, bool>
    {
        public SetActualStartDateCommandHandler(RequestHandlerBaseParameters<CandidateCourse> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(SetActualStartDateCommand request, CancellationToken cancellationToken)
        {
            var Course = await _repository.Get(c => c.CourseId == request.CourseId && c.CandidateId == request.CandidateId).FirstOrDefaultAsync();

            if (Course == null)
                return RequestResult<bool>.Failure(ErrorCode.CourseNotFound);

            Course.ActualStartDate = request.ActualStartDate;
            _repository.SaveIncluded(Course, nameof(Course.ActualStartDate));

            _repository.SaveChanges();

            return RequestResult<bool>.Success(true);
        }
    }
}
