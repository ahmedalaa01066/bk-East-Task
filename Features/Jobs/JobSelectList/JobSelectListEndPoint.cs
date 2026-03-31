using EasyTask.Common.Endpoints;
using EasyTask.Features.Common.Jobs.Quereies;
using EasyTask.Helpers;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Jobs.JobSelectList
{
    public class JobSelectListEndPoint : EndpointBase<JobSelectListRequestViewModel, JobSelectListResponseViewModel>
    {
        public JobSelectListEndPoint(EndpointBaseParameters<JobSelectListRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.JobSelectList })]
        public async Task<EndPointResponse<IEnumerable<JobSelectListResponseViewModel>>> JobSelectList([FromQuery] JobSelectListRequestViewModel viewModel)
        {


            var result = await _mediator.Send(viewModel.MapOne<JobSelectListQuery>());

            var response = result.Data.MapList<JobSelectListResponseViewModel>();

            if (result.IsSuccess)
                return EndPointResponse<IEnumerable<JobSelectListResponseViewModel>>.Success(response, "Jobs got successfully.");
            else
                return EndPointResponse<IEnumerable<JobSelectListResponseViewModel>>.Failure(result.ErrorCode);

        }
    }
}
