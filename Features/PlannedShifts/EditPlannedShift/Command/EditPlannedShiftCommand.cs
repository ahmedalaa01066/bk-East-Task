using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Models.PlannedShifts;

namespace EasyTask.Features.PlannedShifts.EditPlannedShift.Command
{
    public record EditPlannedShiftCommand(
        string ID,
        DateTime? StartDate,
        DateTime? EndDate
        ) : IRequestBase<bool>;
    public class EditPlannedShiftCommandHandler : RequestHandlerBase<PlannedShift, EditPlannedShiftCommand, bool>
    {
        public EditPlannedShiftCommandHandler(RequestHandlerBaseParameters<PlannedShift> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(EditPlannedShiftCommand request, CancellationToken cancellationToken)
        {
            var plannedShift = _repository.GetByID(request.ID);
            if (plannedShift == null)
            {
                return RequestResult<bool>.Failure(ErrorCode.PlannedShiftNotFound);
            }
            plannedShift.StartDate = request.StartDate ?? plannedShift.StartDate;
            plannedShift.EndDate = request.EndDate ?? plannedShift.EndDate;
             
            _repository.SaveIncluded(plannedShift, nameof(plannedShift.StartDate),nameof(plannedShift.EndDate));
            _repository.SaveChanges();
            return RequestResult<bool>.Success(true);
        }
    }
}
