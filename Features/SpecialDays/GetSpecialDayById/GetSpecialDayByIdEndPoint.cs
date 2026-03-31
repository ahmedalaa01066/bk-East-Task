using EasyTask.Common.Endpoints;
using EasyTask.Features.Common.SpecialDays.Queries;
using EasyTask.Helpers;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.SpecialDays.GetSpecialDayById
{
    public class GetSpecialDayByIdEndPoint : EndpointBase<GetSpecialDayByIdRequestViewModel, GetSpecialDayByIdResponseViewModel>
    {
        public GetSpecialDayByIdEndPoint(EndpointBaseParameters<GetSpecialDayByIdRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.GetSpecialDayById })]
        public async Task<EndPointResponse<GetSpecialDayByIdResponseViewModel>> GetSpecialDayById([FromQuery] GetSpecialDayByIdRequestViewModel viewModel)
        {

            var result = await _mediator.Send(viewModel.MapOne<GetSpecialDayByIdQuery>());

            GetSpecialDayByIdResponseViewModel response = result.Data.MapOne<GetSpecialDayByIdResponseViewModel>();

            if (result.IsSuccess && result.Data != null)
                return EndPointResponse<GetSpecialDayByIdResponseViewModel>.Success(response, "Get Special Day successfully.");
            else
                return EndPointResponse<GetSpecialDayByIdResponseViewModel>.Failure(result.ErrorCode);

        }
    }
}
