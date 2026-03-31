using EasyTask.Common.Requests;
using EasyTask.Models.PermissionLogs;

namespace EasyTask.Features.PermissionLogs.CreateFullPermissionLogs.Commands
{
    public record CreateFullPermissionLogsCommand(string CandidateId, DateTime LeaveDate) : IRequestBase<bool>;
    public class CreateFullPermissionLogsCommandHandler : RequestHandlerBase<PermissionLog, CreateFullPermissionLogsCommand, bool>
    {
        public CreateFullPermissionLogsCommandHandler(RequestHandlerBaseParameters<PermissionLog> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(CreateFullPermissionLogsCommand request, CancellationToken cancellationToken)
        {
            var permission = new PermissionLog
            {
                LeaveDate = request.LeaveDate,
                ComeBackDate = DateTime.Now,
                CandidateId = request.CandidateId,
            };
            _repository.Add(permission);
            _repository.SaveChanges();
            return RequestResult<bool>.Success(true);
        }
    }
}
