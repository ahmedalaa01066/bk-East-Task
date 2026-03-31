using EasyTask.Common.Endpoints;
using EasyTask.Features.Jobs.EditJob.Commands;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Jobs.EditJob
{
    public class EditJobEndPoint : EndpointBase<EditJobRequestViewModel, EditJobResponseViewModel>
    {
        public EditJobEndPoint(EndpointBaseParameters<EditJobRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPut]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.EditJob })]
        public async Task<EndPointResponse<EditJobResponseViewModel>> EditJob(EditJobRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);

            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<EditJobCommand>());

            if (result.IsSuccess)
            {
                return EndPointResponse<EditJobResponseViewModel>.Success(new EditJobResponseViewModel(), "Job Edited successfully.");
            }
            return EndPointResponse<EditJobResponseViewModel>.Failure(result.ErrorCode);

        }
    }
}
