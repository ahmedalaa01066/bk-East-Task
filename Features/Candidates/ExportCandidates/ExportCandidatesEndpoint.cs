using EasyTask.Common.Endpoints;
using EasyTask.Common.Enums;
using EasyTask.Features.Common.Candidates.Queries;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Candidates.ExportCandidates
{
    public class ExportCandidatesEndpoint : EndpointBase<ExportCandidatesRequestViewModel, ExportCandidatesResponseViewModel>
    {
        public ExportCandidatesEndpoint(EndpointBaseParameters<ExportCandidatesRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.ExportCandidates })]
        public async Task<ActionResult<EndPointResponse<ExportCandidatesResponseViewModel>>> ExportCandidates([FromQuery] ExportCandidatesRequestViewModel? filter)
        {
            var query = filter.MapOne<ExportCandidatesQuery>();
            var result = await _mediator.Send(query);

            if (result.IsSuccess && result.Data != null)
            {
                var fileResult = new FileContentResult(result.Data.FileContent ?? Array.Empty<byte>(), result.Data.ContentType ?? "application/octet-stream")
                {
                    FileDownloadName = result.Data.FileName ?? "export.xlsx",
                    EnableRangeProcessing = false
                };

                return fileResult;
            }

            return EndPointResponse<ExportCandidatesResponseViewModel>
                .Failure(ErrorCode.NotFound, "No Candidates found.");
        }
    }
}
