using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Features.Common.Permissions.DTOs;
using EasyTask.Helpers;
using EasyTask.Models.Permissions;

namespace EasyTask.Features.Common.Permissions.Queries
{
    public record GetPermissionByIdQuery(string ID):IRequestBase<GetPermissionByIdDTO>;
    public class GetPermissionByIdQueryHandler : RequestHandlerBase<Permission, GetPermissionByIdQuery, GetPermissionByIdDTO>
    {
        public GetPermissionByIdQueryHandler(RequestHandlerBaseParameters<Permission> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<GetPermissionByIdDTO>> Handle(GetPermissionByIdQuery request, CancellationToken cancellationToken)
        {
            var Permission = _repository.GetByID(request.ID);
            if (Permission == null)
            {
                return RequestResult<GetPermissionByIdDTO>.Failure(ErrorCode.NotFound);
            }
            var PermissionDTO = Permission.MapOne<GetPermissionByIdDTO>();
            return RequestResult<GetPermissionByIdDTO>.Success(PermissionDTO);
        }
    }
}
