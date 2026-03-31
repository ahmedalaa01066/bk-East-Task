using EasyTask.Common.Endpoints;
using EasyTask.Common.Enums;
using EasyTask.Common.Views;
using EasyTask.Features.Common.DefaultKPIs.DTOs;
using EasyTask.Features.Common.DefaultKPIs.Queries;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.DefaultKPIs.GetAllDefaultKPIs
{
    public class GetAllDefaultKPIsEndPoint : EndpointBase<GetAllDefaultKPIsRequestViewModel, GetAllDefaultKPIsResponseViewModel>
    {
        public GetAllDefaultKPIsEndPoint(EndpointBaseParameters<GetAllDefaultKPIsRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.GetAllDefaultKPIs })]
        public async Task<ActionResult<EndPointResponse<PagingViewModel<GetAllDefaultKPIsResponseViewModel>>>> GetAllDefaultKPIs(
         [FromQuery] GetAllDefaultKPIsRequestViewModel? filter)
        {

            var result = await _mediator.Send(filter.MapOne<GetAllDefaultKPIsPagingQuery>());
            var response = result.Data.MapPage<GetAllDefaultKPIsDTO,GetAllDefaultKPIsResponseViewModel>();

            if (result.IsSuccess && result.Data != null)
            {

                return EndPointResponse<PagingViewModel<GetAllDefaultKPIsResponseViewModel>>
                    .Success(response, "DefaultKPIs filtered successfully.");
            }

            return EndPointResponse<PagingViewModel<GetAllDefaultKPIsResponseViewModel>>.Failure(ErrorCode.NotFound);
        }
    }
}
