using EasyTask.Common.Requests;
using EasyTask.Features.Users.ActivateUser.Commands;
using EasyTask.Models.Users;

namespace EasyTask.Features.Users.BulkActivateUser.Orchestrator
{
    public record BulkActivateUserOrchestrator (List<string> IDs) : IRequestBase<bool>;
    public class BulkActivateUserOrchestratorHandler : RequestHandlerBase<User, BulkActivateUserOrchestrator, bool>
    {
        public BulkActivateUserOrchestratorHandler(RequestHandlerBaseParameters<User> requestParameters) : base(requestParameters)
        {
        }
        public override async Task<RequestResult<bool>> Handle(BulkActivateUserOrchestrator request, CancellationToken cancellationToken)
        {
            foreach (var ID in request.IDs)
            {
                var check = await _mediator.Send(new ActivateUserCommand(ID));
                if (!check.IsSuccess)
                {
                    return RequestResult<bool>.Failure(check.ErrorCode);
                }
            }

            return RequestResult<bool>.Success(true);
        }
    }
}
