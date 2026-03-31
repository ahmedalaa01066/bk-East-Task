using EasyTask.Common.Endpoints;
using EasyTask.Features.ProjectTypes.CreateProjectType.Commands;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.ProjectTypes.CreateProjectType
{
    public class CreateProjectTypeEndPoint : EndpointBase<CreateProjectTypeRequestViewModel, CreateProjectTypeResponseViewModel>
    {
        public CreateProjectTypeEndPoint(EndpointBaseParameters<CreateProjectTypeRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPost]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.CreateProjectType })]
        public async Task<EndPointResponse<CreateProjectTypeResponseViewModel>> CreateProjectType(CreateProjectTypeRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);

            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<CreateProjectTypeCommand>());

            if (result.IsSuccess)
            {
                return EndPointResponse<CreateProjectTypeResponseViewModel>.Success(new CreateProjectTypeResponseViewModel(), "Project Type Added successfully.");
            }
            return EndPointResponse<CreateProjectTypeResponseViewModel>.Failure(result.ErrorCode);

        }
    }
}
