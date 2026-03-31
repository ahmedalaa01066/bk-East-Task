using EasyTask.Common.Endpoints;
using EasyTask.Features.Penalities.EditPenality.Commands;
using EasyTask.Helpers;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Penalities.EditPenality
{
    public class EditPenalityEndPoint : EndpointBase<EditPenalityRequestViewModel, EditPenalityResponseViewModel>
    {
        public EditPenalityEndPoint(EndpointBaseParameters<EditPenalityRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPut]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.EditPenality })]
        public async Task<EndPointResponse<EditPenalityResponseViewModel>> EditPenality(EditPenalityRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);
            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<EditPenalityCommand>());
            if (result.IsSuccess)
                return EndPointResponse<EditPenalityResponseViewModel>.Success(new EditPenalityResponseViewModel(), "Penality Updated Successfully");
            else
                return EndPointResponse<EditPenalityResponseViewModel>.Failure(result.ErrorCode);
        }
    }
}
