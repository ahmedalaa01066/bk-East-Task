using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Models.Enums;
using EasyTask.Models.PermissionRequests;

namespace EasyTask.Features.PermissionRequests.EditPermissionRequest.Commands
{
    public record EditPermissionRequestCommand(string ID, string PermissionId, DateOnly Date,
        TimeSpan FromTime, TimeSpan ToTime):IRequestBase<bool>;
    public class EditPermissionRequestCommandHandler : RequestHandlerBase<PermissionRequest, EditPermissionRequestCommand, bool>
    {
        public EditPermissionRequestCommandHandler(RequestHandlerBaseParameters<PermissionRequest> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(EditPermissionRequestCommand request, CancellationToken cancellationToken)
        {
            var permissionRequest = await _repository.GetByIDAsync(request.ID);

            if (permissionRequest == null)
                return RequestResult<bool>.Failure(ErrorCode.NotFound);
            if(permissionRequest.PermissionRequestStatus!=RequestStatus.Pending)
                return RequestResult<bool>.Failure(ErrorCode.CannotEdit);

            permissionRequest.PermissionId=request.PermissionId;
            permissionRequest.Date=request.Date;
            permissionRequest.FromTime=request.FromTime;
            permissionRequest.ToTime=request.ToTime;

            _repository.SaveIncluded(permissionRequest, nameof(permissionRequest.PermissionId),
                nameof(permissionRequest.Date), nameof(permissionRequest.FromTime), nameof(permissionRequest.ToTime));

            _repository.SaveChanges();

            return RequestResult<bool>.Success(true);
        }
    }
}
