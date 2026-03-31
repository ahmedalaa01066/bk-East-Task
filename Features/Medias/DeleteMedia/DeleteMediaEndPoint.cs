using EasyTask.Common.Endpoints;
using EasyTask.Features.Medias.DeleteMedia.Commands;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;

namespace EasyTask.Features.Medias.DeleteMedia
{
    public class DeleteMediaEndPoint : EndpointBase<DeleteMediaRequestViewModel, DeleteMediaResponseViewModel>
    {
        public DeleteMediaEndPoint(EndpointBaseParameters<DeleteMediaRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }

        [HttpDelete]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.DeleteMedia })]
        public async Task<EndPointResponse<DeleteMediaResponseViewModel>> DeleteMedia(DeleteMediaRequestViewModel viewModel)

        {
            var validationResult = await ValidateRequestAsync(viewModel);

            if (!validationResult.IsSuccess)
                return validationResult;

            // Send the command to upload the files
            var result = await _mediator.Send(viewModel.MapOne<DeleteMediaCommand>());

            if (result.IsSuccess)
                return EndPointResponse<DeleteMediaResponseViewModel>.Success(new DeleteMediaResponseViewModel(), "One Media file Deleted successfully");
            else
                return EndPointResponse<DeleteMediaResponseViewModel>.Failure(result.ErrorCode);
        }
    }
}
