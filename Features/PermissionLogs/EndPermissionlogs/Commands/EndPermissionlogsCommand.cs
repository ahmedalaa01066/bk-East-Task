using EasyTask.Common.Requests;
using EasyTask.Models.PermissionLogs;

namespace EasyTask.Features.PermissionLogs.EndPermissionlogs.Commands
{
    public record EndPermissionlogsCommand(string ID) : IRequestBase<bool>;
    public class EndPermissionlogsCommandHandler : RequestHandlerBase<PermissionLog, EndPermissionlogsCommand, bool>
    {
        public EndPermissionlogsCommandHandler(RequestHandlerBaseParameters<PermissionLog> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(EndPermissionlogsCommand request, CancellationToken cancellationToken)
        {
            var PermissionLog = new PermissionLog
            {
                ID = request.ID,
                ComeBackDate = DateTime.Now,
            };

            _repository.SaveIncluded(PermissionLog, nameof(PermissionLog.ComeBackDate));
            _repository.SaveChanges();
            return RequestResult<bool>.Success(true);
        }
    }
}
