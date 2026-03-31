using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Features.Departments.ActiveDepartment.Commands;
using EasyTask.Features.Managements.ActiveManagement.Commands;
using EasyTask.Helpers;
using EasyTask.Models.Managements;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Features.Managements.ActiveManagement.Orchestrator
{
    public record ActiveManagementOrchestrator(string ID):IRequestBase<bool>;
    public class ActiveManagementOrchestratorHandler : RequestHandlerBase<Management, ActiveManagementOrchestrator, bool>
    {
        public ActiveManagementOrchestratorHandler(RequestHandlerBaseParameters<Management> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(ActiveManagementOrchestrator request, CancellationToken cancellationToken)
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
                var deleteResult = await _mediator.Send(new ActiveDepartmentCommand(department.ID));
                if (!deleteResult.IsSuccess)
                {
                    return RequestResult<bool>.Failure(deleteResult.ErrorCode);
                }
            }

            var result = await _mediator.Send(request.MapOne<ActiveManagementCommand>());
            return result.IsSuccess
                ? RequestResult<bool>.Success()
                : RequestResult<bool>.Failure(result.ErrorCode);
        }
    }
}
