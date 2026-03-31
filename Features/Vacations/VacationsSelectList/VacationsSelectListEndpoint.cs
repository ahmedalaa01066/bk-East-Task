using EasyTask.Common.Endpoints;
using EasyTask.Features.Common.Vacations.Queries;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Vacations.VacationsSelectList
{
    public class VacationsSelectListEndpoint : EndpointBase<VacationsSelectListRequestViewModel, VacationsSelectListResponseViewModel>
    {
        public VacationsSelectListEndpoint(EndpointBaseParameters<VacationsSelectListRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.VacationsSelectList })]
        public async Task<EndPointResponse<IEnumerable<VacationsSelectListResponseViewModel>>> VacationsSelectList([FromQuery] VacationsSelectListRequestViewModel viewModel)
        {


            var result = await _mediator.Send(viewModel.MapOne<VacationsSelectListQuery>());

            if (result.IsSuccess)
                return EndPointResponse<IEnumerable<VacationsSelectListResponseViewModel>>.Success(result.Data.MapList<VacationsSelectListResponseViewModel>(), "Vacationss got successfully.");
            else
                return EndPointResponse<IEnumerable<VacationsSelectListResponseViewModel>>.Failure(result.ErrorCode);

        }
    }
}
