using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Features.Common.PermissionRequests.DTOs;
using EasyTask.Helpers;
using EasyTask.Models.PermissionRequests;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Features.Common.PermissionRequests.Queries
{
    public record GetPermissionRequestByIdQuery(string ID):IRequestBase<GetPermissionRequestByIdDTO>;
    public class GetPermissionRequestByIdQueryHandler : RequestHandlerBase<PermissionRequest, GetPermissionRequestByIdQuery, GetPermissionRequestByIdDTO>
    {
        public GetPermissionRequestByIdQueryHandler(RequestHandlerBaseParameters<PermissionRequest> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<GetPermissionRequestByIdDTO>> Handle(GetPermissionRequestByIdQuery request, CancellationToken cancellationToken)
        {
            var PermissionRequest = _repository.Get(c=>c.ID==request.ID).Include(c => c.Candidate).Include(c => c.Permission).FirstOrDefault();
            if (PermissionRequest == null)
            {
                return RequestResult<GetPermissionRequestByIdDTO>.Failure(ErrorCode.NotFound);
            }
            var PermissionRequestDTO = PermissionRequest.MapOne<GetPermissionRequestByIdDTO>();
            return RequestResult<GetPermissionRequestByIdDTO>.Success(PermissionRequestDTO);
        }
    }
}
