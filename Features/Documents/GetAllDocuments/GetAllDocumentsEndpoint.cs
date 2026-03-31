using EasyTask.Common.Endpoints;
using EasyTask.Common.Views;
using EasyTask.Features.Common.Documents.DTOs;
using EasyTask.Features.Common.Documents.Queries;
using EasyTask.Helpers;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Documents.GetAllDocuments
{
    public class GetAllDocumentsEndpoint : EndpointBase<GetAllDocumentsRequestViewModel, GetAllDocumentsResponseViewModel>
    {
        public GetAllDocumentsEndpoint(EndpointBaseParameters<GetAllDocumentsRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.GetAllDocuments })]
        public async Task<EndPointResponse<PagingViewModel<GetAllDocumentsResponseViewModel>>> GetAllDocuments([FromQuery] GetAllDocumentsRequestViewModel viewModel)
        {


            var result = await _mediator.Send(viewModel.MapOne<GetAllDocumentsQuery>());
            var response = result.Data.MapPage<GetAllDocumentsDTO, GetAllDocumentsResponseViewModel>();

            if (result.IsSuccess && result.Data != null)
                return EndPointResponse<PagingViewModel<GetAllDocumentsResponseViewModel>>.Success(response, "Documents Filtered Successfully");
            else
                return EndPointResponse<PagingViewModel<GetAllDocumentsResponseViewModel>>.Failure(result.ErrorCode);

        }
    }
}
