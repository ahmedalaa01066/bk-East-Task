using EasyTask.Common.Endpoints;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;
using EasyTask.Features.Penalities.DeletePenality.Commands;
using EasyTask.Helpers;
using EasyTask.Models.Enums;
using EasyTask.Middlewares;

namespace EasyTask.Features.Penalities.DeletePenality
{
    public class DeletePenalityEndpoint : EndpointBase<DeletePenalityRequestViewModel, DeletePenalityResponseViewModel>
    {
        public DeletePenalityEndpoint(EndpointBaseParameters<DeletePenalityRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpDelete]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.DeletePenality })]
        public async Task<EndPointResponse<DeletePenalityResponseViewModel>> DeletePenality(DeletePenalityRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);

            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<DeletePenalityCommand>());
            if (result.IsSuccess)
            {
                return EndPointResponse<DeletePenalityResponseViewModel>.Success(new DeletePenalityResponseViewModel(), "Penality Deleted successfully.");
            }
            return EndPointResponse<DeletePenalityResponseViewModel>.Failure(result.ErrorCode);

        }
    }
}
