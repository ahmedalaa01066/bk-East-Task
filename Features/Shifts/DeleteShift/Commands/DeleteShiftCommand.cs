using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Models.Shifts;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Features.Shifts.DeleteShift.Commands
{
    public record DeleteShiftCommand(string ID):IRequestBase<bool>;
    public class DeleteShiftCommandHandler : RequestHandlerBase<Shift, DeleteShiftCommand, bool>
    {
        public DeleteShiftCommandHandler(RequestHandlerBaseParameters<Shift> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(DeleteShiftCommand request, CancellationToken cancellationToken)
        {
            var shift = await _repository
                  .Get(s => s.ID == request.ID)
                  .Include(s => s.PlannedShifts) 
                  .FirstOrDefaultAsync();

            if (shift == null)
                return RequestResult<bool>.Failure(ErrorCode.NotFound);

            if (shift.PlannedShifts != null && shift.PlannedShifts.Any())
                return RequestResult<bool>.Failure(ErrorCode.CannotDelete); 

            _repository.Delete(shift);
             _repository.SaveChanges();

            return RequestResult<bool>.Success(true);
        }
    }
}
