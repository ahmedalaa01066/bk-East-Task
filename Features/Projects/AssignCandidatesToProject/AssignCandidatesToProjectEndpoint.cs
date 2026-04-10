using EasyTask.Common.Endpoints;
using EasyTask.Helpers;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Projects.AssignCandidatesToProject;

public class AssignCandidatesToProjectEndpoint(
    EndpointBaseParameters<AssignCandidatesToProjectRequestVm> dependencyCollection)
    : EndpointBase<AssignCandidatesToProjectRequestVm, AssignCandidatesToProjectResponseVm>(dependencyCollection)
{
    [HttpPost]
    public async Task<EndPointResponse<AssignCandidatesToProjectResponseVm>> AssignCandidatesToProject(AssignCandidatesToProjectRequestVm vm)
    {
        var validationResult = await ValidateRequestAsync(vm);
        if (!validationResult.IsSuccess)
            return validationResult;

        var result = await _mediator.Send(vm.MapOne<AssignCandidatesToProjectOrchestrator>());

        if (result.IsSuccess)
        {
            return EndPointResponse<AssignCandidatesToProjectResponseVm>.Success(result.Data, result.Message);
        }

        return EndPointResponse<AssignCandidatesToProjectResponseVm>.Failure(result.ErrorCode);
    }
}