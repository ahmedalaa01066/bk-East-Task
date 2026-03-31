using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Models.Enums;
using EasyTask.Models.PermissionRequests;

namespace EasyTask.Features.PermissionRequests.SecondApprovePermissionRequest.Commands
{
    public record SecondApprovePermissionRequestCommand(string ID) : IRequestBase<bool>;
    public class SecondApprovePermissionRequestCommandHandler : RequestHandlerBase<PermissionRequest, SecondApprovePermissionRequestCommand, bool>
    {
        public SecondApprovePermissionRequestCommandHandler(RequestHandlerBaseParameters<PermissionRequest> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(SecondApprovePermissionRequestCommand request, CancellationToken cancellationToken)
        {
            var check = _repository.Get(r => r.ID == request.ID).FirstOrDefault();
            if (check == null)
            {
                return (RequestResult<bool>.Failure(ErrorCode.NotFound));
            }
            var Request = new PermissionRequest
            {
                ID = request.ID,
                PermissionRequestStatus = RequestStatus.SecondApproval,
            };
            _repository.SaveIncluded(Request, nameof(Request.PermissionRequestStatus));
            _repository.SaveChanges();
            return RequestResult<bool>.Success(true);
        }
    }
}
