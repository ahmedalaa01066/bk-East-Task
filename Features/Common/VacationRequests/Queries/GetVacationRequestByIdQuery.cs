using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Features.Common.VacationRequests.DTOs;
using EasyTask.Helpers;
using EasyTask.Models.VacationRequests;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Features.Common.VacationRequests.Queries
{
    public record GetVacationRequestByIdQuery(string ID):IRequestBase<GetVacationRequestByIdDTO>;
    public class GetVacationRequestByIdQueryHandler : RequestHandlerBase<VacationRequest, GetVacationRequestByIdQuery, GetVacationRequestByIdDTO>
    {
        public GetVacationRequestByIdQueryHandler(RequestHandlerBaseParameters<VacationRequest> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<GetVacationRequestByIdDTO>> Handle(GetVacationRequestByIdQuery request, CancellationToken cancellationToken)
        {
            var VacationRequest = _repository.Get(c=>c.ID==request.ID).Include(c=>c.Vacation).Include(c=>c.Candidate).FirstOrDefault();
            if (VacationRequest == null)
            {
                return RequestResult<GetVacationRequestByIdDTO>.Failure(ErrorCode.NotFound);
            }
            var VacationRequestDTO = VacationRequest.MapOne<GetVacationRequestByIdDTO>();
            return RequestResult<GetVacationRequestByIdDTO>.Success(VacationRequestDTO);
        }
    }
}
