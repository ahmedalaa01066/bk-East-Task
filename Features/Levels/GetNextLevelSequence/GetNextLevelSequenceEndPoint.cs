using EasyTask.Common.Endpoints;
using EasyTask.Features.Common.Levels.Queries;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Levels.GetNextLevelSequence
{
    public class GetNextLevelSequenceEndPoint : EndpointBase<GetNextLevelSequenceRequestViewModel, GetNextLevelSequenceResponseViewModel>
    {
        public GetNextLevelSequenceEndPoint(EndpointBaseParameters<GetNextLevelSequenceRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.GetNextLevelSequence })]
        public async Task<EndPointResponse<GetNextLevelSequenceResponseViewModel>> GetNextLevelSequence([FromQuery] GetNextLevelSequenceRequestViewModel viewModel)
        {
            var result = await _mediator.Send(viewModel.MapOne<GetNextLevelSequenceQuery>());
            var response = result.Data.MapOne<GetNextLevelSequenceResponseViewModel>();
            if (result.IsSuccess && result.Data != null)
                return EndPointResponse<GetNextLevelSequenceResponseViewModel>.Success(response, "Get Next Sequence Level successfully.");
            else
                return EndPointResponse<GetNextLevelSequenceResponseViewModel>.Failure(result.ErrorCode);

        }
    }
}
