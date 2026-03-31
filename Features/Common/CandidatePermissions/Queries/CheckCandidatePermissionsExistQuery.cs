using EasyTask.Common.Requests;
using EasyTask.Features.Common.CandidatePermissions.DTOs;
using EasyTask.Helpers;
using EasyTask.Models.CandidatePermissions;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Features.Common.CandidatePermissions.Queries
{
    public record CheckCandidatePermissionsExistQuery(
        string CandidateId,
        string PermissionId, 
        DateTime PermissionMonth
    ) : IRequestBase<CandidatePermissionDTO>;
    public class CheckCandidatePermissionsExistQueryHandler : RequestHandlerBase<CandidatePermission, CheckCandidatePermissionsExistQuery, CandidatePermissionDTO>
    {
        public CheckCandidatePermissionsExistQueryHandler(RequestHandlerBaseParameters<CandidatePermission> requestParameters) : base(requestParameters)
        {
        }

        public override async Task<RequestResult<CandidatePermissionDTO>> Handle(CheckCandidatePermissionsExistQuery request, CancellationToken cancellationToken)
        {
            var candidatePermission = await _repository.Get(
                cp => cp.CandidateId == request.CandidateId && 
                cp.PermissionId == request.PermissionId &&
                cp.PermissionMonth.Month == request.PermissionMonth.Month &&
                cp.PermissionMonth.Year == request.PermissionMonth.Year)
                .FirstOrDefaultAsync();
            var dto = candidatePermission.MapOne<CandidatePermissionDTO>();
            return RequestResult<CandidatePermissionDTO>.Success(dto);
        }
    }
}
