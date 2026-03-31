using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Features.Common.Vacations.DTOs;
using EasyTask.Helpers;
using EasyTask.Models.Vacations;

namespace EasyTask.Features.Common.Vacations.Queries
{
    public record GetVacationByIdQuery(string ID):IRequestBase<GetVacationByIdDTO>;
    public class GetVacationByIdQueryHandler : RequestHandlerBase<Vacation, GetVacationByIdQuery, GetVacationByIdDTO>
    {
        public GetVacationByIdQueryHandler(RequestHandlerBaseParameters<Vacation> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<GetVacationByIdDTO>> Handle(GetVacationByIdQuery request, CancellationToken cancellationToken)
        {
            var vacation = _repository.GetByID(request.ID);
            if (vacation == null)
            {
                return RequestResult<GetVacationByIdDTO>.Failure(ErrorCode.ShiftNotFound);
            }
            var vacationDTO = vacation.MapOne<GetVacationByIdDTO>();
            return RequestResult<GetVacationByIdDTO>.Success(vacationDTO);
        }
    }
}
