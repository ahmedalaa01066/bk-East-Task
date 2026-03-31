using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Features.Common.PlannedShifts.DTOs;
using EasyTask.Models.PlannedShifts;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EasyTask.Features.Common.PlannedShifts.Queries
{
    public record GetNowShiftByCandidateIdQuery(string CandidateId) : IRequestBase<string>;
    public class GetNowShiftByCandidateIdQueryHandler : RequestHandlerBase<PlannedShift, GetNowShiftByCandidateIdQuery, string>
    {
        public GetNowShiftByCandidateIdQueryHandler(RequestHandlerBaseParameters<PlannedShift> requestParameters) : base(requestParameters)
        {
        }

        public override async Task<RequestResult<string>> Handle(GetNowShiftByCandidateIdQuery request, CancellationToken cancellationToken)
        {
            var today = DateTime.Now;
            var model = await _repository.Get(ps => ps.CandidateId == request.CandidateId &&
            ps.StartDate <= today && ps.EndDate >= today &&
            ps.Shift.FromTime <= today.TimeOfDay && ps.Shift.ToTime >= today.TimeOfDay)
                .Include(ps => ps.Shift)
                .FirstOrDefaultAsync();

            if (model == null)
                return RequestResult<string>.Failure(ErrorCode.ShiftNotFoundForRightNow);

            return RequestResult<string>.Success(model.ID);
        }
    }
}
