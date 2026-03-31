using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Features.Common.Levels.DTOs;
using EasyTask.Helpers;
using EasyTask.Models.Levels;

namespace EasyTask.Features.Common.Levels.Queries
{
    public record GetLevelByIdQuery(string ID):IRequestBase<GetLevelByIdDTO>;
    public class GetLevelByIdQueryHandler : RequestHandlerBase<Level, GetLevelByIdQuery, GetLevelByIdDTO>
    {
        public GetLevelByIdQueryHandler(RequestHandlerBaseParameters<Level> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<GetLevelByIdDTO>> Handle(GetLevelByIdQuery request, CancellationToken cancellationToken)
        {
            var Level=_repository.GetByID(request.ID).MapOne<GetLevelByIdDTO>();
            if (Level == null) { 
                return RequestResult<GetLevelByIdDTO>.Failure(ErrorCode.NotFound);
            }
            return RequestResult<GetLevelByIdDTO>.Success(Level);

        }
    }
}
