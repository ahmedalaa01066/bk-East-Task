using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Features.Common.Shifts.DTOs;
using EasyTask.Helpers;
using EasyTask.Models.Shifts;

namespace EasyTask.Features.Common.Shifts.Queries
{
    public record GetShiftByIDQuery(string ID) : IRequestBase<GetShiftByIdDTO>;
    public class GetShiftByIDQueryHandler : RequestHandlerBase<Shift, GetShiftByIDQuery, GetShiftByIdDTO>
    {
        public GetShiftByIDQueryHandler(RequestHandlerBaseParameters<Shift> requestParameters) : base(requestParameters)
        {
        }
        public override async Task<RequestResult<GetShiftByIdDTO>> Handle(GetShiftByIDQuery request, CancellationToken cancellationToken)
        {
            var shift = _repository.GetByID(request.ID);
            if (shift == null)
            {
                return RequestResult<GetShiftByIdDTO>.Failure(ErrorCode.ShiftNotFound);
            }
            var shiftDTO = shift.MapOne<GetShiftByIdDTO>();
            return RequestResult<GetShiftByIdDTO>.Success(shiftDTO);
        }
    }
}
