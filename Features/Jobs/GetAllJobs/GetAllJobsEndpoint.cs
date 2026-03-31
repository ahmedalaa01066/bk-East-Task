
using EasyTask.Common.Endpoints;
using EasyTask.Common.Enums;
using EasyTask.Common.Views;
using EasyTask.Features.Common.Jobs.DTOs;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Jobs.GetAllJobs
{
    public class GetAllJobsEndpoint : EndpointBase<GetAllJobsRequestViewModel, GetAllJobsResponseViewModel>
    {
        public GetAllJobsEndpoint(EndpointBaseParameters<GetAllJobsRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.GetAllJobs })]
        public async Task<ActionResult<EndPointResponse<PagingViewModel<GetAllJobsResponseViewModel>>>> GetAllJobs(
         [FromQuery] GetAllJobsRequestViewModel? filter)
        {

            var result = await _mediator.Send(filter.MapOne<GetAllJobsQuery>());
            var response = result.Data.MapPage<GetAllJobsDTO, GetAllJobsResponseViewModel>();

            if (result.IsSuccess && result.Data != null)
            {

                return EndPointResponse<PagingViewModel<GetAllJobsResponseViewModel>>
                    .Success(response, "Jobs filtered successfully.");
            }

            return EndPointResponse<PagingViewModel<GetAllJobsResponseViewModel>>
                .Failure(ErrorCode.NotFound);
        }
    }
}
