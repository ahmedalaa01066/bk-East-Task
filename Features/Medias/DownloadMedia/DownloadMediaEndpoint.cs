using EasyTask.Common.Endpoints;
using EasyTask.Features.Common.Medias.Queries;
using EasyTask.Helpers;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Medias.DownloadMedia
{
    public class DownloadMediaEndpoint : EndpointBase<DownloadMediaRequestViewModel, DownloadMediaResponseViewModel>
    {
        public DownloadMediaEndpoint(EndpointBaseParameters<DownloadMediaRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        public async Task<ActionResult<EndPointResponse<DownloadMediaResponseViewModel>>> DownloadMedia([FromQuery] DownloadMediaRequestViewModel viewModel)
        {
            var result = await _mediator.Send(viewModel.MapOne<DownloadMediaQuery>());
            if (result.IsSuccess && result.Data != null)
            {
                var fileResult = new FileContentResult(
                    result.Data.FileContent ?? Array.Empty<byte>(),
                    result.Data.ContentType ?? "application/octet-stream")
                {
                    FileDownloadName = result.Data.FileName ?? "export.xlsx",
                    EnableRangeProcessing = false
                };

                return fileResult;
            }

            return EndPointResponse<DownloadMediaResponseViewModel>.Failure(result.ErrorCode);
        }

    }
}
