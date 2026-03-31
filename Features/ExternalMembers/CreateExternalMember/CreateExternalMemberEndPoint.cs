using EasyTask.Common.Endpoints;
using EasyTask.Features.ExternalMembers.CreateExternalMember.Commands;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.ExternalMembers.CreateExternalMember
{
    public class CreateExternalMemberEndPoint : EndpointBase<CreateExternalMemberRequestViewModel, CreateExternalMemberResponseViewModel>
    {
        public CreateExternalMemberEndPoint(EndpointBaseParameters<CreateExternalMemberRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPost]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.CreateExternalMember })]
        public async Task<EndPointResponse<CreateExternalMemberResponseViewModel>> CreateExternalMember(CreateExternalMemberRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);

            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<CreateExternalMemberCommand>());

            if (result.IsSuccess)
            {
                return EndPointResponse<CreateExternalMemberResponseViewModel>.Success(new CreateExternalMemberResponseViewModel(), "ExternalMember Added successfully.");
            }
            return EndPointResponse<CreateExternalMemberResponseViewModel>.Failure(result.ErrorCode);

        }
    }
}
