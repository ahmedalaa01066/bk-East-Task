using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Features.Departments.DeactiveDepartment.Commands;
using EasyTask.Features.Managements.DeactiveManagement.Commands;
using EasyTask.Helpers;
using EasyTask.Models.Managements;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Features.Managements.DeactiveManagement.Orchestrator
{
    public record DeactiveManagementOrchestrator(string ID):IRequestBase<bool>;
    public class DeactiveManagementOrchestratorHandler : RequestHandlerBase<Management, DeactiveManagementOrchestrator, bool>
    {
        public DeactiveManagementOrchestratorHandler(RequestHandlerBaseParameters<Management> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(DeactiveManagementOrchestrator request, CancellationToken cancellationToken)
        {
            var management = _repository.Get((m => m.ID == request.ID))
                           .Include(m => m.Departments)
                           .FirstOrDefault();

            if (management == null)
            {
                return RequestResult<bool>.Failure(ErrorCode.NotFound);
            }

            foreach (var department in management.Departments.ToList())
            {
                var deleteResult = await _mediator.Send(new DeactiveDepartmentCommand(department.ID));
                if (!deleteResult.IsSuccess)
                {
                    return RequestResult<bool>.Failure(deleteResult.ErrorCode);
                }
            }

            var result = await _mediator.Send(request.MapOne<DeactiveManagementCommand>());
            return result.IsSuccess
                ? RequestResult<bool>.Success()
                : RequestResult<bool>.Failure(result.ErrorCode);
        }
    }
}
