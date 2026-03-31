using EasyTask.Common.Endpoints;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;
using EasyTask.Features.Medias.DeleteBulkMediaBySourceId.Commands;
using EasyTask.Helpers;
using EasyTask.Features.Medias.DeleteBulkMediaBySourceId;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;

namespace EasyTask.Features.Medias.DeleteMedia
{
    public class DeleteBulkMediaBySourceIdEndPoint : EndpointBase<DeleteBulkMediaBySourceIdRequestViewModel, DeleteBulkMediaBySourceIdResponseViewModel>
    {
        public DeleteBulkMediaBySourceIdEndPoint(EndpointBaseParameters<DeleteBulkMediaBySourceIdRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }

        [HttpDelete]
        [TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.DeleteBulkMediaBySourceId })]
        public async Task<EndPointResponse<DeleteBulkMediaBySourceIdResponseViewModel>> DeleteBulkMediaBySourceId(DeleteBulkMediaBySourceIdRequestViewModel viewModel)

        {
            var validationResult = await ValidateRequestAsync(viewModel);

            if (!validationResult.IsSuccess)
                return validationResult;

            // Send the command to upload the files
            var result = await _mediator.Send(viewModel.MapOne<DeleteBulkMediaBySourceIdCommand>());

            if (result.IsSuccess)
                return EndPointResponse<DeleteBulkMediaBySourceIdResponseViewModel>.Success(new DeleteBulkMediaBySourceIdResponseViewModel(), "Media files Deleted successfully");
            else
                return EndPointResponse<DeleteBulkMediaBySourceIdResponseViewModel>.Failure(result.ErrorCode);
        }
    }
}
