using EasyTask.Common.Endpoints;
using EasyTask.Features.Common.ExternalMembers.Queries;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.ExternalMembers.ExternalMemberSelectList
{
    public class ExternalMemberSelectListEndpoint : EndpointBase<ExternalMemberSelectListRequestViewModel, ExternalMemberSelectListResponseViewModel>
    {
        public ExternalMemberSelectListEndpoint(EndpointBaseParameters<ExternalMemberSelectListRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.ExternalMemberSelectList })]
        public async Task<EndPointResponse<IEnumerable<ExternalMemberSelectListResponseViewModel>>> ExternalMemberSelectList([FromQuery] ExternalMemberSelectListRequestViewModel viewModel)
        {


            var result = await _mediator.Send(viewModel.MapOne<ExternalMemberSelectListQuery>());

            var response = result.Data.MapList<ExternalMemberSelectListResponseViewModel>();

            if (result.IsSuccess)
                return EndPointResponse<IEnumerable<ExternalMemberSelectListResponseViewModel>>.Success(response, "ExternalMembers got successfully.");
            else
                return EndPointResponse<IEnumerable<ExternalMemberSelectListResponseViewModel>>.Failure(result.ErrorCode);

        }
    }
}
