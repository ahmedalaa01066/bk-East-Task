using EasyTask.Common.Endpoints;
using EasyTask.Features.Projects.CreateProject.Commands;
using EasyTask.Helpers;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Projects.CreateProject
{
    public class CreateProjectEndPoint : EndpointBase<CreateProjectRequestViewModel, CreateProjectResponseViewModel>
    {
        public CreateProjectEndPoint(EndpointBaseParameters<CreateProjectRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }

        [HttpPost]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.CreateProject })]
        public async Task<EndPointResponse<CreateProjectResponseViewModel>> CreateProject(CreateProjectRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);
            if (!validationResult.IsSuccess)
                return validationResult;

            // Send command to MediatR
            var result = await _mediator.Send(viewModel.MapOne<CreateProjectCommand>());

            if (result.IsSuccess)
            {
                // ✅ Map the project ID returned from handler to response ViewModel
                var response = MapperHelper.Mapper.Map<CreateProjectResponseViewModel>(result.Data);
                return EndPointResponse<CreateProjectResponseViewModel>.Success(response, "Project added successfully.");
            }

            return EndPointResponse<CreateProjectResponseViewModel>.Failure(result.ErrorCode);
        }
    }
}
