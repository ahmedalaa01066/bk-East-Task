using EasyTask.Common.Endpoints;
using EasyTask.Features.Common.Shifts.Queries;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Shifts.ShiftSelectList
{
    public class ShiftSelectListEndPoint : EndpointBase<ShiftSelectListRequestViewModel, ShiftSelectListResponseViewModel>
    {
        public ShiftSelectListEndPoint(EndpointBaseParameters<ShiftSelectListRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.SelectShiftList })]
        public async Task<EndPointResponse<IEnumerable<ShiftSelectListResponseViewModel>>> SelectShiftList([FromQuery] ShiftSelectListRequestViewModel viewModel)
        {


            var result = await _mediator.Send(viewModel.MapOne<ShiftSelectListQuery>());

            var response = result.Data.MapList<ShiftSelectListResponseViewModel>();

            if (result.IsSuccess)
                return EndPointResponse<IEnumerable<ShiftSelectListResponseViewModel>>.Success(response, "Shifts got successfully.");
            else
                return EndPointResponse<IEnumerable<ShiftSelectListResponseViewModel>>.Failure(result.ErrorCode);

        }
    }
}
