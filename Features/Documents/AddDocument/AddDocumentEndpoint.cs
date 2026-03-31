using EasyTask.Common.Endpoints;
using EasyTask.Features.Documents.AddDocument.Commands;
using EasyTask.Helpers;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Documents.AddDocument
{
    public class AddDocumentEndpoint : EndpointBase<AddDocumentRequestViewModel, AddDocumentResponseViewModel>
    {
        public AddDocumentEndpoint(EndpointBaseParameters<AddDocumentRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPost]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.AddDocument })]
        public async Task<EndPointResponse<AddDocumentResponseViewModel>> AddDocument(AddDocumentRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);

            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<AddFolderCommand>());
            if (result.IsSuccess)
                return EndPointResponse<AddDocumentResponseViewModel>.Success(new AddDocumentResponseViewModel(), "Document Added Successfully");
            else
                return EndPointResponse<AddDocumentResponseViewModel>.Failure(result.ErrorCode);
        }

    }
}
