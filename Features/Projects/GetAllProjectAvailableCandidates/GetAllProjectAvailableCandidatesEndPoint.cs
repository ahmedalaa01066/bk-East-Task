using EasyTask.Common.Endpoints;
using EasyTask.Features.Projects.GetAllProjectAvailableCandidates.Queries;
using EasyTask.Helpers;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Projects.GetAllProjectAvailableCandidates;

public class GetAllProjectAvailableCandidatesEndPoint(
    EndpointBaseParameters<GetAllProjectAvailableCandidatesRequestViewModel> dependencyCollection)
    : EndpointBase<GetAllProjectAvailableCandidatesRequestViewModel,
        List<GetAllProjectAvailableCandidatesResponseViewModel>>(dependencyCollection)
{
    [HttpGet]
    //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = [Feature.GetAllProjectAvailableCandidates])]
    public async Task<EndPointResponse<List<GetAllProjectAvailableCandidatesResponseViewModel>>> GetAllProjectAvailableCandidates(GetAllProjectAvailableCandidatesRequestViewModel viewModel)
    {
        var validationResult = await ValidateRequestAsync(viewModel);

        if (!validationResult.IsSuccess)
            return validationResult;

        var result = await _mediator.Send(viewModel.MapOne<GetAllProjectAvailableCandidatesQuery>());

        if (result.IsSuccess)
            return EndPointResponse<List<GetAllProjectAvailableCandidatesResponseViewModel>>.Success(result.Data, string.Empty);
            
        return EndPointResponse<List<GetAllProjectAvailableCandidatesResponseViewModel>>.Failure(result.ErrorCode);

    }
}