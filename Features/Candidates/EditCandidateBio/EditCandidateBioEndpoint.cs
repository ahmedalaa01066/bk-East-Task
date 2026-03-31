using EasyTask.Common.Endpoints;
using EasyTask.Features.Candidates.EditCandidateBio.Commands;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Candidates.EditCandidateBio
{
    public class EditCandidateBioEndpoint : EndpointBase<EditCandidateBioRequestViewModel, EditCandidateBioResponseViewModel>
    {
        public EditCandidateBioEndpoint(EndpointBaseParameters<EditCandidateBioRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPut]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.EditCandidateBio })]
        public async Task<EndPointResponse<EditCandidateBioResponseViewModel>> EditCandidateBio(EditCandidateBioRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);

            if (!validationResult.IsSuccess)
                return validationResult;

            var result = await _mediator.Send(viewModel.MapOne<EditCandidateBioCommand>());

            if (result.IsSuccess)
                return EndPointResponse<EditCandidateBioResponseViewModel>.Success(new EditCandidateBioResponseViewModel(), "Candidate Bio Updated successfully");
            else
                return EndPointResponse<EditCandidateBioResponseViewModel>.Failure(result.ErrorCode);
        }
    }
}
