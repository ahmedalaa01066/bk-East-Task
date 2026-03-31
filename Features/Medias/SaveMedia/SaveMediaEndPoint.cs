using EasyTask.Common.Endpoints;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using EasyTask.Helpers;
using EasyTask.Features.Medias.SaveMedia.Commands;

namespace EasyTask.Features.Medias.SaveMedia
{
    public class SaveMediaEndPoint : EndpointBase<SaveMediaRequestViewModel, SaveMediaResponseViewModel>
    {
        public SaveMediaEndPoint(EndpointBaseParameters<SaveMediaRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPost]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.SaveMedia })]
        public async Task<EndPointResponse<SaveMediaResponseViewModel>> SaveMedia(SaveMediaRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);

            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<SaveMediaCommand>());
            if (result.IsSuccess)
                return EndPointResponse<SaveMediaResponseViewModel>.Success(new SaveMediaResponseViewModel(), "Media Saved successfully");
            else
                return EndPointResponse<SaveMediaResponseViewModel>.Failure(result.ErrorCode);
        }
    }
}
