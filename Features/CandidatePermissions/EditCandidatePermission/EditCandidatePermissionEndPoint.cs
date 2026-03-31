using EasyTask.Common.Endpoints;
using EasyTask.Features.CandidatePermissions.CreateCandidatePermission.Commands;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.CandidatePermissions.EditCandidatePermission
{
    public class EditCandidatePermissionEndPoint : EndpointBase<EditCandidatePermissionRequestViewModel, EditCandidatePermissionResponseViewModel>
    {
        public EditCandidatePermissionEndPoint(EndpointBaseParameters<EditCandidatePermissionRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }

        [HttpPut]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.EditPermissionHoursLeftInMonth })]
        public async Task<EndPointResponse<EditCandidatePermissionResponseViewModel>> EditPermissionHoursLeftInMonth(EditCandidatePermissionRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);
            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<EditEditCandidatePermissionCommand>());
            if (result.IsSuccess)
                return EndPointResponse<EditCandidatePermissionResponseViewModel>.Success(new EditCandidatePermissionResponseViewModel(), "Permission Hours Left In Month Updated Successfully");
            else
                return EndPointResponse<EditCandidatePermissionResponseViewModel>.Failure(result.ErrorCode);
        }
    }
}
