using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Features.Common.SpecialDays.DTOs;
using EasyTask.Helpers;
using EasyTask.Models.SpecialDays;

namespace EasyTask.Features.Common.SpecialDays.Queries
{
    public record GetSpecialDayByIdQuery(string ID) : IRequestBase<GetSpecialDayByIdDTO>;
    public class GetSpecialDayByIdQueryHandler : RequestHandlerBase<SpecialDay, GetSpecialDayByIdQuery, GetSpecialDayByIdDTO>
    {
        public GetSpecialDayByIdQueryHandler(RequestHandlerBaseParameters<SpecialDay> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<GetSpecialDayByIdDTO>> Handle(GetSpecialDayByIdQuery request, CancellationToken cancellationToken)
        {
            var specialDay = _repository.GetByID(request.ID);
            if (specialDay == null)
            {
                return RequestResult<GetSpecialDayByIdDTO>.Failure(ErrorCode.NotFound);
            }
            var specialDayByIdDTO = specialDay.MapOne<GetSpecialDayByIdDTO>();
            return RequestResult<GetSpecialDayByIdDTO>.Success(specialDayByIdDTO);
        }
    }
}
