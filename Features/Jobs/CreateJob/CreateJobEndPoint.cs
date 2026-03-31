using EasyTask.Common.Endpoints;
using EasyTask.Features.Jobs.CreateJob.Command;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Jobs.CreateJob
{
    public class CreateJobEndPoint : EndpointBase<CreateJobRequestViewModel, CreateJobResponseViewModel>
    {
        public CreateJobEndPoint(EndpointBaseParameters<CreateJobRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPost]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.CreateJob })]
        public async Task<EndPointResponse<CreateJobResponseViewModel>> CreateJob(CreateJobRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);

            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<CreateJobCommand>());

            if (result.IsSuccess)
            {
                return EndPointResponse<CreateJobResponseViewModel>.Success(new CreateJobResponseViewModel(), "Job Added successfully.");
            }
            return EndPointResponse<CreateJobResponseViewModel>.Failure(result.ErrorCode);

        }
    }
}
