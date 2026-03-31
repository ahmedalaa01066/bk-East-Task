using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Models.Managements;
using EasyTask.Features.Managements.DeleteManagement.Orchestrator;

namespace EasyTask.Features.Managements.BulkDeleteManagement.Orchisterator
{
    public record BulkDeleteManagementOrchisterator(List<string> Ids) : IRequestBase<bool>;

    public class BulkDeleteManagementOrchisteratorHandler : RequestHandlerBase<Management, BulkDeleteManagementOrchisterator, bool>
    {
        public BulkDeleteManagementOrchisteratorHandler(RequestHandlerBaseParameters<Management> requestParameters) : base(requestParameters) { }

        public async override Task<RequestResult<bool>> Handle(BulkDeleteManagementOrchisterator request, CancellationToken cancellationToken)
        {
            foreach (var id in request.Ids)
            {
                var result = await _mediator.Send(new DeleteManagementOrchestrator(id));
                if (!result.IsSuccess)
                {
                    return RequestResult<bool>.Failure(result.ErrorCode);
                }
            }
            return RequestResult<bool>.Success(true);

        }
    }
}
