using EasyTask.Common.Endpoints;
using EasyTask.Common.Enums;
using EasyTask.Common.Views;
using EasyTask.Features.Common.Users.DTOs;
using EasyTask.Features.Common.Users.Queries;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Users.GetAllUsers
{
    public class GetAllUsersEndpoint : EndpointBase<GetAllUsersRequestViewModel, GetAllUsersResponseViewModel>
    {
        public GetAllUsersEndpoint(EndpointBaseParameters<GetAllUsersRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        [TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.FilterUsers })]
        public async Task<ActionResult<EndPointResponse<PagingViewModel<GetAllUsersResponseViewModel>>>> FilterUsers(
          [FromQuery] GetAllUsersRequestViewModel? filter)
        {

            var result = await _mediator.Send(filter.MapOne<GetAllUsersQuery>());
            var response = result.Data.MapPage<GetAllUsersDTO, GetAllUsersResponseViewModel>();

            if (result.IsSuccess && result.Data != null)
            {

                return EndPointResponse<PagingViewModel<GetAllUsersResponseViewModel>>
                    .Success(response, "Companies filtered successfully.");
            }

            return EndPointResponse<PagingViewModel<GetAllUsersResponseViewModel>>
                .Failure(ErrorCode.NotFound);


        }

    }
}
