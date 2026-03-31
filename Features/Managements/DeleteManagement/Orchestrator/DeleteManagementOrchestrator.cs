using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Features.Departments.DeleteDepartment.Commands;
using EasyTask.Features.Managements.DeleteManagement.Commands;
using EasyTask.Helpers;
using EasyTask.Models.Managements;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Features.Managements.DeleteManagement.Orchestrator
{
    public record DeleteManagementOrchestrator(string ID):IRequestBase<bool>;
    public class DeleteManagementOrchestratorHandler : RequestHandlerBase<Management, DeleteManagementOrchestrator, bool>
    {
        public DeleteManagementOrchestratorHandler(RequestHandlerBaseParameters<Management> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(DeleteManagementOrchestrator request, CancellationToken cancellationToken)
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
                var deleteResult = await _mediator.Send(new DeleteDepartmentCommand(department.ID));
                if (!deleteResult.IsSuccess)
                {
                    return RequestResult<bool>.Failure(deleteResult.ErrorCode);
                }
            }

            var result = await _mediator.Send(request.MapOne<DeleteManagementCommand>());
            return result.IsSuccess
                ? RequestResult<bool>.Success()
                : RequestResult<bool>.Failure(result.ErrorCode);
        }
    }
}
