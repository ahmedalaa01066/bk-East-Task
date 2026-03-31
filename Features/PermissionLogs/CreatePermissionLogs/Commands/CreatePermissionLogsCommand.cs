using EasyTask.Common.Requests;
using EasyTask.Models.PermissionLogs;

namespace EasyTask.Features.PermissionLogs.CreatePermissionLogs.Commands
{
    public record CreatePermissionLogsCommand(string CandidateId) : IRequestBase<bool>;
    public class CreatePermissionLogsCommandHandler : RequestHandlerBase<PermissionLog, CreatePermissionLogsCommand, bool>
    {
        public CreatePermissionLogsCommandHandler(RequestHandlerBaseParameters<PermissionLog> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(CreatePermissionLogsCommand request, CancellationToken cancellationToken)
        {
            var permission = new PermissionLog
            {
                LeaveDate = DateTime.Now,
                CandidateId = request.CandidateId,
            };
            _repository.Add(permission);
            _repository.SaveChanges();
            return RequestResult<bool>.Success(true);
        }
    }
}
