using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Models.Enums;
using EasyTask.Models.PermissionRequests;

namespace EasyTask.Features.PermissionRequests.FirstApprovePermissionRequest.Commands
{
    public record FirstApprovePermissionRequestCommand(string ID) : IRequestBase<bool>;
    public class FirstApprovePermissionRequestCommandHandler : RequestHandlerBase<PermissionRequest, FirstApprovePermissionRequestCommand, bool>
    {
        public FirstApprovePermissionRequestCommandHandler(RequestHandlerBaseParameters<PermissionRequest> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(FirstApprovePermissionRequestCommand request, CancellationToken cancellationToken)
        {
            var check = _repository.Get(r => r.ID == request.ID).FirstOrDefault();
            if (check == null)
            {
                return (RequestResult<bool>.Failure(ErrorCode.NotFound));
            }
            var Request = new PermissionRequest
            {
                ID = request.ID,
                PermissionRequestStatus = RequestStatus.FirstApproval,
            };
            _repository.SaveIncluded(Request, nameof(Request.PermissionRequestStatus));
            _repository.SaveChanges();
            return RequestResult<bool>.Success(true);
        }
    }
}
