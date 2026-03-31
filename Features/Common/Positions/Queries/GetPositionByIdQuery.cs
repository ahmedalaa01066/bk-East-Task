using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Features.Common.Positions.DTOs;
using EasyTask.Helpers;
using EasyTask.Models.Positions;

namespace EasyTask.Features.Common.Positions.Queries
{
    public record GetPositionByIdQuery(string ID):IRequestBase<GetPositionByIdDTO>;
    public class GetPositionByIdQueryHandler : RequestHandlerBase<Position, GetPositionByIdQuery, GetPositionByIdDTO>
    {
        public GetPositionByIdQueryHandler(RequestHandlerBaseParameters<Position> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<GetPositionByIdDTO>> Handle(GetPositionByIdQuery request, CancellationToken cancellationToken)
        {
            var Position=_repository.GetByID(request.ID).MapOne<GetPositionByIdDTO>();
            if (Position == null) { 
                return RequestResult<GetPositionByIdDTO>.Failure(ErrorCode.NotFound);
            }
            return RequestResult<GetPositionByIdDTO>.Success(Position);

        }
    }
}
