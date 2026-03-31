using EasyTask.Common.Endpoints;
using EasyTask.Features.Common.Positions.Queries;
using EasyTask.Helpers;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Positions.PositionSelectList
{
    public class PositionSelectListEndPoint : EndpointBase<PositionSelectListRequestViewModel, PositionSelectListResponseViewModel>
    {
        public PositionSelectListEndPoint(EndpointBaseParameters<PositionSelectListRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.PositionSelectList })]
        public async Task<EndPointResponse<IEnumerable<PositionSelectListResponseViewModel>>> PositionSelectList([FromQuery] PositionSelectListRequestViewModel viewModel)
        {


            var result = await _mediator.Send(viewModel.MapOne<PositionSelectListQuery>());

            var response = result.Data.MapList<PositionSelectListResponseViewModel>();

            if (result.IsSuccess)
                return EndPointResponse<IEnumerable<PositionSelectListResponseViewModel>>.Success(response, "Positions got successfully.");
            else
                return EndPointResponse<IEnumerable<PositionSelectListResponseViewModel>>.Failure(result.ErrorCode);

        }
    }
}
