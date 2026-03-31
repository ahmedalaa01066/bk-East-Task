using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Models.Permissions;

namespace EasyTask.Features.Permissions.EditPermission.Commands
{
    public record EditPermissionCommand(string ID, string Name, int MaxHours, int MinHours,
        int MaxRepeatTimes, int MaxHoursPerMonth) : IRequestBase<bool>;
    public class EditPermissionCommandHandler : RequestHandlerBase<Permission, EditPermissionCommand, bool>
    {
        public EditPermissionCommandHandler(RequestHandlerBaseParameters<Permission> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(EditPermissionCommand request, CancellationToken cancellationToken)
        {
            var Permission = await _repository.GetByIDAsync(request.ID);

            if (Permission == null)
                return RequestResult<bool>.Failure(ErrorCode.NotFound);

            Permission.Name = request.Name;
            Permission.MaxHours = request.MaxHours;
            Permission.MinHours = request.MinHours;
            Permission.MaxRepeatTimes = request.MaxRepeatTimes;
            Permission.MaxHoursPerMonth = request.MaxHoursPerMonth;
            _repository.SaveIncluded(Permission, nameof(Permission.Name), nameof(Permission.MaxHours)
                , nameof(Permission.MinHours), nameof(Permission.MaxRepeatTimes),
                nameof(Permission.MaxHoursPerMonth));

            _repository.SaveChanges();

            return RequestResult<bool>.Success(true);
        }
    }
}
