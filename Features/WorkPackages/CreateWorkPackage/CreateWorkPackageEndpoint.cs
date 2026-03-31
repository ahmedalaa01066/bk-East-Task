using EasyTask.Common.Endpoints;
using EasyTask.Features.WorkPackages.CreateWorkPackage.Orchestartor;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.WorkPackages.CreateWorkPackage
{
    public class CreateWorkPackageEndpoint : EndpointBase<CreateWorkPackageRequestViewModel, CreateWorkPackageResponseViewModel>
    {
        public CreateWorkPackageEndpoint(EndpointBaseParameters<CreateWorkPackageRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPost]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.CreateWorkPackage })]
        public async Task<EndPointResponse<CreateWorkPackageResponseViewModel>> CreateWorkPackage(CreateWorkPackageRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);

            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<CreateWorkPackageOrchestartor>());

            if (result.IsSuccess)
            {
                return EndPointResponse<CreateWorkPackageResponseViewModel>.Success(new CreateWorkPackageResponseViewModel(), "WorkPackage Added successfully.");
            }
            return EndPointResponse<CreateWorkPackageResponseViewModel>.Failure(result.ErrorCode);

        }
    }
}
