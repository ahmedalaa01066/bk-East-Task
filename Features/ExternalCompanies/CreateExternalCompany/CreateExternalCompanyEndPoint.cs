using EasyTask.Common.Endpoints;
using EasyTask.Features.ExternalCompanies.CreateExternalCompany.Commands;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.ExternalCompanies.CreateExternalCompany
{
    public class CreateExternalCompanyEndPoint : EndpointBase<CreateExternalCompanyRequestViewModel, CreateExternalCompanyResponseViewModel>
    {
        public CreateExternalCompanyEndPoint(EndpointBaseParameters<CreateExternalCompanyRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPost]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.CreateExternalCompany })]
        public async Task<EndPointResponse<CreateExternalCompanyResponseViewModel>> CreateExternalCompany(CreateExternalCompanyRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);

            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<CreateExternalCompanyCommand>());

            if (result.IsSuccess)
            {
                return EndPointResponse<CreateExternalCompanyResponseViewModel>.Success(new CreateExternalCompanyResponseViewModel(), "ExternalCompany Added successfully.");
            }
            return EndPointResponse<CreateExternalCompanyResponseViewModel>.Failure(result.ErrorCode);

        }
    }
}
