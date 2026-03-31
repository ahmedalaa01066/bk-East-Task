using EasyTask.Common.Endpoints;
using EasyTask.Common.Enums;
using EasyTask.Common.Views;
using EasyTask.Features.Common.SpecialDays.DTOs;
using EasyTask.Features.Common.SpecialDays.Queries;
using EasyTask.Helpers;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.SpecialDays.GetAllSpecialDays
{
    public class GetAllSpecialDaysEndPoint : EndpointBase<GetAllSpecialDaysRequestViewModel, GetAllSpecialDaysResponseViewModel>
    {
        public GetAllSpecialDaysEndPoint(EndpointBaseParameters<GetAllSpecialDaysRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.GetAllSpecialDays })]
        public async Task<ActionResult<EndPointResponse<PagingViewModel<GetAllSpecialDaysResponseViewModel>>>> GetAllSpecialDays(
         [FromQuery] GetAllSpecialDaysRequestViewModel? filter)
        {

            var result = await _mediator.Send(filter.MapOne<GetAllSpecialDaysQuery>());
            var response = result.Data.MapPage<GetSpecialDayByIdDTO, GetAllSpecialDaysResponseViewModel>();

            if (result.IsSuccess && result.Data != null)
            {

                return EndPointResponse<PagingViewModel<GetAllSpecialDaysResponseViewModel>>
                    .Success(response, "Special Days filtered successfully.");
            }

            return EndPointResponse<PagingViewModel<GetAllSpecialDaysResponseViewModel>>
                .Failure(ErrorCode.NotFound);
        }
    }
}
