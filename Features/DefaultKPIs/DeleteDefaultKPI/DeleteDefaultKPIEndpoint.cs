using EasyTask.Common.Endpoints;
using EasyTask.Features.DefaultKPIs.DeleteDefaultKPI.Commands;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.DefaultKPIs.DeleteDefaultKPI
{
    public class DeleteDefaultKPIEndpoint : EndpointBase<DeleteDefaultKPIRequetViewModel, DeleteDefaultKPIResponseViewModel>
    {
        public DeleteDefaultKPIEndpoint(EndpointBaseParameters<DeleteDefaultKPIRequetViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpDelete]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.DeleteDefaultKPI })]
        public async Task<EndPointResponse<DeleteDefaultKPIResponseViewModel>> Delete(DeleteDefaultKPIRequetViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);

            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<DeleteDefaultKPICommand>());
            if (result.IsSuccess)
            {
                return EndPointResponse<DeleteDefaultKPIResponseViewModel>.Success(new DeleteDefaultKPIResponseViewModel(), "Default KPI Deleted successfully.");
            }
            return EndPointResponse<DeleteDefaultKPIResponseViewModel>.Failure(result.ErrorCode, result.Message);

        }
    }
}
