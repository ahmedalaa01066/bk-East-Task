using EasyTask.Common.Endpoints;
using EasyTask.Features.Projects.GetAllProjectWorkPackages.Queries;
using EasyTask.Helpers;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Projects.GetAllProjectWorkPackages;

public class GetAllProjectWorkPackagesEndPoint(
    EndpointBaseParameters<GetAllProjectWorkPackagesRequestVm> dependencyCollection)
    : EndpointBase<GetAllProjectWorkPackagesRequestVm,
        GetAllProjectWorkPackagesResponseVm>(dependencyCollection)
{
    [HttpGet]
    //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = [Feature.GetAllProjectWorkPackages])]
    public async Task<EndPointResponse<GetAllProjectWorkPackagesResponseVm>> GetAllProjectWorkPackages(GetAllProjectWorkPackagesRequestVm vm)
    {
        var validationResult = await ValidateRequestAsync(vm);

        if (!validationResult.IsSuccess)
            return validationResult;

        var result = await _mediator.Send(vm.MapOne<GetAllProjectWorkPackagesQuery>());

        if (result.IsSuccess)
            return EndPointResponse<GetAllProjectWorkPackagesResponseVm>.Success(result.Data, string.Empty);

        return EndPointResponse<GetAllProjectWorkPackagesResponseVm>.Failure(result.ErrorCode);
    }
}
