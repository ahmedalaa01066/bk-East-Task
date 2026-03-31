using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Models.Enums;
using EasyTask.Models.PermissionRequests;

namespace EasyTask.Features.PermissionRequests.CancelPermissionRequest.Commands
{
    public record CancelPermissionRequestCommand(string ID) : IRequestBase<bool>;
    public class CancelPermissionRequestCommandHandler : RequestHandlerBase<PermissionRequest, CancelPermissionRequestCommand, bool>
    {
        public CancelPermissionRequestCommandHandler(RequestHandlerBaseParameters<PermissionRequest> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(CancelPermissionRequestCommand request, CancellationToken cancellationToken)
        {
            var check = _repository.Get(r => r.ID == request.ID).FirstOrDefault();
            if (check.PermissionRequestStatus == RequestStatus.Pending)
            {
                if (check == null)
                {
                    return (RequestResult<bool>.Failure(ErrorCode.NotFound));
                }
                var Request = new PermissionRequest
                {
                    ID = request.ID,
                    PermissionRequestStatus = RequestStatus.Cancelled,
                };
                _repository.SaveIncluded(Request, nameof(Request.PermissionRequestStatus));
                _repository.SaveChanges();
                return RequestResult<bool>.Success(true);
            }
            return RequestResult<bool>.Failure(ErrorCode.CannotCancel);
        }
    }
}
