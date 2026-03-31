using EasyTask.Common.Endpoints;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;
using EasyTask.Features.Managements.BulkDeleteManagement.Orchisterator;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;

namespace EasyTask.Features.Managements.BulkDeleteManagement
{
    public class BulkDeleteManagementEndPoint : EndpointBase<BulkDeleteManagementRequestViewModel, BulkDeleteManagementResponseViewModel>
    {
        public BulkDeleteManagementEndPoint(EndpointBaseParameters<BulkDeleteManagementRequestViewModel> parameters) : base(parameters)
        {
        }

        [HttpDelete]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.BulkDeleteManagement })]
        public async Task<EndPointResponse<BulkDeleteManagementResponseViewModel>> BulkDeleteManagement(BulkDeleteManagementRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);
            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<BulkDeleteManagementOrchisterator>());
            if (result.IsSuccess)
                return EndPointResponse<BulkDeleteManagementResponseViewModel>.Success(new BulkDeleteManagementResponseViewModel(), "All Managements Deleted Successfully");
            else
                return EndPointResponse<BulkDeleteManagementResponseViewModel>.Failure(result.ErrorCode);
        }
    }
}
