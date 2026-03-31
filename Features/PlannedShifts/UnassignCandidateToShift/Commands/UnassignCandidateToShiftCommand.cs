using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Models.PlannedShifts;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Features.PlannedShifts.UnassignCandidateToShift.Commands
{
    public record UnassignCandidateToShiftCommand(string CandidateId,string ShiftId):IRequestBase<bool>;
    public class UnassignCandidateToShiftCommandHandler : RequestHandlerBase<PlannedShift, UnassignCandidateToShiftCommand, bool>
    {
        public UnassignCandidateToShiftCommandHandler(RequestHandlerBaseParameters<PlannedShift> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(UnassignCandidateToShiftCommand request, CancellationToken cancellationToken)
        {
            var plannedShiftID = await _repository.Get(c => c.CandidateId == request.CandidateId && c.ShiftId == request.ShiftId).FirstOrDefaultAsync();
            if (plannedShiftID is not null)
            {
                _repository.Delete(plannedShiftID);
                _repository.SaveChanges();
                return RequestResult<bool>.Success(true);

            }
            return RequestResult<bool>.Failure(ErrorCode.NotFound);
        }
    }
}
