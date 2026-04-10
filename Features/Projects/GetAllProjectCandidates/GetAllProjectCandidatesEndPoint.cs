using EasyTask.Common.Endpoints;
using EasyTask.Features.Projects.GetAllProjectCandidates.Queries;
using EasyTask.Helpers;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Projects.GetAllProjectCandidates;

public class GetAllProjectCandidatesEndPoint(
    EndpointBaseParameters<GetAllProjectCandidatesRequestVm> dependencyCollection)
    : EndpointBase<GetAllProjectCandidatesRequestVm,
        List<GetAllProjectCandidatesResponseVm>>(dependencyCollection)
{
    [HttpGet]
    //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = [Feature.GetAllProjectCandidates])]
    public async Task<EndPointResponse<List<GetAllProjectCandidatesResponseVm>>> GetAllProjectCandidates(GetAllProjectCandidatesRequestVm vm)
    {
        var validationResult = await ValidateRequestAsync(vm);

        if (!validationResult.IsSuccess)
            return validationResult;

        var result = await _mediator.Send(vm.MapOne<GetAllProjectCandidatesQuery>());

        if (result.IsSuccess)
            return EndPointResponse<List<GetAllProjectCandidatesResponseVm>>.Success(result.Data, string.Empty);
            
        return EndPointResponse<List<GetAllProjectCandidatesResponseVm>>.Failure(result.ErrorCode);

    }
}