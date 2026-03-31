using EasyTask.Common.Endpoints;
using EasyTask.Common.Enums;
using EasyTask.Features.Common.Medias.Queries;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Medias.GetAllMediaByDocumentId
{
    public class GetAllMediaByDocumentIdEndpoint : EndpointBase<GetAllMediaByDocumentIdRequestViewModel, GetAllMediaByDocumentIdResponseViewModel>
    {
        public GetAllMediaByDocumentIdEndpoint(EndpointBaseParameters<GetAllMediaByDocumentIdRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.GetAllMediaByDocumentId })]
        public async Task<ActionResult<EndPointResponse<IEnumerable<GetAllMediaByDocumentIdResponseViewModel>>>> GetAll(
       [FromQuery] GetAllMediaByDocumentIdRequestViewModel filter)
        {

            var result = await _mediator.Send(filter.MapOne<GetAllMediaByDocumentIdQuery>());
            var response = result.Data.MapList<GetAllMediaByDocumentIdResponseViewModel>();

            if (result.IsSuccess && result.Data != null)
            {

                return EndPointResponse<IEnumerable<GetAllMediaByDocumentIdResponseViewModel>>
                    .Success(response, "Medias got successfully.");
            }

            return EndPointResponse<IEnumerable<GetAllMediaByDocumentIdResponseViewModel>>
                .Failure(ErrorCode.NotFound);
        }
    }
}
