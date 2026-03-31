using EasyTask.Common.Endpoints;
using EasyTask.Features.DefaultKPIs.CreateDefaultKPI.Commands;
using EasyTask.Features.Levels.AddLevel;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.DefaultKPIs.CreateDefaultKPI
{
    public class CreateDefaultKPIEndPoint : EndpointBase<CreateDefaultKPIRequestViewModel, CreateDefaultKPIResponseViewModel>
    {
        public CreateDefaultKPIEndPoint(EndpointBaseParameters<CreateDefaultKPIRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPost]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.CreateDefaultKPI })]
        public async Task<EndPointResponse<CreateDefaultKPIResponseViewModel>> CreateDefaultKPI(CreateDefaultKPIRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);

            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<CreateDefaultKPICommand>());
            //var response = result.Data.MapOne<CreateDefaultKPIResponseViewModel>();
            if (result.IsSuccess)
                return EndPointResponse<CreateDefaultKPIResponseViewModel>.Success(new CreateDefaultKPIResponseViewModel(result.Data), "Default KPI Added Successfully");
            else
                return EndPointResponse<CreateDefaultKPIResponseViewModel>.Failure(result.ErrorCode);
        }
    }
}
