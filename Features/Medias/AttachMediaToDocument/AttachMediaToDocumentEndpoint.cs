using EasyTask.Common.Endpoints;
using EasyTask.Features.Medias.AttachMediaToDocument.Commands;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Medias.AttachMediaToDocument
{
    public class AttachMediaToDocumentEndpoint : EndpointBase<AttachMediaToDocumentRequestViewModel, AttachMediaToDocumentResponseViewModel>
    {
        public AttachMediaToDocumentEndpoint(EndpointBaseParameters<AttachMediaToDocumentRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPost]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.AttachMediaToDocument })]
        public async Task<EndPointResponse<AttachMediaToDocumentResponseViewModel>> AttachMediaToDocument(AttachMediaToDocumentRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);

            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<AttachMediaToDocumentCommand>());
            if (result.IsSuccess)
                return EndPointResponse<AttachMediaToDocumentResponseViewModel>.Success(new AttachMediaToDocumentResponseViewModel(), "Media Saved successfully");
            else
                return EndPointResponse<AttachMediaToDocumentResponseViewModel>.Failure(result.ErrorCode);
        }
    }
}
