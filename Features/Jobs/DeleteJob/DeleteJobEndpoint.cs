using EasyTask.Common.Endpoints;
using EasyTask.Features.Jobs.DeleteJob.Commands;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Jobs.DeleteJob
{
    public class DeleteJobEndpoint : EndpointBase<DeleteJobRequestViewModel, DeleteJobResponseViewModel>
    {
        public DeleteJobEndpoint(EndpointBaseParameters<DeleteJobRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }

        [HttpDelete]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.DeleteJob })]
        public async Task<EndPointResponse<DeleteJobResponseViewModel>> Delete(DeleteJobRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);
            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<DeleteJobCommand>());
            if (result.IsSuccess)
                return EndPointResponse<DeleteJobResponseViewModel>.Success(new DeleteJobResponseViewModel(), "Job Deleted Successfully");
            else
                return EndPointResponse<DeleteJobResponseViewModel>.Failure(result.ErrorCode);
        }

    }
}
