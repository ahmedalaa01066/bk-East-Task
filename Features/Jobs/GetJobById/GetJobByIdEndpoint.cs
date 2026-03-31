using EasyTask.Common.Endpoints;
using EasyTask.Features.Common.Jobs.Quereies;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Jobs.GetJobById
{
    public class GetJobByIdEndpoint : EndpointBase<GetJobByIdRequestViewModel, GetJobByIdResponseViewModel>
    {
        public GetJobByIdEndpoint(EndpointBaseParameters<GetJobByIdRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.GetJobById })]
        public async Task<EndPointResponse<GetJobByIdResponseViewModel>> GetJobById([FromQuery] GetJobByIdRequestViewModel viewModel)
        {

            var result = await _mediator.Send(viewModel.MapOne<GetJobByIdQuery>());

            GetJobByIdResponseViewModel response = result.Data.MapOne<GetJobByIdResponseViewModel>();

            if (result.IsSuccess && result.Data != null)
                return EndPointResponse<GetJobByIdResponseViewModel>.Success(response, "Get Job successfully.");
            else
                return EndPointResponse<GetJobByIdResponseViewModel>.Failure(result.ErrorCode);

        }
    }
}
