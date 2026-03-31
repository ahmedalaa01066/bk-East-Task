using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Models.PermissionLogs;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace EasyTask.Features.Common.PermissionLogs.Queries
{
    public record GerPermissionLogsIDQuery(string CandidateId) : IRequestBase<string>;
    public class GerPermissionLogsIDQueryHandler : RequestHandlerBase<PermissionLog, GerPermissionLogsIDQuery, string>
    {
        public GerPermissionLogsIDQueryHandler(RequestHandlerBaseParameters<PermissionLog> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<string>> Handle(GerPermissionLogsIDQuery request, CancellationToken cancellationToken)
        {
            string ID = (await _repository.Get(p => p.CandidateId == request.CandidateId && p.LeaveDate.Date == DateTime.Now.Date).FirstOrDefaultAsync()).ID;
            if (ID.IsNullOrEmpty())
                return RequestResult<string>.Failure(ErrorCode.NotFound);
            return RequestResult<string>.Success(ID);
        }
    }
}
