using EasyTask.Common.Endpoints;
using EasyTask.Features.Candidates.EditCandidateLevel.Command;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Candidates.EditCandidateLevel
{
    public class EditCandidateLevelEndPoint : EndpointBase<EditCandidateLevelRequestViewModel, EditCandidateLevelResponseViewModel>
    {
        public EditCandidateLevelEndPoint(EndpointBaseParameters<EditCandidateLevelRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }

        [HttpPut]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.EditCandidateLevel })]
        public async Task<EndPointResponse<EditCandidateLevelResponseViewModel>> EditCandidateLevel(EditCandidateLevelRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);

            if (!validationResult.IsSuccess)
                return validationResult;

            var result = await _mediator.Send(viewModel.MapOne<EditCandidateLevelCommand>());

            if (result.IsSuccess)
                return EndPointResponse<EditCandidateLevelResponseViewModel>.Success(new EditCandidateLevelResponseViewModel(), "Candidate Level Updated successfully");
            else
                return EndPointResponse<EditCandidateLevelResponseViewModel>.Failure(result.ErrorCode);
        }
    }
}
